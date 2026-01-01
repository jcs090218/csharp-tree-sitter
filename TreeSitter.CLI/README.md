# TreeSitter.CLI

A good demo is the following, it is a test written in C#
which walks the AST tree in post order by calling
`tree-sitter-cpp` parser with these bindings.

You can manually run with:

```console
csharp-tree-sitter parse -files [your test cpp files]
```

```console
csharp-tree-sitter build
```

## TODO

- [x] Add an command line parser ([commandline](https://github.com/commandlineparser/commandline))
- [ ] Support more languages for testing.
- [ ] Add option to pass in languages to load.
- [ ] Add build command option.
