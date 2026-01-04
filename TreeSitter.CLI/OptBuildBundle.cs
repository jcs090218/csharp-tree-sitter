using System;
using System.IO;
using CommandLine;

namespace TreeSitter.CLI
{
    [Verb("build-bundle", HelpText = "Build the language bundle")]
    internal class OptBuildBundle
    {
        [Option('i', "input"
            , HelpText = "The input directory"
            , Required = true)]
        public string input { get; set; }

        [Option('o', "output"
            , HelpText = "The output directory"
            , Required = true)]
        public string output { get; set; }

        [Option('l', "language"
            , HelpText = "The language to build"
            , Required = false)]
        public string language { get; set; }


        /// <summary>
        /// Returns true if the given path is NOT an invalid node_modules path.
        /// </summary>
        private static bool IsValidPath(string path)
        {
            string normalized = path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);

            string[] segments = normalized.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);

            foreach (string segment in segments)
            {
                if (segment.Equals("node_modules", StringComparison.OrdinalIgnoreCase))
                    return false;
            }

            return true;
        }

        private static void TryBuild(string output, string js, string language)
        {
            string dir = Path.GetDirectoryName(js)!;
            string lang = Path.GetFileName(dir);
            lang = TreeSitter.RemovePrefix(lang);

            if (!string.IsNullOrEmpty(language))
            {
                if (language != lang)
                    return;
            }

            string dlib = Native.DLibName(lang);

            string f_dlib = Path.Combine(output, dlib);

            f_dlib = Path.GetFullPath(f_dlib);  // normalize

            Console.Error.WriteLine($"Compiling {f_dlib}...");

            Util.WithTSCommand(dir, $"generate");
            Util.WithTSCommand(dir, $"build -o {f_dlib}");
        }

        public static int Run(OptBuildBundle opts)
        {
            if (!Util.EnsureExec("npm") ||
                !Util.EnsureExec("tree-sitter"))
                return -1;

            string[] jss = Directory.GetFiles(
                opts.input, "grammar.js",
                SearchOption.AllDirectories);

            string cwd = Directory.GetCurrentDirectory();

            string output = Path.Combine(cwd, opts.output);

            foreach (string js in jss)
            {
                if (!IsValidPath(js))
                    continue;

                TryBuild(output, js, opts.language);
            }

            return 0;
        }
    }
}
