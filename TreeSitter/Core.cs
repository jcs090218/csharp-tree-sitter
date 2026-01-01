using System.Runtime.InteropServices;

namespace TreeSitter
{
    public static class TreeSitter
    {
        public const string VERSION = "0.1.0";

        public const string REPO_RELEASE_URL = "https://github.com/jcs090218/csharp-tree-sitter/releases/download/";

        /// <summary>
        /// Return true if the tree-sitter shared library is presented.
        /// </summary>
        private static bool IsReady(string binPath)
        {
            string libName = Native.DLibName("tree-sitter");

            string dll = Path.Combine(binPath, libName);

            return File.Exists(dll);
        }

        /// <summary>
        /// Prepare the prebuilt Tree-sitter binary.
        /// </summary>
        public static bool EnsurePrebuilt()
        {
            return EnsurePrebuiltAsync().GetAwaiter().GetResult();
        }
        public static async Task<bool> EnsurePrebuiltAsync()
        {
            return await EnsurePrebuiltAsync(VERSION);
        }
        public static async Task<bool> EnsurePrebuiltAsync(string version)
        {
            string? processPath = Environment.ProcessPath
                ?? throw new InvalidOperationException("ProcessPath is null");

            string path = Path.GetDirectoryName(processPath)
                ?? throw new InvalidOperationException("DirectoryName is null");

            return await EnsurePrebuiltAsync(version, path);
        }
        public static async Task<bool> EnsurePrebuiltAsync(string version, string? binPath)
        {
            if (binPath == null)
                return false;

            if (IsReady(binPath))
                return true;

            string url = PrebuiltUrl(version);

            string filename = PrebuiltName();

            // The tar/zip file.
            string file = Path.Combine(binPath, filename);

            await Util.DownloadFileAsync(url, file);

            bool result = Native.UnArchive(file, binPath);

            File.Delete(file);

            return result;
        }

        /// <summary>
        /// Return the prebuilt bundle url.
        /// </summary>
        private static string PrebuiltUrl(string version)
        {
            return $"{REPO_RELEASE_URL}{version}/{PrebuiltName()}";
        }

        /// <summary>
        /// Return the prebuilt bundle name.
        /// </summary>
        private static string PrebuiltName()
        {
            string host = HostName();

            string ext = Native.ArchiveExt();

            string arch = Native.ArchName();

            return $"tree-sitter.{arch}-{host}.{ext}";
        }

        private static string HostName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "windows-msvc";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return "macos-none";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "linux-gnu";

            return "unknown";
        }
    }
}
