# csharp-tree-sitter

## Introduction

This module provides C# bindings to the [Tree-sitter][] parsing library,
which can enable c# developers be able to invoke the tree-sitter libraries
through P/Invoke from their C# code.

## Cloning

This repo includes the needed tree-sitter repos as submodules.
Remember to use the `--recursive` option with git clone.

```console
git clone https://github.com/tree-sitter/csharp-tree-sitter.git --recursive
```

## Building

Requirements:

- Windows-only (the Makefile in the `tree-sitter` has OS-specific stuff in it so far)
- .NET 8

We'll first need to build the dependencies, and then the C# project.

```console
# Navigate to project's `tree-sitter` directory.
cd <project>/tree-sitter

# Build dependencies.
nmake
```

Then build the C# project:

```console
dotnet build csharp-tree-sitter.csproj
```

## Testing

A good demo is the following, it is a test written in C#
which walks the AST tree in post order by calling
`tree-sitter-cpp` parser with these bindings.

Assuming you're in VS Code:

- navigate to a C++ file to be parsed
- press `F5` to run with the default 'launch' configuration

Otherwise, you may manually run with:

```console
csharp-tree-sitter.exe -files [your test cpp files]
```

TODO: continue here

## Contributing

TODO: Explain how other users and developers can contribute to make your code better.

<!-- Links -->

[tree-sitter]: https://github.com/tree-sitter/tree-sitter
