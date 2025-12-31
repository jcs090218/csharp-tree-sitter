using System.Runtime.InteropServices;

namespace TreeSitter.Bundle
{
    public class TreeSitterBundle
    {
        private string _binPath = string.Empty;

        public TreeSitterBundle(string binPath)
        {
            _binPath = binPath;
        }

        public TSLanguage Load(string name)
        {
            string path = Path.Combine(_binPath, name);
            string symbol = Name2Symbol(name);

            return NativeGrammar.Load(path, symbol);
        }

        public static void DownloadLatest()
        {

        }

        /// <summary>
        /// Convert the name to function symbol
        /// 
        /// Ex: `tree-sitter-cpp` => `tree_sitter_cpp`.
        /// </summary>
        private string Name2Symbol(string name)
        {
            return name.Replace("-", "_");
        }
    }
}
