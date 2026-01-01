using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandLine;

namespace TreeSitter.CLI
{
    public class Program
    {
        class Options
        {
            [Option("files"
                , HelpText = "The source files to read")]
            public IEnumerable<string> files { get; set; }
        }

        public static async Task Main(string[] args)
        {
            await TreeSitter.EnsurePrebuilt();

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(RunOptions)
                .WithNotParsed(HandleParseError);
        }

        private static void RunOptions(Options opts)
        {
            string[] inputs = opts.files.ToArray();

            List<string> files = null;

            if ((files = Parse.ArgsToPaths(inputs)) != null)
            {
                Parse.PrintTree(files);
            }
        }

        private static void HandleParseError(IEnumerable<Error> errs)
        {
            //handle e
        }
    }
}
