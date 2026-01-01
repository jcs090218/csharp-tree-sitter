using System.Collections.Generic;
using System.Linq;
using CommandLine;

namespace TreeSitter.CLI
{
    [Verb("parse", HelpText = "Parse souce files with supported grammars")]
    internal class OptParse
    {
        [Option("files", HelpText = "The source files to read")]
        public IEnumerable<string> files { get; set; }

        public static int Run(OptParse opts)
        {
            string[] inputs = opts.files.ToArray();

            List<string> files = null;

            if ((files = Parse.ArgsToPaths(inputs)) != null)
            {
                Parse.PrintTree(files);
            }

            return 0;
        }
    }
}
