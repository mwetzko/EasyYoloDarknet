param(
	[Parameter(Mandatory = $false)]
	[switch] $cuda,
	[Parameter(Mandatory = $false)]
	[switch] $cudnn,
	[Parameter(Mandatory = $false)]
	[switch] $dbg
)

$ErrorActionPreference = "Stop"
$InformationPreference = "Continue"

Push-Location (Split-Path -Path $MyInvocation.MyCommand.Definition -Parent)

if (!(Get-Command "git.exe" -ErrorAction Ignore)) {
	Write-Error "Git.exe has not been found. Make sure you have git installed!"
	exit
}

if (!(Get-Command "dotnet.exe" -ErrorAction Ignore)) {
	Write-Error "dotnet.exe has not been found. Make sure you have .NET 6 SDK installed!"
	exit
}

if (!(Test-Path ".\vcpkg\bootstrap-vcpkg.bat")) {
	Write-Information "Cloning vcpkg repo..."
	& "git.exe" clone https://github.com/microsoft/vcpkg.git .\vcpkg
}

if (!(Test-Path ".\vcpkg\vcpkg.exe")) {
	Write-Information "Compiling vcpkg..."
	& ".\vcpkg\bootstrap-vcpkg.bat"
}

@("x86", "x64") | ForEach-Object { 
	
	$arch = $_

	@(
		@("detours:$($arch)-windows", "detours\detours.h"), 
		@("stb:$($arch)-windows", "stb_image.h"), 
		@("pthread:$($arch)-windows", "pthread.h"), 
		@("opencv[world]:$($arch)-windows", "opencv2\opencv.hpp")) | ForEach-Object {

		$pack = $_[0]
		$header = $_[1]

		if (!(Test-Path (Join-Path -Path ".\vcpkg\installed\$($arch)-windows\include" -ChildPath $header))) {
			Write-Information "Installing $($pack)..."
			& ".\vcpkg\vcpkg.exe" install $pack
		}

	}

}

if (!(Test-Path ".\darknet\src")) {
	Write-Information "Cloning darknet repo..."
	& "git.exe" clone https://github.com/AlexeyAB/darknet.git .\darknet
}

if (!(Test-Path ".\data\")) {
	$null = New-Item (Join-Path -Path (Get-Location) -ChildPath "data") -ItemType "directory"
}

if (!(Test-Path ".\data\yolov4.weights")) {
	Write-Information "Downloading YoloV4 Weights..."
	Invoke-WebRequest "https://github.com/AlexeyAB/darknet/releases/download/darknet_yolo_v3_optimal/yolov4.weights" -OutFile ".\data\yolov4.weights"
}

@($("GitHubExport.ps1", "GitHub"), @("envvars.ps1", "Visual Studio"), @("vcdevenv.ps1", "Visual Studio")) | ForEach-Object {
	if (!(Test-Path ".\tools\$($_[0])")) {
		Write-Information "Downloading $($_[0])..."
		Invoke-WebRequest "https://github.com/mwetzko/Tools/raw/master/$($_[1])/$($_[0])" -OutFile ".\tools\$($_[0])"
	}
}

if (!(Test-Path ".\tools\EnumDependencies\EnumDependencies\bin\EnumDependencies.exe")) {
	$path = ".\tools\EnumDependencies"

	if (Test-Path $path) {
		Remove-Item $path -Recurse -Force
	}

	& ".\Tools\GitHubExport.ps1" mwetzko Tools Windows/EnumDependencies (Get-Item -Path ".\tools").FullName

	$output = New-Item ".\tools\EnumDependencies\EnumDependencies\bin" -ItemType "directory"

	& "dotnet.exe" publish ".\tools\EnumDependencies\EnumDependencies\EnumDependencies.csproj" -o $output.FullName
}

@("x86", "x64") | ForEach-Object { & ".\tools\makedarknet.ps1" $_ $cuda $cudnn $dbg }
