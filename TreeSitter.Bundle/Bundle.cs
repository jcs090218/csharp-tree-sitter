using System.Runtime.InteropServices;

namespace TreeSitter.Bundle
{
    public static class TreeSitterBundle
    {
        /// <summary>
        /// Prepare the language.
        /// </summary>
        public static TSLanguage Load(string lang)
        {
            bool success = EnsurePrebuilt(lang);

            if (!success)
                throw new InvalidDataException($"Invalid bundle name: {lang}");

            return NativeGrammar.Load(lang);
        }

        /// <summary>
        /// Return true if the tree-sitter shared library is presented.
        /// </summary>
        private static bool IsReady(string binPath, string lang)
        {
            string libName = Native.DLibName($"tree-sitter-{lang}");

            string dll = Path.Combine(binPath, libName);

            return File.Exists(dll);
        }

        /// <summary>
        /// Prepare the prebuilt Tree-sitter language bundle.
        /// </summary>
        public static bool EnsurePrebuilt(string lang)
        {
            return EnsurePrebuiltAsync(lang).GetAwaiter().GetResult();
        }
        public static async Task<bool> EnsurePrebuiltAsync(string lang)
        {
            return await EnsurePrebuiltAsync(lang, TreeSitter.VERSION);
        }
        public static async Task<bool> EnsurePrebuiltAsync(string lang, string version)
        {
            string? processPath = Environment.ProcessPath
                ?? throw new InvalidOperationException("ProcessPath is null");

            string path = Path.GetDirectoryName(processPath)
                ?? throw new InvalidOperationException("DirectoryName is null");

            return await EnsurePrebuiltAsync(lang, version, path);
        }
        public static async Task<bool> EnsurePrebuiltAsync(string lang, string version, string? binPath)
        {
            if (binPath == null)
                return false;

            if (IsReady(binPath, lang))
                return true;


            string url = PrebuiltUrl(version, lang);

            string filename = PrebuiltName(lang);

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
        private static string PrebuiltUrl(string version, string lang)
        {
            return $"{TreeSitter.REPO_RELEASE_URL}{version}/{PrebuiltName(lang)}";
        }

        /// <summary>
        /// Return the prebuilt bundle name.
        /// </summary>
        private static string PrebuiltName(string lang)
        {
            string host = HostName();

            string ext = Native.ArchiveExt();

            string arch = Native.ArchName();

            return $"tree-sitter-{lang}.{arch}-{host}.{ext}";
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
