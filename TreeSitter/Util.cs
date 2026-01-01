using System.Reflection;

namespace TreeSitter
{
    public static class Util
    {
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

        public static bool EnsureExec(string filename)
        {
            if (ExistsInPath(filename))
                return true;

            Console.Error.WriteLine($"Required executable '{filename}' was not found in PATH.");

            return false;
        }

        /// <summary>
        /// Return true if the file name can be found on path.
        /// </summary>
        public static bool ExistsInPath(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return false;

            var paths = (Environment.GetEnvironmentVariable("PATH") ?? "")
                .Split(Path.PathSeparator, StringSplitOptions.RemoveEmptyEntries);

            // Windows uses PATHEXT for executable extensions
            var extensions = OperatingSystem.IsWindows()
                ? (Environment.GetEnvironmentVariable("PATHEXT") ?? ".EXE;.CMD;.BAT")
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                : new[] { string.Empty };

            foreach (var dir in paths)
            {
                foreach (var ext in extensions)
                {
                    var fullPath = Path.Combine(dir, command + ext);
                    if (File.Exists(fullPath))
                        return true;
                }
            }

            return false;
        }

        public static string RemovePrefix(string str, string prefix)
        {
            if (str.StartsWith(prefix))
                return str.Substring(prefix.Length);

            return str;
        }
    }
}
