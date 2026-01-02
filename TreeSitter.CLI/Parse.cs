using System;
using System.Collections.Generic;
using System.IO;
using TreeSitter.Bundle;

namespace TreeSitter.CLI
{
    internal static class Parse
    {
        public static void PostOrderTraverse(string path, string filetext, TSCursor cursor)
        {
            TSCursor rootCursor = cursor;

            for (; ; )
            {
                int so = (int)cursor.current_node().start_offset();
                int eo = (int)cursor.current_node().end_offset();
                int sl = (int)cursor.current_node().start_point().row + 1;
                var field = cursor.current_field();
                var type = cursor.current_symbol();
                bool hasChildren = cursor.goto_first_child();

                var span = filetext.AsSpan(so, eo - so);

                if (hasChildren)
                    continue;

                Console.Out.WriteLine("The node type is {0}, symbol is {1}", type, span.ToString());

                if (cursor.goto_next_sibling())
                    continue;

                do
                {
                    cursor.goto_parent();
                    int so_p = (int)cursor.current_node().start_offset();
                    int eo_p = (int)cursor.current_node().end_offset();
                    var type_p = cursor.current_symbol();
                    var span_p = filetext.AsSpan(so_p, eo_p - so_p);

                    Console.Out.WriteLine("The node type is {0}, symbol is {1}", type_p, span_p.ToString());

                    if (rootCursor == cursor)
                    {
                        Console.Error.WriteLine("done!");
                        return;
                    }
                } while (!cursor.goto_next_sibling());
            }
        }

        public static bool ParseTree(string path, string filetext, TSParser parser)
        {
            TSLanguage lang = TreeSitterBundle.Load(TreeSitterBundle.Language.cpp);

            parser.set_language(lang);

            using var tree = parser.parse_string(null, filetext);

            if (tree == null)
                return false;

            using var cursor = new TSCursor(tree.root_node(), lang);

            PostOrderTraverse(path, filetext, cursor);

            return true;
        }

        public static bool TraverseTree(string filename, string filetext)
        {
            using var parser = new TSParser();
            return ParseTree(filename, filetext, parser);
        }

        public static bool PrintTree(List<string> paths)
        {
            bool good = true;
            foreach (var path in paths)
            {
                var filetext = File.ReadAllText(path);
                if (!TraverseTree(path, filetext))
                {
                    good = false;
                }
            }
            return good;
        }

        public static void PrintErrorAt(string path, string error, params object[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            if (Console.CursorLeft != 0)
                Console.Error.WriteLine();

            Console.Error.WriteLine("{0}(): error {1}", path, string.Format(error, args));
            Console.ForegroundColor = Console.ForegroundColor;
        }

        public static List<string> ArgsToPaths(string[] inputs)
        {
            var files = new List<string>();
            var used = new HashSet<string>();
            var options = new EnumerationOptions();

            options.RecurseSubdirectories = false;
            options.ReturnSpecialDirectories = false;
            options.MatchCasing = MatchCasing.CaseInsensitive;
            options.MatchType = MatchType.Simple;
            options.IgnoreInaccessible = false;

            foreach (string input in inputs)
            {
                if (Directory.Exists(input))
                {
                    PrintErrorAt(input, "XR0101: Path is a directory, not a file spec.");
                    return null;
                }

                string directory = Path.GetDirectoryName(input);
                string pattern = Path.GetFileName(input);

                if (directory == string.Empty)
                    directory = ".";

                if (directory == null || string.IsNullOrEmpty(pattern))
                {
                    PrintErrorAt(input, "XR0102: Path is anot a valid file spec.");
                    return null;
                }

                if (!Directory.Exists(directory))
                {
                    PrintErrorAt(directory, "XR0103: Couldn't find direvtory.");
                    return null;
                }

                int cnt = 0;

                foreach (var filepath in Directory.EnumerateFiles(directory, pattern, options))
                {
                    cnt++;

                    if (!used.Contains(filepath))
                    {
                        files.Add(filepath);
                        used.Add(filepath);
                    }
                }
            }

            return files;
        }
    }
}
