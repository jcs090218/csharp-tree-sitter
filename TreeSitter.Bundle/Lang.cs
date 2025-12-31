using System.Runtime.InteropServices;

namespace TreeSitter.Bundle
{
    public class TreeSitterCPP
    {
        [DllImport("tree-sitter-cpp")]
        private static extern IntPtr tree_sitter_cpp();

        public static TSLanguage Create() => new TSLanguage(tree_sitter_cpp());
    }

    public class TreeSitterPython
    {
        [DllImport("tree-sitter-python")]
        private static extern IntPtr tree_sitter_python();

        public static TSLanguage Create() => new TSLanguage(tree_sitter_python());
    }
}
