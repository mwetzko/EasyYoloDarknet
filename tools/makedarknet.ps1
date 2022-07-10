param(
	[Parameter(Mandatory, Position = 0)]
	[ValidateSet('x86', 'x64')]
	[string] $arch
)

$ErrorActionPreference = "Stop"
$InformationPreference = "Continue"

Push-Location (Split-Path -Path $MyInvocation.MyCommand.Definition -Parent)

$arch

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

				$vcpkgdep = Join-Path $vcpkgbin $_
		
				if (Test-Path $vcpkgdep) {
					Write-Information "Processing dependency $($_)..."

					$item = Join-Path $dll $_

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

	$codefiles = New-Object System.Collections.ArrayList
	
	[void]$codefiles.Add((Get-Item -Path "..\src\darknet.def").FullName)

	Get-Item -Path "..\darknet\src\*.c" | ForEach-Object { [void]$codefiles.Add($_.FullName) }
	Get-Item -Path "..\darknet\src\*.cpp" -Exclude "yolo_console_dll.cpp" | ForEach-Object { [void]$codefiles.Add($_.FullName) }

	$inc = (Get-Item -Path "..\darknet\include").FullName

	$vcpkginc = (Get-Item -Path "..\vcpkg\installed\$($arch)-windows\include").FullName
	$vcpkglib = (Get-Item -Path "..\vcpkg\installed\$($arch)-windows\lib").FullName
	$vcpkgbin = (Get-Item -Path "..\vcpkg\installed\$($arch)-windows\bin").FullName

	$libs = New-Object System.Collections.ArrayList
	
	$pthread = Get-Item -Path (Join-Path $vcpkglib "pthreadVC*.lib") | Where-Object { $_.Name -match "pthreadVC[0-9]+\.lib" } | Select-Object -First 1
	
	$codefiles.Add($pthread.FullName)
	
	Get-Item -Path (Join-Path $vcpkglib "opencv_world.lib") | ForEach-Object { [void]$libs.Add($_.FullName) }

	$path = Join-Path (Get-Item -Path "..").FullName "obj\$($arch)\"

	if (Test-Path $path) {
		Remove-Item $path -Recurse -Force
	}

	$null = New-Item $path -ItemType "directory"

	Push-Location $path

	try {
		& "cl.exe" /Gd /EHsc /DWIN32 /DOPENCV /DUSE_CMAKE_LIBS /Fedarknet /I $vcpkginc /I $inc /LD $codefiles $libs

		if (!$?) {
			throw "Compiling darknet $($arch) failed."
		}
	}
	finally {
		Pop-Location
	}

	$dll = Join-Path (Get-Item -Path "..").FullName "bin\$($arch)\"

	if (Test-Path $dll) {
		Remove-Item $dll -Recurse -Force
	}

	$null = New-Item $dll -ItemType "directory"

	$darknet = Join-Path $dll "darknet.dll"

	Move-Item -Path (Join-Path $path "darknet.dll") $darknet

	$deps = & ".\EnumDependencies\EnumDependencies\bin\EnumDependencies.exe" $darknet

	$libs = New-Object System.Collections.ArrayList

	My-Do-Dependencies -deps $deps -libs $libs -vcpkgbin $vcpkgbin -dll $dll	
}
finally {
	Restore-EnvVars

	Pop-Location
}