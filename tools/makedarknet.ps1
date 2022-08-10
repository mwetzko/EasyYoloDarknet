param(
	[Parameter(Mandatory, Position = 0)]
	[ValidateSet('x86', 'x64')]
	[string] $arch,
	[Parameter(Position = 1)]
	[switch] $cuda,
	[Parameter(Position = 2)]
	[switch] $cudnn,
	[Parameter(Position = 3)]
	[switch] $dbg
)

$ErrorActionPreference = "Stop"
$InformationPreference = "Continue"

Push-Location (Split-Path -Path $MyInvocation.MyCommand.Definition -Parent)

"Arch: $($arch)"
"Cuda: $($cuda.IsPresent)"
if ($cuda.IsPresent) {
	"Cudnn: $($cudnn.IsPresent)"
}
"Generate Debug Version: $($dbg.IsPresent)"

if ($dbg.IsPresent) {
	$linkerflag = "/DEBUG"
}
else {
	$linkerflag = "/RELEASE"
}

function My-Do-Dependencies {
	param(
		$deps,
		$libs,
		$vcpkgbin,
		$dll
	)

	if ($deps) {
		$deps | ForEach-Object {

			if ($libs -notcontains $_) {

				[void]$libs.Add($_)

				$vcpkgdep = Join-Path -Path $vcpkgbin -ChildPath $_

				if (Test-Path $vcpkgdep) {
					Write-Information "Processing dependency $($_)..."

					$item = Join-Path -Path $dll -ChildPath $_

					Copy-Item -Path $vcpkgdep $item

					$subs = & ".\EnumDependencies\EnumDependencies\bin\EnumDependencies.exe" $item

					My-Do-Dependencies -deps $subs -libs $libs -vcpkgbin $vcpkgbin -dll $dll
				}
			}
		}
	}
}

. ".\envvars.ps1"

