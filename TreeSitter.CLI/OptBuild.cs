using CommandLine;
using System;
using System.IO;

namespace TreeSitter.CLI
{
    [Verb("build", HelpText = "Build the language bundle")]
    internal class OptBuild
    {
        [Option('o', "output"
            , HelpText = "The output directory"
            , Required = true)]
        public string output { get; set; }

        public static int Run(OptBuild opts)
        {
            string[] jss = Directory.GetFiles(
                opts.output, "grammar.js", 
                SearchOption.AllDirectories);

            Console.WriteLine(jss.Length);

            foreach (string js in jss)
            {
                Console.WriteLine(js);
            }

            return 0;
        }
    }
}
