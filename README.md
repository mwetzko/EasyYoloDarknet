# EasyYoloDarknet

Compile and run [https://github.com/AlexeyAB/darknet](https://github.com/AlexeyAB/darknet) for Windows. Makes it easy to start with. Ideal for beginners.

## Steps to follow

1. Make sure you have Visual Studio 2019 or newer installed. Community edition, Professional, all will work. Make sure you have installed the C++ and C# workloads with it.
2. Make sure you have git installed: [https://git-scm.com/download/win](https://git-scm.com/download/win).
3. Make sure you have Powershell or Pwsh installed. Powershell is already part of Windows 10 or newer. So most users wont need this step. You can download it here: [https://github.com/PowerShell/PowerShell](https://github.com/PowerShell/PowerShell)
4. Check out this repository
5. Run `bootstrap.ps1`. This will compile `darknet.dll` in both x86 and x64 under \bin\x86\ and \bin\x64\
5.1 If you want to use CUDA/CUDNN, run `bootstrap.ps1 -cuda [-cudnn]`. This will compile the x64 version of darknet with CUDA. x86 is not supported and will fallback to the version as if it was not compiled with the -cuda flag
6. Open `src\Detect\Detect.sln` with Visual Studio and run. You will be ask to choose an image to detect objects on. Try a picture with people or cars on it. The current version of this project builds `darknet.dll` without GPU support, so detection might take minutes.

## Important

+ Make sure you have an internet connection while running `bootstrap.ps1`. It will download all necessary tools to compile `darknet.dll`.
+ The compiled `darknet.dll` does require Microsoft Visual C++ Redistributable package. It is installed with Visual Studio by default. You can download it here: [https://docs.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170](https://docs.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170) 
