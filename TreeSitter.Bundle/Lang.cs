using System.Runtime.InteropServices;

namespace TreeSitter.Bundle
{
    public class TreeSitterCPP
    {
        public const string Name = $"tree-sitter-{ShortName}";
        public const string ShortName = "cpp";

        public static TSLanguage Create() => NativeGrammar.Load(Name);
    }

    public class TreeSitterPython
    {
        public const string Name = $"tree-sitter-{ShortName}";
        public const string ShortName = "python";

        public static TSLanguage Create() => NativeGrammar.Load(Name);
    }
}
