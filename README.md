# EasyYoloDarknet

Compile and run [https://github.com/AlexeyAB/darknet](https://github.com/AlexeyAB/darknet) for Windows. Makes it easy to start with. Ideal for beginners.

## Steps to follow

1. Make sure you have Visual Studio 2019 or newer installed. Community edition, Professional, all will work. Make sure you have installed the C++ and C# workloads with it.
2. Make sure you have git installed: [https://git-scm.com/download/win](https://git-scm.com/download/win).
3. Make sure you have Powershell or Pwsh installed. Powershell is already part of Windows 10 or newer. So most users wont need this step. You can download it here: [https://github.com/PowerShell/PowerShell](https://github.com/PowerShell/PowerShell)
4. Check out this repository
5. Run `bootstrap.ps1`. This will compile `darknet.dll` in both x86 and x64 under \bin\x86\ and \bin\x64\
5.1 If you want to use CUDA/CUDNN, run `bootstrap.ps1 -cuda [-cudnn]`. This will compile the x64 version of darknet with CUDA. x86 is not supported and will fallback to the version as if it was not compiled with the -cuda flag
5.2 If you compile with -cuda (optionally with -cudnn) please follow the install instructions for CUDA/CUDNN below
6. Open `src\Detect\Detect.sln` with Visual Studio and run. You will be ask to choose an image to detect objects on. Try a picture with people or cars on it. The current version of this project builds `darknet.dll` without GPU support, so detection might take minutes.

## Important

+ Make sure you have an internet connection while running `bootstrap.ps1`. It will download all necessary tools to compile `darknet.dll`.
+ The compiled `darknet.dll` does require Microsoft Visual C++ Redistributable package. It is installed with Visual Studio by default. You can download it here: [https://docs.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170](https://docs.microsoft.com/en-us/cpp/windows/latest-supported-vc-redist?view=msvc-170) 

## Install CUDA/CUDNN (Optional)

1. Download Nvidia CUDA Tookit (~2 to ~3 GB) [https://developer.nvidia.com/cuda-downloads](https://developer.nvidia.com/cuda-downloads). I did the 11.7 version.

2. Run the Nvidia CUDA Tookit Installer, select custom install to choose only `CUDA`. You are free to install all the software the installer offers, but for now we don't need Audio Drivers, Graphics or Physics!

3. While installing, Nvidia CUDA Toolkit will check, if you have Visual Studio installed and will install proper Visual Studio references for you. These are not necessary for this project, but will help you creating CUDA applications with Visual Studio.

4. Download CUDNN. Either register with Nvidia to get the latest version of CUDNN or download one of the archive versions. Make sure the major version of CUDNN matches the major version of CUDA. So if you have installed CUDA 11.7, you have to download CUDNN for CUDA 11.x [https://developer.nvidia.com/rdp/cudnn-archive](https://developer.nvidia.com/rdp/cudnn-archive). For me it said 'Download cuDNN v8.4.1 (May 27th, 2022), **for CUDA 11.x**'

5. After download, extract the CUDNN zip archive, and copy all contents where you want. I copied all to the folder, where the CUDA Toolkit was installed. But instead of copying them into the CUDA folder, I created a separate folder named `CUDNN` next to the `CUDA` folder.\
![image](https://user-images.githubusercontent.com/49561427/177331567-f0681d9c-5036-432b-ad13-4ba26e8686cc.png)

6. Inside this new folder, I created a folder named `11.x`.\
![image](https://user-images.githubusercontent.com/49561427/177331818-e35d3713-89fe-4ecc-9541-75854810c542.png)

7. Into that folder copy all folders you extracted from the CUDNN zip file:\
![image](https://user-images.githubusercontent.com/49561427/177331996-c5ee4ec9-e446-4094-a070-d4d934e4d641.png)

8. Create the environment variable `CUDNN` pointing to the folder we just created:\
![image](https://user-images.githubusercontent.com/49561427/177332790-05ae62f9-2ecb-48ef-87f1-ae0ff31a0728.png)
