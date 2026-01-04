# TreeSitter.CLI

A good demo is the following, it is a test written in C#
which walks the AST tree in post order by calling
`tree-sitter-cpp` parser with these bindings.

You can manually run with:

```console
csharp-tree-sitter parse -files [your test cpp files]
```

To build the language bundle.

```console
csharp-tree-sitter build-bundle -i ./repos -o ./bin
```

## TODO

- [x] Add an command line parser ([commandline](https://github.com/commandlineparser/commandline))
- [x] Support more languages for testing.
- [ ] Add option to pass in languages to load.
- [x] Add build command option.