try {
	& ".\vcdevenv.ps1" $arch

	$defines = New-Object System.Collections.ArrayList
	$includes = New-Object System.Collections.ArrayList
	$codefiles = New-Object System.Collections.ArrayList
	$libraries = New-Object System.Collections.ArrayList

	## code files
	[void]$codefiles.Add((Get-Item -Path "..\src\darknet_dll.cpp").FullName) ## add DllMain to intercept exit commands
	Get-Item -Path "..\darknet\src\*.c" | ForEach-Object { [void]$codefiles.Add($_.FullName) }
	Get-Item -Path "..\darknet\src\*.cpp" -Exclude "yolo_console_dll.cpp" | ForEach-Object { [void]$codefiles.Add($_.FullName) }

	if ($cuda.IsPresent -and ($arch -eq "x64")) {
		Get-Item -Path "..\darknet\src\*.cu" | ForEach-Object { [void]$codefiles.Add($_.FullName) }
	}

	# include paths
	[void]$includes.Add((Get-Item -Path "..\darknet\include").FullName)
	[void]$includes.Add((Get-Item -Path "..\vcpkg\installed\$($arch)-windows\include").FullName)

	# lib files
	[void]$libraries.Add((Join-Path -Path (Get-Item -Path "..\vcpkg\installed\$($arch)-windows\lib").FullName -ChildPath "*.lib"))

	#bin files
	$vcpkgbin = (Get-Item -Path "..\vcpkg\installed\$($arch)-windows\bin").FullName

	# ensure clean output
	$path = Join-Path -Path (Get-Item -Path "..").FullName -ChildPath "obj\$($arch)\"

	if (Test-Path $path) {
		Remove-Item $path -Recurse -Force
	}

	$null = New-Item $path -ItemType "directory"

	# defines
	[void]$defines.Add("WIN32")
	[void]$defines.Add("OPENCV")
	[void]$defines.Add("USE_CMAKE_LIBS")

	# check for cuda, only supported with x64
	if ($cuda.IsPresent) {

		if ($arch -eq "x86") {
			Write-Warning "Darknet and CUDA is only supported on x64. Using non-CUDA darknet code for x86 now..."
			Start-Sleep -Seconds 2
		}
		else {
			[void]$defines.Add("GPU")

			$cudapath = Get-Item -Path $Env:CUDA_PATH

			if (!(Test-Path $cudapath)) {
				throw "Cuda path not found! Make sure CUDA_PATH environment variable is set properly!"
			}

			$nvcc = Join-Path -Path $cudapath.FullName -ChildPath "bin" -AdditionalChildPath "nvcc.exe"

			# additional cuda includes
			[void]$includes.Add((Join-Path -Path $cudapath.FullName -ChildPath "include"))

			# additional libraries
			[void]$libraries.Add((Join-Path -Path $cudapath.FullName -ChildPath "lib" -AdditionalChildPath "x64","*.lib"))

			# check for cudnn
			if ($cudnn.IsPresent) {
				[void]$defines.Add("CUDNN")

				$cudnnpath = Get-Item -Path $Env:CUDNN

				if (!(Test-Path $cudnnpath)) {
					throw "Cuda path not found! Make sure CUDNN environment variable is set properly!"
				}

				# additional cudnn includes
				[void]$includes.Add((Join-Path -Path $cudnnpath.FullName -ChildPath "include"))

				# additional cudnn libs
				[void]$libraries.Add((Join-Path -Path $cudnnpath.FullName -ChildPath "lib" -AdditionalChildPath "*.lib"))
			}
		}
	}

	$defs = New-Object System.Collections.ArrayList
	$incs = New-Object System.Collections.ArrayList

	if ($cuda.IsPresent -and ($arch -eq "x64")) {
		# use nvcc compiler

		$defines | ForEach-Object { [void]$defs.Add("-D $($_)") }
		$includes | ForEach-Object { [void]$incs.AddRange($("-I", $_)) }

		& $nvcc -m64 -odir $path $defs $incs -c $codefiles

		if (!$?) {
			throw "Failed to compile darknet with nvcc."
		}

		$def = (Get-Item -Path "..\src\darknet.def").FullName

		Push-Location $path

		try {
			& "link.exe" /DLL $linkerflag /OUT:darknet.dll /DEF:"$($def)" (Join-Path -Path $path -ChildPath "*.obj") $libraries

			if (!$?) {
				throw "Compiling darknet $($arch) failed."
			}
		}
		finally {
			Pop-Location
		}
	}
	else {
		# use cl compiler

		# def files
		[void]$codefiles.Add((Get-Item -Path "..\src\darknet.def").FullName)

		$defines | ForEach-Object { [void]$defs.Add("/D$($_)") }
		$includes | ForEach-Object { [void]$incs.AddRange($("/I", $_)) }

		Push-Location $path

		try {
			& "cl.exe" /Gd /EHsc $defs /Fedarknet $incs /LD $codefiles $libraries /link $linkerflag

			if (!$?) {
				throw "Compiling darknet $($arch) failed."
			}
		}
		finally {
			Pop-Location
		}
	}

	$dll = Join-Path -Path (Get-Item -Path "..").FullName -ChildPath "bin\$($arch)\"

	if (Test-Path $dll) {
		Remove-Item $dll -Recurse -Force
	}

	$null = New-Item $dll -ItemType "directory"

	$darknet = Join-Path -Path $dll -ChildPath "darknet.dll"

	Move-Item -Path (Join-Path -Path $path -ChildPath "darknet.dll") $darknet

	$deps = & ".\EnumDependencies\EnumDependencies\bin\EnumDependencies.exe" $darknet

	$libs = New-Object System.Collections.ArrayList

	My-Do-Dependencies -deps $deps -libs $libs -vcpkgbin $vcpkgbin -dll $dll

	if ($dbg.IsPresent ) {
		$pdb = Join-Path -Path $path -ChildPath "darknet.pdb"

		if (Test-Path $pdb) {
			Move-Item -Path $pdb (Join-Path -Path $dll -ChildPath "darknet.pdb")
		}
	}
}
finally {
	Restore-EnvVars

	Pop-Location
}