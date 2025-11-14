param(
    [string]$Root = (Get-Location)
)

$rootPath = Resolve-Path $Root
$projectDirs = Get-ChildItem -Path $rootPath -Directory | Where-Object { -not (Test-Path (Join-Path $_.FullName 'README.md')) }

foreach ($dir in $projectDirs) {
    $projectName = $dir.Name
    $readmePath = Join-Path $dir.FullName 'README.md'

    $solution = Get-ChildItem -Path $dir.FullName -Filter *.sln -Recurse -ErrorAction SilentlyContinue | Select-Object -First 1
    $csproj = Get-ChildItem -Path $dir.FullName -Filter *.csproj -Recurse -ErrorAction SilentlyContinue | Where-Object { $_.FullName -notmatch '\\bin\\|\\obj\\' } | Select-Object -First 1

    $relativeSolution = $null
    $relativeProject = $null

    if ($solution) {
        $relativeSolution = [System.IO.Path]::GetRelativePath($dir.FullName, $solution.FullName)
    }

    if ($csproj) {
        $relativeProject = [System.IO.Path]::GetRelativePath($dir.FullName, $csproj.FullName)
    }

    $lines = @()
    $lines += "# $projectName"
    $lines += ""
    $lines += "Bu klasor $projectName adli .NET pratik calismasini icerir."
    $lines += ""
    $lines += "## Calistirma"

    if ($relativeSolution) {
        $lines += [string]::Format("- Visual Studio ile acmak icin: {0}", $relativeSolution)
    }

    if ($relativeProject -or $relativeSolution) {
        $lines += '- Komut satirindan calistirmak icin:'
        $lines += "  ```bash"
        $lines += ('  cd "{0}"' -f $dir.Name)
        if ($relativeSolution) {
            $lines += ('  dotnet restore "{0}"' -f $relativeSolution)
        } else {
            $lines += "  dotnet restore"
        }
        if ($relativeProject) {
            $lines += ('  dotnet run --project "{0}"' -f $relativeProject)
        } else {
            $lines += "  dotnet run"
        }
        $lines += "  ```"
    } else {
        $lines += '- Bu klasor icinde otomatik algilanan bir .sln veya .csproj bulunamadigindan calistirma adimlarini proje turune gore el ile uygulayin.'
    }

    $lines += ""
    $lines += "## Onemli Dosyalar"
    if ($relativeSolution) {
        $lines += [string]::Format('- {0}', $relativeSolution)
    }
    if ($relativeProject -and ($relativeSolution -ne $relativeProject)) {
        $lines += [string]::Format('- {0}', $relativeProject)
    }
    if (!$relativeSolution -and !$relativeProject) {
        $lines += '- Ozel giris noktasi dosyalarini manuel kontrol edin.'
    }

    Set-Content -Path $readmePath -Value $lines -Encoding UTF8
}
