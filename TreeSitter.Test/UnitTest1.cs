using TreeSitter.Bundle;

namespace TreeSitter.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Ensure the core shared library is presented.
            TreeSitter.EnsurePrebuilt();
        }

        [Test]
        public void parse_cpp_example_1()
        {
            string path = Util.FromProjectDir("fixtures", "cpp", "example_1.cpp");

            Util.ParseWithLang(TreeSitterBundle.Language.cpp, path);

            Assert.Pass();
        }
    }
}
