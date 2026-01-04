[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![Release](https://img.shields.io/github/tag/jcs090218/csharp-tree-sitter.svg?label=release&logo=github)](https://github.com/jcs090218/csharp-tree-sitter/releases/latest)

# C# Tree-sitter

[![Build Tree-sitter](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-tree-sitter.yml/badge.svg)](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-tree-sitter.yml)
[![Build Tree-sitter Bundle](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-tree-sitter-bundle.yml/badge.svg)](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-tree-sitter-bundle.yml)
[![Build CLI](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-cli.yml/badge.svg)](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-cli.yml)
[![Build nupkg](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-nupkg.yml/badge.svg)](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/build-nupkg.yml)
[![Test](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/test.yml/badge.svg)](https://github.com/jcs090218/csharp-tree-sitter/actions/workflows/test.yml)

This module provides C# bindings to the [Tree-sitter][] parsing library,
which can enable c# developers be able to invoke the tree-sitter libraries
through P/Invoke from their C# code.

You can install it by downloading the latest `.nupkg` files from our [release][_self.release] page.

- `TreeSitter.<version>.nupkg` (C# Bindings)
- `TreeSitter.Bundle.<version>.nupkg` (Language Bundle)

## 🏆 Features

- C# bindings for the tree-sitter parsing library.
- Prebuilt language bundle support Windows (`x64`), Linux (`x64`, `arm64`), and macOS (`x64`, `arm64`)
- Lazy loading for shared libraries
- No module definition file (`.def`) required
- Bundle with 50+ languages

## ⚡ Quickstart

```cs
using var parser = new TSParser();

TSLanguage tsLang = TreeSitterBundle.Load(lang);
parser.set_language(tsLang);

using var tree = parser.parse_string(null, @"
#include <iostream> // Include the input/output stream library

int main() {
    // std::cout prints to the console
    // std::endl adds a newline character and flushes the stream
    std::cout << ""Hello, World!"" << std::endl;

    return 0; // Indicates that the program ended successfully
}");
```

## 🔨 Development

### Cloning

This repo includes the needed tree-sitter repos as submodules.
Remember to use the `--recursive` option with git clone.

```console
git clone https://github.com/jcs090218/csharp-tree-sitter.git --recursive
```

#### Submodules Location

The submodules are split into two main sections,

- `core` - Main [tree-sitter][] library.
- `repos` - For language bundle.

### Building

Requirements:

- .NET 9

We'll first need to build the native library, or download the prebuilt binary in our [release][_self.release] page.

See [6. Contributing (Developing Tree-sitter)](https://tree-sitter.github.io/tree-sitter/6-contributing.html#developing-tree-sitter)
for the build process of your choice.

Then build the entire C# projects:

```console
dotnet build
```

### Packaging

We use the standard [NuGet][] packaging process to create reusable packages.

To build `.nupkg` files:

```console
dotnet pack
```

### Testing

The unit test is written using the [Nunit][] framework.

To run tests:

```console
dotnet test
```

### Adding new grammars

Register a new submodule. For example:

```console
git submodule add -b master -- https://github.com/tree-sitter/tree-sitter-rust repos/rust
```

Try building the parser:

```console
csharp-tree-sitter build-bundle -i ./repos -o ./bin
```

Then add the tests to `TreeSitter.Test/UnitTest1.cs`:

```csharp
[Test]
public void parse_rust_example_1()
{
    string path = Util.FromProjectDir(
        "fixtures", "rust", "example_1.rs");

    Util.ParseWithLangFile(TreeSitterBundle.Language.rust, path);

    Assert.Pass();
}
```

Run tests with the command `dotnet test`.

## 🔗 Alternatives

- [csharp-tree-sitter][tree-sitter/csharp-tree-sitter] (official)
- [dotnet-tree-sitter][]
- [tree-sitter-dotnet-bindings][]


<!-- Links -->

[_self.release]: https://github.com/jcs090218/csharp-tree-sitter/releases

[tree-sitter]: https://github.com/tree-sitter/tree-sitter

[tree-sitter/csharp-tree-sitter]: https://github.com/tree-sitter/csharp-tree-sitter
[dotnet-tree-sitter]: https://github.com/zabbius/dotnet-tree-sitter
[tree-sitter-dotnet-bindings]: https://github.com/mariusgreuel/tree-sitter-dotnet-bindings

[NuGet]: https://www.nuget.org/
[Nunit]: https://github.com/nunit/nunit
