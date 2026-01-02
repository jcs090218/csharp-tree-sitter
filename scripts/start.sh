#!/usr/bin/env bash

DOT_NET=net9.0

export PATH="$PATH:./TreeSitter.CLI/bin/Debug/$DOT_NET"
export PATH="$PATH:./TreeSitter.CLI/bin/Release/$DOT_NET"

# Back to project root.
cd ..

echo "Entering an new shell."

# Keep the shell open.
exec "$SHELL"
