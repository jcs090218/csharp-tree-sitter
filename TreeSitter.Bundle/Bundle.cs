namespace TreeSitter.Bundle
{
    public class TreeSitterBundle
    {
        private string? _binPath = string.Empty;

        public TreeSitterBundle()
        {
            _binPath = Path.GetDirectoryName(Environment.ProcessPath);
        }
        public TreeSitterBundle(string binPath)
        {
            _binPath = binPath;
        }

        public TSLanguage Load(string name)
        {
            if (_binPath == null)
            {
                throw new InvalidOperationException(
                    $"Invalid binary path {_binPath}");
            }

            string path = Path.Combine(_binPath, name);

            return NativeGrammar.Load(path);
        }

        /// <summary>
        /// Download to use the pre-built binaries.
        /// </summary>
        public void DownloadPrebuilt()
        {
            if (_binPath == null)
            {
                throw new InvalidOperationException(
                    $"Invalid binary path {_binPath}");
            }

            DownloadPrebuilt(_binPath);
        }
        private static void DownloadPrebuilt(string path)
        {
            // TODO: ..
        }

        private static string BundleName()
        {
            return "";
        }
    }
}
