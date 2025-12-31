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

        public TSLanguage Create(string name)
        {
            return new TSLanguage(Resolve(name));
        }

        private IntPtr Resolve(string name)
        {
            string path = Path.Combine(_binPath, name);

            return NativeLibrary.Load(path);
        }

        public static void DownloadLatest()
        {

        }
    }

 
}
