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

#if false
        [Test]
        public void TestExtract()
        {
            string tar = Util.FromProjectDir(
                "_test", "tree-sitter-bundle.x86_64-macos-none.tar");

            string dest = Util.FromProjectDir("_test");

            Native.ExtractTarFile(tar, dest);
        }
#endif

        #region ActionScript

        [Test]
        public void parse_actionscript_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "actionscript", "example_1.as");

            Util.ParseWithLangFile(TreeSitterBundle.Language.actionscript, path);

            Assert.Pass();
        }

        [Test]
        public void parse_actionscript_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.actionscript, @"
package org.wikipedia.example {
    import flash.display.Sprite;
    import flash.text.TextField;

    public class Greeter extends Sprite {
        public function Greeter() {
            // Create a new TextField object
            var txtHello: TextField = new TextField();
            // Set the text content
            txtHello.text = ""Hello World"";
            // Add the TextField to the display list (make it visible on stage)
            this.addChild(txtHello);
        }
    }
}

");

            Assert.Pass();
        }

        #endregion

        #region Ada

        [Test]
        public void parse_ada_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "ada", "example_1.adb");

            Util.ParseWithLangFile(TreeSitterBundle.Language.ada, path);

            Assert.Pass();
        }

        [Test]
        public void parse_ada_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.ada, @"
with Ada.integer_text_IO;
use Ada;

procedure add_by_referance is 
    procedure add(a, b: in Integer; c: out Integer) is
    begin
        c := a + b;
    end add;
    answer : Integer;
begin
    add(3, 5, answer);
    integer_text_IO.put(answer);
end add_by_referance;

");

            Assert.Pass();
        }

        #endregion

        #region Arduino

        [Test]
        public void parse_arduino_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "arduino", "example_1.cpp");

            Util.ParseWithLangFile(TreeSitterBundle.Language.arduino, path);

            Assert.Pass();
        }

        [Test]
        public void parse_arduino_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.arduino, @"
with Ada.integer_text_IO;
use Ada;

procedure add_by_referance is 
    procedure add(a, b: in Integer; c: out Integer) is
    begin
        c := a + b;
    end add;
    answer : Integer;
begin
    add(3, 5, answer);
    integer_text_IO.put(answer);
end add_by_referance;

");

            Assert.Pass();
        }

        #endregion

        #region Assembly

        [Test]
        public void parse_asm_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "asm", "example_1.asm");

            Util.ParseWithLangFile(TreeSitterBundle.Language.asm, path);

            Assert.Pass();
        }

        [Test]
        public void parse_asm_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.asm, @"
global _start

section .text

_start: nop

        ; prompt user for file name
        mov rax, SYS_WRITE
        mov rdi, FD_STDOUT
        mov rsi, str_pname
        mov rdx, len_pname
        syscall

        ; read file name
        mov rax, SYS_READ
        mov rdi, FD_STDIN
        mov rsi, str_name
        mov rdx, len_name
        syscall

");

            Assert.Pass();
        }

        #endregion

        #region Bash

        [Test]
        public void parse_bash_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "bash", "example_1.sh");

            Util.ParseWithLangFile(TreeSitterBundle.Language.bash, path);

            Assert.Pass();
        }

        [Test]
        public void parse_bash_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.bash, @"
#!/bin/bash

# Prompt the user for their name
echo ""What is your name?""

# Read the input from the user and store it in a variable
read USER_NAME

# Print the greeting using the stored variable
echo ""Hello, $USER_NAME! Welcome.""

");

            Assert.Pass();
        }

        #endregion

        #region Beancount

        [Test]
        public void parse_beancount_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "beancount", "example_1.beancount");

            Util.ParseWithLangFile(TreeSitterBundle.Language.beancount, path);

            Assert.Pass();
        }

        [Test]
        public void parse_beancount_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.beancount, @"
;;; A basic example file with some example accounts and transactions.

option ""title"" ""Simple Example Ledger""
option ""operating_currency"" ""USD""

1980-01-01 open Assets:US:BofA:Checking USD
1980-01-01 open Expenses:Food:Groceries USD
1980-01-01 open Income:Salary:Google USD
1980-01-01 open Equity:Opening-Balances USD

;; You must declare accounts before using them in a transaction.

2024-01-01 * ""Initial Balance""
  Assets:US:BofA:Checking 1000.00 USD
  Equity:Opening-Balances -1000.00 USD
  
2024-01-02 * ""Whole Foods"" ""Groceries for the week""
  Expenses:Food:Groceries 50.00 USD
  Assets:US:BofA:Checking -50.00 USD

2024-01-05 * ""Monthly Paycheck""
  Assets:US:BofA:Checking 2000.00 USD
  Income:Salary:Google -2000.00 USD

;; You can also assert a known balance at a specific date.
2024-01-05 balance Assets:US:BofA:Checking 2950.00 USD

");

            Assert.Pass();
        }

        #endregion

        #region BibTex

        [Test]
        public void parse_bibtex_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "bibtex", "example_1.tex");

            Util.ParseWithLangFile(TreeSitterBundle.Language.bibtex, path);

            Assert.Pass();
        }

        [Test]
        public void parse_bibtex_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.beancount, @"
@article{cohen1963independence,
  author  = {P. J. Cohen},
  title   = {The independence of the continuum hypothesis},
  journal = {Proceedings of the National Academy of Sciences},
  year    = {1963},
  volume  = {50},
  number  = {6},
  pages   = {1143--1148}
}

");

            Assert.Pass();
        }

        #endregion

        #region C++

        [Test]
        public void parse_cpp_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "cpp", "example_1.cpp");

            Util.ParseWithLangFile(TreeSitterBundle.Language.cpp, path);

            Assert.Pass();
        }

        [Test]
        public void parse_cpp_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.cpp, @"
# include <iostream> // Include the input/output stream library

int main() {
    // std::cout prints to the console
    // std::endl adds a newline character and flushes the stream
    std::cout << ""Hello, World!"" << std::endl;

    return 0; // Indicates that the program ended successfully
}

");

            Assert.Pass();
        }

        #endregion

        #region C#

        [Test]
        public void parse_c_sharp_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "c-sharp", "example_1.cs");

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

            Assert.Pass();
        }

        #endregion

        #region PHP

        [Test]
        public void parse_php_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "php", "example_1.php");

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
            Assert.Pass();
        }

        #endregion
    }
}
