$DOT_NET = "net9.0"

$env:PATH += ";./TreeSitter.CLI/bin/Debug/$DOT_NET"
$env:PATH += ";./TreeSitter.CLI/bin/Release/$DOT_NET"

# Back to project root
Set-Location ..

echo "Entering an new shell."
