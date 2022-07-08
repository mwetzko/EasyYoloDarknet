# EasyYoloDarknet

Compile and run [https://github.com/AlexeyAB/darknet](https://github.com/AlexeyAB/darknet) for Windows. Makes it easy to start with. Ideal for beginners.

## Steps to follow

1. Make sure you have Visual Studio 2019 or newer installed. Community edition, Professional, all will work.
2. Make sure you have git installed: [https://git-scm.com/download/win](https://git-scm.com/download/win).
3. Make sure you have Powershell or Pwsh installed. Powershell is already part of Windows 10 or newer. So most users wont need this step. You can download it here: [https://github.com/PowerShell/PowerShell](https://github.com/PowerShell/PowerShell)
4. Check out this repository
5. Run `bootstrap.ps1`. This will compile `darknet.dll` in both x86 and x64 under \bin\x86\ and \bin\x64\

## Important

+ Make sure you have an internet connection while running `bootstrap.ps1`. It will download all necessary tools to compile `darknet.dll`.
+ The compiled `darknet.dll` does not need any Microsoft Visual C++ Redistributable package.
