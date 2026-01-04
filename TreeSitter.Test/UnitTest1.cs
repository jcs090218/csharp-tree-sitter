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

            Util.ParseWithLangFile(TreeSitterBundle.Language.dockerfile, path);

            Assert.Pass();
        }

        [Test]
        public void parse_dockerfile_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.dockerfile, @"
# EditorConfig helps developers define and maintain consistent
# coding styles between different editors and IDEs
# editorconfig.org

root = true


[*]
end_of_line = lf
charset = utf-8
trim_trailing_whitespace = true
insert_final_newline = true
indent_style = space
indent_size = 2

[*.txt]
indent_style = tab
indent_size = 4

[*.{diff,md}]
trim_trailing_whitespace = false

");

            Assert.Pass();
        }

        #endregion

        #region Editorconfig

        [Test]
        public void parse_editorconfig_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "editorconfig", ".editorconfig");

            Util.ParseWithLangFile(TreeSitterBundle.Language.editorconfig, path);

            Assert.Pass();
        }

        [Test]
        public void parse_editorconfig_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.editorconfig, @"
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

        #region Emacs Lisp

        [Test]
        public void parse_elisp_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "elisp", "example_1.el");

            Util.ParseWithLangFile(TreeSitterBundle.Language.elisp, path);

            Assert.Pass();
        }

        [Test]
        public void parse_elisp_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.elisp, @"
(defun my-wrap-markup-region ()
  ""Insert a markup <b></b> around a region.""
  (interactive)
  (let ((p1 (region-beginning)) (p2 (region-end)))
    (goto-char p2)
    (insert ""</b>"")
    (goto-char p1)
    (insert ""<b>"")))

");

            Assert.Pass();
        }

        #endregion

        #region Elixir

        [Test]
        public void parse_elixir_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "elixir", "example_1.ex");

            Util.ParseWithLangFile(TreeSitterBundle.Language.elixir, path);

            Assert.Pass();
        }

        [Test]
        public void parse_elixir_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.elixir, @"
defmodule Geometry do
  # Clause 1: handles a rectangle tuple {width, height}
  def area({:rectangle, w, h}) do
    w * h
  end

  # Clause 2: handles a circle tuple {radius} only if the radius is a number
  def area({:circle, r}) when is_number(r) do
    3.14 * r * r
  end
end

# Example usage:
IO.puts(Geometry.area({:rectangle, 2, 3}))
IO.puts(Geometry.area({:circle, 3}))

");

            Assert.Pass();
        }

        #endregion

        #region Elm

        [Test]
        public void parse_elm_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "elm", "example_1.elm");

            Util.ParseWithLangFile(TreeSitterBundle.Language.elm, path);

            Assert.Pass();
        }

        [Test]
        public void parse_elm_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.elm, @"
module Main exposing (..)

import Browser
import Html exposing (Html, button, div, text)
import Html.Events exposing (onClick)

-- MAIN
main =
    Browser.sandbox { init = init, update = update, view = view }

-- MODEL
-- The Model is the state of your application.
type alias Model = Int

init : Model
init =
    0

-- UPDATE
-- Update is a way to update your state based on messages (actions).
-- Define the possible messages using a custom type.
type Msg
    = Increment
    | Decrement

update : Msg -> Model -> Model
update msg model =
    case msg of
        Increment ->
            model + 1

        Decrement ->
            model - 1

-- VIEW
-- The view function turns your model into HTML.
view : Model -> Html Msg
view model =
    div []
        [ button [ onClick Decrement ] [ text ""-"" ]
        , div [] [ text (toString model) ]
        , button [ onClick Increment ] [ text ""+"" ]
        ]

");

            Assert.Pass();
        }

        #endregion

        #region Erlang

        [Test]
        public void parse_erlang_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "erlang", "example_1.erl");

            Util.ParseWithLangFile(TreeSitterBundle.Language.erlang, path);

            Assert.Pass();
        }

        [Test]
        public void parse_erlang_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.erlang, @"
-module(helloworld).
-export([start/0]).

start() ->
    io:fwrite(""Hello, world!\\n"").

