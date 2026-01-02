using TreeSitter.Bundle;

namespace TreeSitter.Test
{
    public class Tests
    {
        public static DirectoryInfo TryGetSlnDirInfo(string currentPath = null)
        {
            var directory = new DirectoryInfo(currentPath ?? Directory.GetCurrentDirectory());

            while (directory != null && !directory.GetFiles("*.sln").Any())
                directory = directory.Parent;

            return directory;
        }

        private static string FromSlnDir(params string[] paths)
        {
            DirectoryInfo slnDir = TryGetSlnDirInfo();

            var jPaths = new List<string>();

            jPaths.Add(slnDir.FullName);

            jPaths.AddRange(paths);

            return Path.Combine(jPaths.ToArray());
        }

        private static string FromProjectDir(params string[] paths)
        {
            DirectoryInfo slnDir = TryGetSlnDirInfo();

            var jPaths = new List<string>();

            jPaths.Add(slnDir.FullName);
            jPaths.Add("TreeSitter.Test");

            jPaths.AddRange(paths);

            return Path.Combine(jPaths.ToArray());
        }

        [SetUp]
        public void Setup()
        {
            TreeSitter.EnsurePrebuilt();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void parse_cpp()
        {
            using var parser = new TSParser();

            TSLanguage lang = TreeSitterBundle.Load(TreeSitterBundle.Language.cpp);

            parser.set_language(lang);

            string path = FromProjectDir("fixtures", "cpp", "example_1.cpp");

            var filetext = File.ReadAllText(path);

            using var tree = parser.parse_string(null, filetext);

            Assert.Pass();
        }
    }
}
