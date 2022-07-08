$ErrorActionPreference = "Stop"

Push-Location (Split-Path -Path $MyInvocation.MyCommand.Definition -Parent)

if (!(Test-Path ".\vcpkg\bootstrap-vcpkg.bat")) {
	& "git.exe" clone https://github.com/microsoft/vcpkg.git .\vcpkg
}

if (!(Test-Path ".\vcpkg\vcpkg.exe")) {
	& ".\vcpkg\bootstrap-vcpkg.bat"
}

if (!(Test-Path ".\vcpkg\installed\x86-windows\lib") -or !(Test-Path ".\vcpkg\installed\x86-windows\include\stb_image.h")) {
	& ".\vcpkg\vcpkg.exe" install stb:x86-windows
}

if (!(Test-Path ".\vcpkg\installed\x86-windows\lib") -or !(Test-Path ".\vcpkg\installed\x86-windows\include\pthread.h")) {
	& ".\vcpkg\vcpkg.exe" install pthread:x86-windows
}

if (!(Test-Path ".\vcpkg\installed\x86-windows\lib") -or !(Test-Path ".\vcpkg\installed\x86-windows\lib\opencv_world.lib")) {
	& ".\vcpkg\vcpkg.exe" install opencv[world]:x86-windows
}

if (!(Test-Path ".\vcpkg\installed\x64-windows\lib") -or !(Test-Path ".\vcpkg\installed\x64-windows\include\stb_image.h")) {
	& ".\vcpkg\vcpkg.exe" install stb:x64-windows
}

if (!(Test-Path ".\vcpkg\installed\x64-windows\lib") -or !(Test-Path ".\vcpkg\installed\x64-windows\include\pthread.h")) {
	& ".\vcpkg\vcpkg.exe" install pthread:x64-windows
}

if (!(Test-Path ".\vcpkg\installed\x64-windows\lib") -or !(Test-Path ".\vcpkg\installed\x64-windows\lib\opencv_world.lib")) {
	& ".\vcpkg\vcpkg.exe" install opencv[world]:x64-windows
}

if (!(Test-Path ".\darknet\src")) {
	& "git.exe" clone https://github.com/AlexeyAB/darknet.git .\darknet
}

@("x86", "x64") | ForEach-Object { & ".\tools\makedarknet.ps1" $_ }
