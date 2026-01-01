using System.IO;
using System.Runtime.InteropServices;

namespace TreeSitter
{
    public static class TreeSitter
    {
        private const string DEFAULT_VERSION = "0.1.0";

        private const string URL = "https://github.com/jcs090218/csharp-tree-sitter/releases/download/";

        /// <summary>
        /// Prepare the prebuilt Tree-sitter binary.
        /// </summary>
        public static async Task<bool> EnsurePrebuilt()
        {
            return await EnsurePrebuilt(DEFAULT_VERSION);
        }
        public static async Task<bool> EnsurePrebuilt(string version)
        {
            string path = Path.GetDirectoryName(Environment.ProcessPath);

            return await EnsurePrebuilt(version, path);
        }
        public static async Task<bool> EnsurePrebuilt(string version, string? binPath)
        {
            if (binPath == null)
                return false;

            string url = PrebuiltUrl(version);

            string filename = PrebuiltName();

            Console.Out.WriteLine(filename);

            await DownloadFileAsync(url, Path.Combine(binPath, filename));

            return true;
        }

        /// <summary>
        /// Return the prebuilt bundle url.
        /// </summary>
        private static string PrebuiltUrl(string version)
        {
            return $"{URL}{version}/{PrebuiltName()}";
        }

        /// <summary>
        /// Return the prebuilt bundle name.
        /// </summary>
        private static string PrebuiltName()
        {
            Architecture arch = RuntimeInformation.OSArchitecture;

            string host = HostName();

            string ext = (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                ? "zip"
                : "tar";

            switch (arch)
            {
                case Architecture.X86:
                case Architecture.X64:
                    return $"tree-sitter.x86_64-{host}.{ext}";

                case Architecture.Arm:
                case Architecture.Arm64:
                    return $"tree-sitter.aarch64-{host}.{ext}";
            }

            throw new NotSupportedException($"Architecture '{arch}' is not supported.");

        }

        private static string HostName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "windows-msvc";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return "macos-none";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "linux-gnu";

            return "unknown";
        }

        public static async Task DownloadFileAsync(string fileUrl, string destinationPath)
        {
            using var client = new HttpClient();

            try
            {
                // Get the stream from the URL
                using var stream = await client.GetStreamAsync(fileUrl);

                // Create a FileStream to write the data to the local file
                using var fstream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);

                // Copy the data from the download stream to the file stream asynchronously
                await stream.CopyToAsync(fstream);
                await fstream.FlushAsync();

                Console.WriteLine($"Downloaded file saved to: {destinationPath}");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error downloading file: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}
