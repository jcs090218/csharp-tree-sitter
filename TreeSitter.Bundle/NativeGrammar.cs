using System.Runtime.InteropServices;

namespace TreeSitter.Bundle
{
    /// <summary>
    /// Dynamic load the dynamic link grammar files.
    /// </summary>
    public static class NativeGrammar
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr LanguageFn();

        /// <summary>
        /// Load the grammar to raw pointer.
        /// </summary>
        /// <param name="path"> The path to dynamic binary file. </param>
        public static IntPtr LoadRaw(string path, string symbol)
        {
            IntPtr lib = NativeLibrary.Load(path);

            var fn = Marshal.GetDelegateForFunctionPointer<LanguageFn>(
                NativeLibrary.GetExport(lib, symbol)
            );

            return fn();  // const TSLanguage*
        }

        /// <summary>
        /// Load the grammar to language.
        /// </summary>
        /// <param name="path"> The path to dynamic binary file. </param>
        public static TSLanguage Load(string path)
        {
            string symbol = Path2Symbol(path);
            return Load(path, symbol);
        }
        public static TSLanguage Load(string path, string symbol)
        {
            return new TSLanguage(LoadRaw(path, symbol));
        }

        /// <summary>
        /// Convert the name to function symbol
        /// 
        /// Ex: `tree-sitter-cpp` => `tree_sitter_cpp`.
        /// </summary>
        private static string Path2Symbol(string path)
        {
            string dir = Path.GetDirectoryName(path)!;
            string file = Path.GetFileName(path);

            file = EnsureTSPrefix(file);

            return file.Replace('-', '_');
        }

        /// <summary>
        /// Ensure the string is with `tree-sitter-` binary prefix.
        /// </summary>
        private static string EnsureTSPrefix(string symbol)
        {
            if (symbol.StartsWith("tree-sitter-") ||
                symbol.StartsWith("tree_sitter_"))
                return symbol;

            return $"tree-sitter-{symbol}";
        }
    }
}
