param(
	[Parameter(Mandatory, Position = 0)]
	[ValidateSet('x86', 'x64')]
	$arch
)

$ErrorActionPreference = "Stop"

Push-Location (Split-Path -Path $MyInvocation.MyCommand.Definition -Parent)

. ".\envvars.ps1"

try {
	& ".\vcdevenv.ps1" $arch

	$codefiles = New-Object System.Collections.ArrayList
	
	Get-Item -Path (Join-Path (Get-Location)  '..\darknet\src\*.c') | ForEach-Object { [void]$codefiles.Add($_.FullName) }
	Get-Item -Path (Join-Path (Get-Location)  '..\darknet\src\*.cpp') -Exclude "yolo_console_dll.cpp" | ForEach-Object { [void]$codefiles.Add($_.FullName) }

	$inc = (Get-Item -Path "..\darknet\include").FullName

	$vcpkginc = (Get-Item -Path "..\vcpkg\installed\$($arch)-windows\include").FullName

	$libs = New-Object System.Collections.ArrayList
	
	Get-Item -Path "..\vcpkg\installed\$($arch)-windows\lib\pthread*.lib" -Exclude "pthread*E*.lib" | ForEach-Object { [void]$libs.Add($_.FullName) }
	Get-Item -Path "..\vcpkg\installed\$($arch)-windows\lib\opencv_world.lib" | ForEach-Object { [void]$libs.Add($_.FullName) }

	$path = Join-Path (Get-Item -Path "..").FullName "obj\$($arch)\"

	if (Test-Path $path) {
		Remove-Item $path -Recurse -Force
	}

	$null = New-Item $path -ItemType "directory"

	Push-Location $path

	try {
		& "cl.exe" /Gd /EHsc /DWIN32 /DOPENCV /Fedarknet /I $vcpkginc /I $inc /LD $codefiles $libs

		if (!$?) {
			throw "Compiling darknet $($arch) failed."
		}
	}
	finally {   
		Pop-Location
	}

	$path = Join-Path $path "darknet.dll"

	$dll = Join-Path (Get-Item -Path "..").FullName "bin\$($arch)\"

	if (Test-Path $dll) {
		Remove-Item $dll -Recurse -Force
	}

	$null = New-Item $dll -ItemType "directory"

	$dll = Join-Path $dll "darknet.dll"

	Move-Item -Path $path $dll
}
finally {
	Restore-EnvVars

	Pop-Location
}