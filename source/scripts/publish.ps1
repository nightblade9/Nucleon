dotnet publish

# Assumes Windows, dunno why [System.IO.Path]::Join doesn't work in this script
$baseDirectory = Get-Location
$publishedFilesPath = "NucleonWeb\bin\Release\net8.0\publish"

### Remove some files to shrink the total files down from 600MB. These are relative to $publishedFilePath.
# Interactive UI tests: 247MB we don't need
$fullPath = "$baseDirectory\$publishedFilesPath\runtimes\win-x64\native\interactive_ui_tests.exe"
remove-item -recurse -force $fullPath

# Remove all locales except en-US, saving us ~40MB
$localesPath = "$baseDirectory\$publishedFilesPath\runtimes\win-x64\native\locales"
foreach ($item in [System.IO.Directory]::GetFiles($localesPath))
{
    if ($item.Contains("en-US.pak"))
    {
        continue;
    }

    remove-item -recurse -force $item
}
###

# Already optimal compression
Compress-Archive -LiteralPath $publishedFilesPath -DestinationPath "published.zip"