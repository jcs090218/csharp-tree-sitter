using System.Runtime.InteropServices;

namespace TreeSitter.Bundle
{
    public static class TreeSitterBundle
    {
        // The supported language for our prebuilt bundle.
        public enum Language
        {
            c_sharp,
            //c,
            cpp,
            php,
            php_only,
        }

        private static string LangName(Language lang)
        {
            switch (lang)
            {
                case Language.c_sharp: return "c-sharp";
            }

            return lang.ToString();
        }

        /// <summary>
        /// Prepare the language.
        /// </summary>
        public static TSLanguage Load(Language lang)
        {
            string name = LangName(lang);

            return Load(name);
        }
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
            string libName = Native.DLibName($"{lang}");

            string dll = Path.Combine(binPath, libName);

            return File.Exists(dll);
        }

        /// <summary>
        /// Prepare the prebuilt Tree-sitter language bundle.
        /// </summary>
        public static bool EnsurePrebuilt()
        {
            bool success = true;

            List<Language> langs = Enum.GetValues(typeof(Language))
                .Cast<Language>().ToList();

            foreach (Language lang in langs)
            {
                // If one fails, it will return false.
                if (!EnsurePrebuilt(lang))
                    success = false;
            }

            return success;
        }
        public static bool EnsurePrebuilt(Language lang)
        {
            string name = LangName(lang);
            return EnsurePrebuilt(name);
        }
        public static bool EnsurePrebuilt(string lang)
        {
            return EnsurePrebuiltAsync(lang).GetAwaiter().GetResult();
        }
        private static async Task<bool> EnsurePrebuiltAsync(string lang)
        {
            return await EnsurePrebuiltAsync(lang, TreeSitter.VERSION);
        }
        private static async Task<bool> EnsurePrebuiltAsync(string lang, string version)
        {
            string? processPath = Environment.ProcessPath
                ?? throw new InvalidOperationException("ProcessPath is null");

            string path = Path.GetDirectoryName(processPath)
                ?? throw new InvalidOperationException("DirectoryName is null");

            return await EnsurePrebuiltAsync(lang, version, path);
        }
        private static async Task<bool> EnsurePrebuiltAsync(string lang, string version, string? binPath)
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
        private static string PrebuiltName(string _lang)
        {
            // XXX: The parameter `_lang` is not used, the 
            // original design was to load only the used languages.

            string host = Native.HostName();

            string ext = Native.ArchiveExt();

            string arch = Native.ArchName();

            return $"tree-sitter-bundle.{arch}-{host}.{ext}";
        }
    }
}
