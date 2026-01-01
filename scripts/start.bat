@echo off

set DOT_NET=net8.0

set "PATH=%PATH%;./TreeSitter.CLI/bin/Debug/%DOT_NET%/"
set "PATH=%PATH%;./TreeSitter.CLI/bin/Release/%DOT_NET%/"

:: Back to project root.
cd ..

echo "Entering an new shell."

cmd /k
