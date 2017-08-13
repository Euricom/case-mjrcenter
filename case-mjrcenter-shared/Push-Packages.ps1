param(
    [Parameter(Mandatory=$true)]
    [string] $version,

    [Parameter(Mandatory=$true)]
    [ValidateSet('Data','DI','Hosting')]
    [System.String]$library
)
write-host $PSScriptRoot
. .\Push-NugetPackage.ps1
$rootNamespace = 'Euricom.MjrCenter.Shared.'

Push-NugetPackage "$rootNamespace$library" $version
