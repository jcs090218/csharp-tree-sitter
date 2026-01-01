[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Release](https://img.shields.io/github/tag/jcs090218/csharp-tree-sitter.svg?label=release&logo=github)](https://github.com/jcs090218/csharp-tree-sitter/releases/latest)
[![Nuget DT](https://img.shields.io/nuget/dt/csharp-tree-sitter?logo=nuget&logoColor=49A2E6)](https://www.nuget.org/packages/csharp-tree-sitter/)

# C# Tree-sitter

[![Build Tree-sitter](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-tree-sitter.yml/badge.svg)](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-tree-sitter.yml)
[![Build Tree-sitter Bundle](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-tree-sitter-bundle.yml/badge.svg)](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-tree-sitter-bundle.yml)
[![Build CLI](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-cli.yml/badge.svg)](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-cli.yml)

## Introduction

This module provides C# bindings to the [Tree-sitter][] parsing library,
which can enable c# developers be able to invoke the tree-sitter libraries
through P/Invoke from their C# code.

## Cloning

This repo includes the needed tree-sitter repos as submodules.
Remember to use the `--recursive` option with git clone.

```console
git clone https://github.com/jcs090218/csharp-tree-sitter.git --recursive
```

## Building

Requirements:

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

WIP.

## Contributing

TODO: Explain how other users and developers can contribute to make your code better.


<!-- Links -->

[tree-sitter]: https://github.com/tree-sitter/tree-sitter
