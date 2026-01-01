using CommandLine;

namespace TreeSitter.CLI
{
    // @global-options
    class OptGlobal
    {
        // ..
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<
                OptGlobal, OptParse , OptBuildBundle
                >(args);

            result.MapResult(
                (OptParse opts) => OptParse.Run(opts),
                (OptBuildBundle opts) => OptBuildBundle.Run(opts),
                errs => 1);
        }
    }
}
