using System.Threading.Tasks;
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
        public static async Task Main(string[] args)
        {
            await TreeSitter.EnsurePrebuilt();

            var result = Parser.Default.ParseArguments<
                OptGlobal, OptParse , OptBuild
                >(args);

            result.MapResult(
                (OptParse opts) => OptParse.Run(opts),
                (OptBuild opts) => OptBuild.Run(opts),
                errs => 1);
        }
    }
}
