$ErrorActionPreference = "Stop"

$projectRoot = "C:\RecipeVault"
$tfm = "net8.0-windows10.0.19041.0"
$rid = "win10-x64"
$exe = Join-Path $projectRoot "bin\Debug\$tfm\$rid\RecipeVault.exe"

if (-not (Test-Path $exe)) {
    Write-Host "Build output not found. Building project..."
    dotnet build (Join-Path $projectRoot "RecipeVault.csproj") -f $tfm | Out-Host
}

if (-not (Test-Path $exe)) {
    throw "Unable to find executable at: $exe"
}

Start-Process -FilePath $exe | Out-Null
Write-Host "RecipeVault launched."
