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

        #region C

        [Test]
        public void parse_c_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "c", "example_1.c");

            Util.ParseWithLangFile(TreeSitterBundle.Language.c, path);

            Assert.Pass();
        }

        [Test]
        public void parse_c_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.c, @"
#include <stdio.h>

int main() {
    printf(""Hello, World!"");
    return 0;
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

        #region Clojure

        [Test]
        public void parse_clojure_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "clojure", "example_1.clj");

            Util.ParseWithLangFile(TreeSitterBundle.Language.clojure, path);

            Assert.Pass();
        }

        [Test]
        public void parse_clojure_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.clojure, @"
;; A list
'(1 2 3 4)
;; => (1 2 3 4)

;; A vector (more common for general-purpose collections)
[1 2 3 4]
;; => [1 2 3 4]

;; A map (hash map)
(def person {:first ""Han"" :last ""Solo"" :occupation ""smuggler""})
;; => #'user/person

;; Accessing a value in a map (keywords can act as functions)
(:first person)
;; => ""Han""

;; Using a function with a collection
(map inc [1 2 3]) ; inc increments by 1
;; => (2 3 4)

;; Using the 'thread-first' macro to make code more readable
(-> person :occupation count)
;; is equivalent to: (count (:occupation person))
;; => 8

");

            Assert.Pass();
        }

        #endregion

        #region CMake

        [Test]
        public void parse_cmake_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "cmake", "CMakeLists.txt");

            Util.ParseWithLangFile(TreeSitterBundle.Language.cmake, path);

            Assert.Pass();
        }

        [Test]
        public void parse_cmake_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.cmake, @"
cmake_minimum_required(VERSION 3.10)
# set the project name
project(HelloWorld CXX)
# add the executable
add_executable(HelloWorld main.cpp)

");

            Assert.Pass();
        }

        #endregion

        #region Common Lisp

        [Test]
        public void parse_commonlisp_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "commonlisp", "example_1.lisp");

            Util.ParseWithLangFile(TreeSitterBundle.Language.commonlisp, path);

            Assert.Pass();
        }

        [Test]
        public void parse_commonlisp_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.commonlisp, @"
(defun hello-world ()
  ""Returns the string 'Hello, World!'.""
  ""Hello, World!"")

(hello-world) ;=> ""Hello, World!""

");

            Assert.Pass();
        }

        #endregion

        #region CSS

        [Test]
        public void parse_css_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "css", "example_1.css");

            Util.ParseWithLangFile(TreeSitterBundle.Language.css, path);

            Assert.Pass();
        }

        [Test]
        public void parse_css_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.css, @"
selector {
  property: value;
  property: value;
}

");

            Assert.Pass();
        }

        #endregion

        #region CSV

        [Test]
        public void parse_csv_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "csv", "example_1.csv");

            Util.ParseWithLangFile(TreeSitterBundle.Language.csv, path);

            Assert.Pass();
        }

        [Test]
        public void parse_csv_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.csv, @"
firstName,lastName,email
John,Doe,john.doe@example.com
Jane,Smith,jane.smith@example.com

");

            Assert.Pass();
        }

        #endregion

        #region D

        [Test]
        public void parse_d_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "d", "example_1.d");

            Util.ParseWithLangFile(TreeSitterBundle.Language.d, path);

            Assert.Pass();
        }

        [Test]
        public void parse_d_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.d, @"
import std.stdio; // Imports the standard I/O library

void main()
{
    writeln(""Hello, World!""); // writeln prints a line to standard output
}

");

            Assert.Pass();
        }

        #endregion

        #region Dart

        [Test]
        public void parse_dart_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "dart", "example_1.dart");

            Util.ParseWithLangFile(TreeSitterBundle.Language.dart, path);

            Assert.Pass();
        }

        [Test]
        public void parse_dart_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.dart, @"
// Explicit type declaration
String name = 'Voyager I';
int year = 1977;
double antennaDiameter = 3.7;
bool isLaunched = true;

// Type inference using 'var'
var flybyObjects = ['Jupiter', 'Saturn', 'Uranus', 'Neptune']; // List<String>
var image = { // Map<String, Object>
  'tags': ['saturn'],
  'url': '//path/to/saturn.jpg',
};

// Printing variables with string interpolation
print('Name: $name');
print('Year: $year');
print('Flyby objects: $flybyObjects');

");

            Assert.Pass();
        }

        #endregion

        #region Dockerfile

        [Test]
        public void parse_dockerfile_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "dockerfile", "Dockerfile");

            Util.ParseWithLangFile(TreeSitterBundle.Language.dart, path);

            Assert.Pass();
        }

        [Test]
        public void parse_dockerfile_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.dockerfile, @"
# Stage 1: Build the application
FROM node:18-alpine as builder

WORKDIR /app

COPY package*.json ./
RUN npm install && npm cache clean --force
COPY . .
RUN npm run build

# Stage 2: Production stage using a lightweight web server
FROM nginx:alpine

# Copy the built files from the builder stage to the Nginx web server directory
COPY --from=builder /app/dist /usr/share/nginx/html

EXPOSE 80

CMD [""nginx"", ""-g"", ""daemon off;""]

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
