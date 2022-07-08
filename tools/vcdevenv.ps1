param (
    [Parameter(Mandatory = $true)]
    [ValidateSet('x86', 'x64')]
    $arch
)

function Invoke-VCDevEnvironment {
    $installationPath = & ".\vswhere.exe" -latest -property installationPath
    $Command = Join-Path $installationPath "VC\Auxiliary\Build\vcvarsall.bat"

    if (!(Test-Path $Command)) {
        throw "vcvarsall.bat not found!"
    }

    & "${env:COMSPEC}" /s /c "`"$Command`" $($arch) && set" | Foreach-Object {
        if ($_ -match '^([^=]+)=(.*)') {
            [System.Environment]::SetEnvironmentVariable($matches[1], $matches[2])
        }
    }
}

$ErrorActionPreference = "Stop"

Push-Location (Split-Path -Path $MyInvocation.MyCommand.Definition -Parent)

try {
    if (!(Test-Path ".\vswhere.exe")) {
        $data = Invoke-WebRequest "https://api.github.com/repos/microsoft/vswhere/releases/latest" | ConvertFrom-Json
        Invoke-WebRequest "https://github.com/microsoft/vswhere/releases/download/$($data.tag_name)/vswhere.exe" -OutFile "vswhere.exe"
    }

    if (!$env:DevEnvDir) {
        Write-Host "Loading VC $($arch) Build Environment..."
        Invoke-VCDevEnvironment
    }
}
finally {
    Pop-Location
}