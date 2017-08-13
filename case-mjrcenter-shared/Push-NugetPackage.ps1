function Push-NugetPackage ([string] $assemblyName, [string] $version) {
    $package = join-path (join-path $PSScriptRoot $assemblyName) "bin\Debug\$assemblyName.$version.nupkg"
    nuget push $package 8228e4da-15db-4477-936c-44e52690395c -Source https://www.myget.org/F/case-mjrcenter-feed/api/v2/package
}
