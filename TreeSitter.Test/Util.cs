using TreeSitter.Bundle;

namespace TreeSitter.Test
{
    /// <summary>
    /// The test utilities.
    /// </summary>
    internal class Util
    {
        #region Project Paths

        public static DirectoryInfo TryGetSlnDirInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());

            while (directory != null && !directory.GetFiles("*.sln").Any())
                directory = directory.Parent;

            return directory;
        }

        public static string FromProjectDir(params string[] paths)
        {
            DirectoryInfo slnDir = TryGetSlnDirInfo();

            var jPaths = new List<string>();

            jPaths.Add(slnDir.FullName);
            jPaths.Add("TreeSitter.Test");

            jPaths.AddRange(paths);

            return Path.Combine(jPaths.ToArray());
        }

        public static string FromSlnDir(params string[] paths)
        {
            DirectoryInfo slnDir = TryGetSlnDirInfo();

            var jPaths = new List<string>();

            jPaths.Add(slnDir.FullName);

            jPaths.AddRange(paths);

            return Path.Combine(jPaths.ToArray());
        }

        #endregion

        public static void ParseWithLangFile(
            TreeSitterBundle.Language lang,
            string filename)
        {
            string path = FromProjectDir("fixtures", filename);

            var filetext = File.ReadAllText(path);

            ParseWithLangText(lang, filetext);
        }

        public static void ParseWithLangText(
            TreeSitterBundle.Language lang,
            string text)
        {
            using var parser = new TSParser();

            TSLanguage tsLang = TreeSitterBundle.Load(lang);
            parser.set_language(tsLang);

            using var tree = parser.parse_string(null, text);
        }
    }
}
