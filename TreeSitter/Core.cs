using System.Runtime.InteropServices;

namespace TreeSitter
{
    public static class TreeSitter
    {
        private const string URL = "https://github.com/jcs090218/csharp-tree-sitter/releases/download/";

        /// <summary>
        /// Prepare the prebuilt Tree-sitter binary.
        /// </summary>
        public static async Task<bool> EnsurePrebuilt(string version)
        {
            return await EnsurePrebuilt(version, Environment.ProcessPath);
        }
        public static async Task<bool> EnsurePrebuilt(string version, string? binPath)
        {
            if (binPath == null)
                return false;

            string url = PrebuiltUrl(version);

            await DownloadFileAsync(url, binPath);

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
                using var downloadStream = await client.GetStreamAsync(fileUrl);

                // Create a FileStream to write the data to the local file
                using var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);

                // Copy the data from the download stream to the file stream asynchronously
                await downloadStream.CopyToAsync(fileStream);
                await fileStream.FlushAsync();

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
