function Find-EnvObject {
    param (
        [Parameter(Position = 0)]
        $key,
        [Parameter(Position = 1)]
        $vars
    )
    
    for ($i = 0; $i -lt $vars.Count; $i++) {
        if ($vars[$i].Key -eq $key) {       
            return $vars[$i]
        }
    }

    return $null
}

$script:capturedvars = Get-ChildItem env:*

function Restore-EnvVars {    

    Get-ChildItem env:* | ForEach-Object {

        $obj = Find-EnvObject $_.Key $script:capturedvars

        if ($obj) {
            [System.Environment]::SetEnvironmentVariable($_.Key, $obj.Value)
        }
        else {
            [System.Environment]::SetEnvironmentVariable($_.Key, $null)
        }
    }
}