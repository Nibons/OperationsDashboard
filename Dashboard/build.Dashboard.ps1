param([string]$configuration="Development",
[string]$framework="netcoreapp2.0",
[string]$outputPath="obj/$configuration/$framework/",
[validateset("quiet","minimal","normal","detailed","diagnostic")]
[string]$verbosity='minimal'
)
#restore the dotNet dependencies
dotnet restore

#compile the dotNet depencies for running
dotnet build --configuration $configuration --framework $framework --output $outputPath --verbosity $verbosity

#compile the angular4App to wwwroot
$wwwRootOutputPath = "$outputPath/wwwroot"
if($configuration -eq 'Production'){
    #build as Production
    ng build -prod --output-path=$wwwRootOutputPath
}else{
    ng build --output-path=$wwwRootOutputPath
}