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

        #region C++

        [Test]
        public void parse_cpp_example_1()
        {
            string path = Util.FromProjectDir("fixtures", "cpp", "example_1.cpp");

            Util.ParseWithLangFile(TreeSitterBundle.Language.cpp, path);

            Assert.Pass();
        }

        [Test]
        public void parse_cpp_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.cpp, @"
#include <iostream> // Include the input/output stream library

int main() {
    // std::cout prints to the console
    // std::endl adds a newline character and flushes the stream
    std::cout << ""Hello, World!"" << std::endl;

    return 0; // Indicates that the program ended successfully
}");
        }

        #endregion

        #region C#

        [Test]
        public void parse_c_sharp_example_1()
        {
            string path = Util.FromProjectDir("fixtures", "c-sharp", "example_1.cs");

            Util.ParseWithLangFile(TreeSitterBundle.Language.c_sharp, path);

            Assert.Pass();
        }

        [Test]
        public void parse_c_sharp_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.c_sharp, @"
using System.IO;  // include the System.IO namespace

string writeText = ""Hello World!"";  // Create a text string
File.WriteAllText(""filename.txt"", writeText);  // Create a file and write the content of writeText to it

string readText = File.ReadAllText(""filename.txt"");  // Read the contents of the file
Console.WriteLine(readText);  // Output the content
");
        }

        #endregion

        #region PHP

        [Test]
        public void parse_php_example_1()
        {
            string path = Util.FromProjectDir("fixtures", "php", "example_1.php");

            Util.ParseWithLangFile(TreeSitterBundle.Language.php, path);

            Assert.Pass();
        }

        [Test]
        public void parse_php_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.php, @"
<!DOCTYPE html>
<html>
<body>

<h1>My first PHP page</h1>

<?php
    // This is a single-line comment in PHP
    echo ""Hello World!""; // The echo statement is used to output data
?>

</body>
</html>
");
        }

        #endregion
    }
}