");

            Assert.Pass();
        }

        #endregion

        #region Fennel

        [Test]
        public void parse_fennel_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "fennel", "example_1.fnl");

            Util.ParseWithLangFile(TreeSitterBundle.Language.fennel, path);

            Assert.Pass();
        }

        [Test]
        public void parse_fennel_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.fennel, @"
(fn fib [n]
  (if (< n 2)
      n
      (+ (fib (- n 1)) (fib (- n 2)))))

(print (fib 10)) ; Prints 55

");

            Assert.Pass();
        }

        #endregion

        #region F#

        [Test]
        public void parse_fsharp_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "fsharp", "example_1.fs");

            Util.ParseWithLangFile(TreeSitterBundle.Language.fsharp, path);

            Assert.Pass();
        }

        [Test]
        public void parse_fsharp_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.fsharp, @"
// Define a new record type
type ContactCard = { 
    Name : string 
    Phone : string 
    Verified : bool 
}

// Instantiate a record
let contact1 = { Name = ""Alf""; Phone = ""(206) 555-0157""; Verified = false }

// Use ""copy-and-update"" to create a new record from an existing one
let contact2 = { contact1 with Phone = ""(206) 555-0112""; Verified = true }

// Function to process a record
let showContactCard (c: ContactCard) = 
    c.Name + "" Phone: "" + c.Phone + (if not c.Verified then "" (unverified)"" else """")

printfn $""Alf's updated contact card: {showContactCard contact2}""

");

            Assert.Pass();
        }

        #endregion

        #region GDScript

        [Test]
        public void parse_gdscript_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "gdscript", "example_1.gd");

            Util.ParseWithLangFile(TreeSitterBundle.Language.gdscript, path);

            Assert.Pass();
        }

        [Test]
        public void parse_gdscript_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.gdscript, @"
extends Sprite # Inherits from the Sprite class

# Member variables declared at the top of the script have script-wide scope
@export var speed := 400.0 # @export makes the variable visible and editable in the Godot Inspector

func _ready():
    # Called when the node enters the scene tree for the first time
    print(""Player sprite is ready to move!"")
    # Set the initial position to a specific location if desired
    # position = Vector2(500, 500) 

func _process(delta):
    # Called every frame; 'delta' is the elapsed time since the previous frame
    
    # Move the sprite to the right by 'speed' pixels per second
    position.x += speed * delta
    
    # If the sprite goes off-screen (e.g., past x=1200), reset its position
    if position.x > 1200:
        position.x = -100 # Start from the left side again

");

            Assert.Pass();
        }

        #endregion

        #region GLSL

        [Test]
        public void parse_glsl_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "glsl", "example_1.vert");

            Util.ParseWithLangFile(TreeSitterBundle.Language.glsl, path);

            Assert.Pass();
        }

        [Test]
        public void parse_glsl_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.glsl, @"
// A very basic fragment shader
void main() {
    // gl_FragColor is a built-in output variable that holds the final color of the fragment.
    // vec4 is a 4-component vector used to represent color (R, G, B, A).
    // The values are floats ranging from 0.0 to 1.0.
    gl_FragColor = vec4(1.0, 0.0, 0.0, 1.0); // This sets the color to solid red.
}

");

            Assert.Pass();
        }

        #endregion

        #region Go

        [Test]
        public void parse_go_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "go", "example_1.go");

            Util.ParseWithLangFile(TreeSitterBundle.Language.go, path);

            Assert.Pass();
        }

        [Test]
        public void parse_go_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.go, @"
package main

import ""fmt""
import ""math/cmplx""

func main() {
    // Standard declaration
    var i int = 1
    // Short variable declaration (type inferred)
    j := 2
    
    // Example of basic types
    ToBe := false
    MaxInt := uint64(1<<64 - 1)
    z := cmplx.Sqrt(-5 + 12i)

    fmt.Println(""i:"", i, ""j:"", j)
    fmt.Printf(""Type: %T Value: %v\n"", ToBe, ToBe)
    fmt.Printf(""Type: %T Value: %v\n"", MaxInt, MaxInt)
    fmt.Printf(""Type: %T Value: %v\n"", z, z)
}

");

            Assert.Pass();
        }

        #endregion

        #region Groovy

        [Test]
        public void parse_groovy_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "groovy", "example_1.groovy");

            Util.ParseWithLangFile(TreeSitterBundle.Language.groovy, path);

            Assert.Pass();
        }

        [Test]
        public void parse_groovy_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.groovy, @"
def multiply = { x, y -> x * y } // A closure for multiplication
def applyOperation(operation, a, b) {
    return operation(a, b)
}

def result2 = applyOperation(multiply, 3, 4)
println(""Multiplication: ${result2}"") // Output: Multiplication: 12

");

            Assert.Pass();
        }

        #endregion

        #region Haskell

        [Test]
        public void parse_haskell_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "haskell", "example_1.hs");

            Util.ParseWithLangFile(TreeSitterBundle.Language.haskell, path);

            Assert.Pass();
        }

        [Test]
        public void parse_haskell_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.haskell, @"
main :: IO ()
main = do
    putStrLn ""What is your name?""
    name <- getLine
    putStrLn (""Hello, "" ++ name ++ ""!"")

");

            Assert.Pass();
        }

        #endregion

        #region Haxe

        [Test]
        public void parse_haxe_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "haxe", "example_1.hx");

            Util.ParseWithLangFile(TreeSitterBundle.Language.haxe, path);

            Assert.Pass();
        }

        [Test]
        public void parse_haxe_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.haxe, @"
/**
 * Multi-line comments for documentation.
 */
class Main {
    // Single line comment
    static public function main():Void {
        trace(""Hello World"");
    }
}

");

            Assert.Pass();
        }

        #endregion

        #region HLSL

        [Test]
        public void parse_hlsl_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "hlsl", "example_1.vert");

            Util.ParseWithLangFile(TreeSitterBundle.Language.hlsl, path);

            Assert.Pass();
        }

        [Test]
        public void parse_hlsl_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.hlsl, @"
// declaration of functions
#pragma ps pixelShader
#pragma vs vertexShader

// data structure : before vertex shader (mesh info)
struct vertexInfo
{
    float3 position : POSITION;
    float2 uv: TEXCOORD0;
    float3 color : COLOR;
}

// uniforms : external parameters
sampler2D MyTexture;
float2 UVTile;
matrix4x4 worldViewProjection;

// vertex shader function
v2p vertexShader(vertexInfo input)
{
    v2p output;
    output.position = mul(worldViewProjection, float4(input.position,1.0));
    output.uv = input.uv * UVTile;
    output.color = input.color;
    return output;
}

// pixel shader function
float4 pixelShader(v2p input) : SV_TARGET
{
    float4 color = tex2D(MyTexture, input.uv);
    return color * input.color;
}

");

            Assert.Pass();
        }

        #endregion

        #region HTML

        [Test]
        public void parse_html_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "html", "example_1.html");

            Util.ParseWithLangFile(TreeSitterBundle.Language.html, path);

            Assert.Pass();
        }

        [Test]
        public void parse_html_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.html, @"
<!DOCTYPE html>
<html>
<head>
    <title>Page Title</title>
</head>
<body>

    <h1>This is a Heading</h1>
    <p>This is a paragraph.</p>
    <a href=""https://www.example.com"">This is a link</a>

</body>
</html>

");

            Assert.Pass();
        }

        #endregion

        #region Java

        [Test]
        public void parse_java_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "java", "example_1.java");

            Util.ParseWithLangFile(TreeSitterBundle.Language.java, path);

            Assert.Pass();
        }

        [Test]
        public void parse_java_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.java, @"
public class Main {
    public static void main(String[] args) {
        System.out.println(""Hello World"");
    }
}
// Output:
// Hello World

");

            Assert.Pass();
        }

        #endregion

        #region JavaScript

        [Test]
        public void parse_javascript_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "javascript", "example_1.js");

            Util.ParseWithLangFile(TreeSitterBundle.Language.javascript, path);

            Assert.Pass();
        }

        [Test]
        public void parse_javascript_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.javascript, @"
// Define a function that takes a name as an argument
function greetUser(name) {
  return ""Hello, "" + name + ""!"";
}

// Call the function and store the result
let message = greetUser(""Alice"");

// Log the result
console.log(message); // Hello, Alice!

");

            Assert.Pass();
        }

        #endregion

        #region JSON

        [Test]
        public void parse_json_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "json", "example_1.json");

            Util.ParseWithLangFile(TreeSitterBundle.Language.json, path);

            Assert.Pass();
        }

        [Test]
        public void parse_json_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.json, @"
{
  ""firstName"": ""John"",
  ""lastName"": ""Doe"",
  ""age"": 30,
  ""isStudent"": false,
  ""courses"": [""Math"", ""Science""],
  ""address"": {
    ""street"": ""123 Main St"",
    ""city"": ""Anytown""
  }
}

");

            Assert.Pass();
        }

        #endregion

        #region Julia

        [Test]
        public void parse_julia_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "julia", "example_1.jl");

            Util.ParseWithLangFile(TreeSitterBundle.Language.julia, path);

            Assert.Pass();
        }

        [Test]
        public void parse_julia_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.julia, @"
A = [1 2; 3 4] # A 2x2 matrix
# Output:
# 2×2 Matrix{Int64}:
#  1  2
#  3  4

println(""Maximum value:"", maximum(A))       #> Maximum value: 4
println(""Maximum of abs2 element-wise:"", maximum(abs2, A)) # maximum of the square of each element

x = [1, 2, 3, 4]
y = sin.(x) # apply sin function to each element using the dot operator
println(y)

");

            Assert.Pass();
        }

        #endregion

        #region Kotlin

        [Test]
        public void parse_kotlin_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "kotlin", "example_1.kt");

            Util.ParseWithLangFile(TreeSitterBundle.Language.kotlin, path);

            Assert.Pass();
        }

        [Test]
        public void parse_kotlin_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.kotlin, @"
// A function that returns the maximum of two integers
fun maxOf(a: Int, b: Int): Int { // Specifies Int parameters and Int return type
    if (a > b) {
        return a
    } else {
        return b
    }
}

// A more concise way to write the same function using expression syntax
fun maxOfConcise(a: Int, b: Int) = if (a > b) a else b

fun main() {
    println(""Max of 0 and 42 is ${maxOf(0, 42)}"")
    println(""Max of 5 and 10 is ${maxOfConcise(5, 10)}"")
}

");

            Assert.Pass();
        }

        #endregion

        #region Makefile

        [Test]
        public void parse_make_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "make", "Makefile");

            Util.ParseWithLangFile(TreeSitterBundle.Language.make, path);

            Assert.Pass();
        }

        [Test]
        public void parse_make_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.make, @"
# Variables for compiler and flags
CC = gcc
CFLAGS = -Wall -g
TARGET = hello
SOURCE = hello.c

# Default target: builds the 'hello' executable
all: $(TARGET)

# Rule to build the executable from the source file
$(TARGET): $(SOURCE)
	$(CC) $(CFLAGS) $(SOURCE) -o $(TARGET)

# Rule to clean up generated files
clean:
	rm -f $(TARGET)

");

            Assert.Pass();
        }

        #endregion

        #region Markdown

        [Test]
        public void parse_markdown_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "markdown", "example_1.md");

            Util.ParseWithLangFile(TreeSitterBundle.Language.markdown, path);

            Assert.Pass();
        }

        [Test]
        public void parse_markdown_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.markdown, @"
# Welcome to Markdown!

Markdown is a lightweight markup language for creating formatted text using a plain-text editor.

## Basic Formatting

You can easily add **bold** text, *italic* text, or even ***combined*** emphasis. Need to strike through something? Use ~~two tildes~~.

You can also use `inline code` for quick snippets.

---

## Lists

### Unordered List:
*   First item
*   Second item
    *   You can nest lists by indenting.
*   Third item

### Ordered List:
1.  First ordered item
2.  Second item
3.  Third item
    1.  Nested ordered list.
    2.  Another nested item.

---

## Links and Images

Here is an [example link](https://www.example.com) to a website.

Here is an image (note: actual rendering depends on the image URL and platform support):
![Alt text for the image](https://example.com/image.jpg ""Optional title"")

---

## Blockquotes

> Markdown uses email-style characters for blockquoting.
> > You can even nest blockquotes.

---

## Code Blocks

Use three backticks (\`\`\`) to create fenced code blocks for multiple lines of code, with optional syntax highlighting:

\`\`\`python
def hello_world():
    print(""Hello, world!"")
\`\`\`

---

## Tables

Tables are an extended syntax feature and are great for organizing data.

");

            Assert.Pass();
        }

        #endregion

        #region Nix

        [Test]
        public void parse_nix_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "nix", "example_1.nix");

            Util.ParseWithLangFile(TreeSitterBundle.Language.nix, path);

            Assert.Pass();
        }

        [Test]
        public void parse_nix_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.nix, @"
rec {
  x = ""foo"";
  y = x + ""bar""; # y can refer to x
}

");

            Assert.Pass();
        }

        #endregion

        #region Org

        [Test]
        public void parse_org_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "org", "example_1.org");

            Util.ParseWithLangFile(TreeSitterBundle.Language.org, path);

            Assert.Pass();
        }

        [Test]
        public void parse_org_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.org, @"
#+TITLE: My Org Document Example

* A Top-Level Heading
  This is a paragraph with *bold*, /italic/, _underline_, and =verbatim= text [1].

** A Sub-Heading
   - A list item
   - Another list item

*** A Sub-Sub-Heading

:DRAWER-NAME:
This text is inside a drawer.
:END:

<<TAGS>>

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

        #region Python

        [Test]
        public void parse_python_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "python", "example_1.py");

            Util.ParseWithLangFile(TreeSitterBundle.Language.python, path);

            Assert.Pass();
        }

        [Test]
        public void parse_python_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.python, @"
# Variables can be integers, floats, strings, etc.
x = 10         # integer
y = ""Python""   # string
z = 3.14       # float

# Perform a simple calculation
sum_result = x + 5
print(f""The sum is: {sum_result}"") # Output: The sum is: 15
print(f""The language is: {y}"")

");

            Assert.Pass();
        }

        #endregion

        #region Racket

        [Test]
        public void parse_racket_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "racket", "example_1.rkt");

            Util.ParseWithLangFile(TreeSitterBundle.Language.racket, path);

            Assert.Pass();
        }

        [Test]
        public void parse_racket_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.racket, @"
#lang racket

(define (fib n)
  (cond
    [(= n 0) 0]
    [(= n 1) 1]
    [else (+ (fib (- n 1)) (fib (- n 2)))]))

(fib 30) ; Evaluates to 832040

");

            Assert.Pass();
        }

        #endregion

        #region Ruby

        [Test]
        public void parse_ruby_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "ruby", "example_1.rb");

            Util.ParseWithLangFile(TreeSitterBundle.Language.ruby, path);

            Assert.Pass();
        }

        [Test]
        public void parse_ruby_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.ruby, @"
age = 15

if age >= 18
  puts ""You are an adult.""
elsif age >= 12
  puts ""You are a teenager.""
else
  puts ""You are a child.""
end
# Output: You are a teenager.

");

            Assert.Pass();
        }

        #endregion


        #region Rust

        [Test]
        public void parse_rust_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "rust", "example_1.rs");

            Util.ParseWithLangFile(TreeSitterBundle.Language.rust, path);

            Assert.Pass();
        }

        [Test]
        public void parse_rust_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.rust, @"
fn main() {
    // This variable is immutable by default.
    let foo = 10;
    println!(""The value of foo is {foo}"");

    // To allow modification, use the 'mut' keyword.
    let mut bar = 20;
    println!(""The value of bar is {bar}"");
    bar = 30;
    println!(""The new value of bar is {bar}"");
}

");

            Assert.Pass();
        }

        #endregion

        #region SQL

        [Test]
        public void parse_sql_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "sql", "example_1.sql");

            Util.ParseWithLangFile(TreeSitterBundle.Language.sql, path);

            Assert.Pass();
        }

        [Test]
        public void parse_sql_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.sql, @"
CREATE TABLE Employees (
    ID INT PRIMARY KEY,
    Name VARCHAR(100),
    Salary DECIMAL(10, 2),
    Department VARCHAR(50)
);

");

            Assert.Pass();
        }

        #endregion

        #region Swift

        [Test]
        public void parse_swift_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "swift", "example_1.swift");

            Util.ParseWithLangFile(TreeSitterBundle.Language.swift, path);

            Assert.Pass();
        }

        [Test]
        public void parse_swift_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.swift, @"
// A simple function with no parameters or return value
func sayHello() {
    print(""Hello, Swift!"")
}

sayHello() // Calls the function

// A function with parameters and a return value
func greeting(for person: String) -> String {
    return ""Hello, "" + person + ""!""
}

print(greeting(for: ""Dave"")) // Calls the function and prints the result

");

            Assert.Pass();
        }

        #endregion

        #region TOML

        [Test]
        public void parse_toml_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "toml", "example_1.toml");

            Util.ParseWithLangFile(TreeSitterBundle.Language.toml, path);

            Assert.Pass();
        }

        [Test]
        public void parse_toml_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.toml, @"
# Nested tables use dotted keys in the header.
[database]
server = ""192.168.1.1""
connection_max = 5000

[servers.alpha]
ip = ""10.0.0.1""
dc = ""eqdc10""

[servers.beta]
ip = ""10.0.0.2""
dc = ""eqdc10""

# Arrays of tables use double square brackets.
[[products]]
name = ""Hammer""
sku = 738594937

[[products]]
name = ""Nail""
sku = 284758393
color = ""gray""

");

            Assert.Pass();
        }

        #endregion

        #region TypeScript

        [Test]
        public void parse_typescript_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "typescript", "example_1.ts");

            Util.ParseWithLangFile(TreeSitterBundle.Language.typescript, path);

            Assert.Pass();
        }

        [Test]
        public void parse_typescript_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.typescript, @"
// Function with typed parameters and return type
const sum = (a: number, b: number): number => {
  return a + b;
};

// Example usage
console.log(sum(5, 10)); // Output: 15

// Function with an optional parameter (using ?) and default value
const buildName = (firstName: string, lastName?: string, middleName: string = ""Smith""): string => {
    if (lastName) {
        return firstName + "" "" + middleName + "" "" + lastName;
    }
    return firstName + "" "" + middleName;
};

");

            Assert.Pass();
        }

        #endregion

        #region XML

        [Test]
        public void parse_xml_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "xml", "example_1.xml");

            Util.ParseWithLangFile(TreeSitterBundle.Language.xml, path);

            Assert.Pass();
        }

        [Test]
        public void parse_xml_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.xml, @"
<?xml version=""1.0"" encoding=""UTF-8""?>
<note>
  <to>Tove</to>
  <from>Jani</from>
  <heading>Reminder</heading>
  <body>Don't forget me this weekend!</body>
</note>

");

            Assert.Pass();
        }

        #endregion

        #region YAML

        [Test]
        public void parse_yaml_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "yaml", "example_1.yaml");

            Util.ParseWithLangFile(TreeSitterBundle.Language.yaml, path);

            Assert.Pass();
        }

        [Test]
        public void parse_yaml_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.yaml, @"
<?xml version=""1.0"" encoding=""UTF-8""?>
<note>
  <to>Tove</to>
  <from>Jani</from>
  <heading>Reminder</heading>
  <body>Don't forget me this weekend!</body>
</note>

");

            Assert.Pass();
        }

        #endregion

        #region Zig

        [Test]
        public void parse_zig_example_1()
        {
            string path = Util.FromProjectDir(
                "fixtures", "zig", "example_1.zig");

            Util.ParseWithLangFile(TreeSitterBundle.Language.zig, path);

            Assert.Pass();
        }

        [Test]
        public void parse_zig_example_1_raw()
        {
            Util.ParseWithLangText(TreeSitterBundle.Language.zig, @"
const std = @import(""std"");

pub fn main() !void {
    var i: usize = 1;
    while (i <= 16) : (i += 1) { // The ':(i += 1)' is the while loop continuation expression
        if (i % 15 == 0) {
            std.log.info(""ZiggZagg"", .{});
        } else if (i % 3 == 0) {
            std.log.info(""Zigg"", .{});
        } else if (i % 5 == 0) {
            std.log.info(""Zagg"", .{});
        } else {
            // Using ""{d}"" format specifier for decimal integers
            std.log.info(""{d}"", .{i});
        }
    }
}

");

            Assert.Pass();
        }

        #endregion
    }
}
