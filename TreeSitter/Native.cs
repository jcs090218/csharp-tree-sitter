using System.Formats.Tar;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace TreeSitter
{
    public static class Native
    {
        /// <summary>
        /// Return the native dynamic link library.
        /// </summary>
        public static string DLibName(string name)
        {
            string prefix = DLibPrefix();
            string ext = DLibExt();

            return $"{prefix}{name}.{ext}";
        }

        /// <summary>
        /// Return the dynamic link library's prefix 
        /// based on the current OS.
        /// </summary>
        public static string DLibPrefix()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return $"";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return $"lib";

            // Linux and most Unix-like systems
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return $"lib";

            throw new PlatformNotSupportedException();
        }

        /// <summary>
        /// Return the dynamic link library's extension 
        /// based on the current OS.
        /// </summary>
        public static string DLibExt()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return $"dll";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return $"dylib";

            // Linux and most Unix-like systems
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return $"so";

            throw new PlatformNotSupportedException();
        }

        /// <summary>
        /// Return the archive extension.
        /// </summary>
        public static string ArchiveExt()
        {
            return (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                ? "zip"
                : "tar";
        }

        /// <summary>
        /// Unarchive the file.
        /// </summary>
        public static bool UnArchive(string path, string dest)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return UnzipFile(path, dest);

            return ExtractTarFile(path, dest);
        }

        private static bool UnzipFile(string path, string dest)
        {
            if (!Directory.Exists(dest))
                Directory.CreateDirectory(dest);

            try
            {
                ZipFile.ExtractToDirectory(path, dest, overwriteFiles: true);

                return true;
            }
            catch (IOException)
            {
                // ..
            }

            return false;
        }

        private static bool ExtractTarFile(string path, string dest)
        {
            if (!Directory.Exists(dest))
                Directory.CreateDirectory(dest);

            TarFile.ExtractToDirectory(path, dest, overwriteFiles: true);

            return true;
        }

        /// <summary>
        /// Return the architecture name.
        /// </summary>
        public static string ArchName()
        {
            Architecture arch = RuntimeInformation.OSArchitecture;

            switch (arch)
            {
                case Architecture.X86:
                case Architecture.X64:
                    return "x86_64";

                case Architecture.Arm:
                case Architecture.Arm64:
                    return "aarch64";
            }

            throw new NotSupportedException($"Architecture '{arch}' is not supported.");
        }

        /// <summary>
        /// Return the build host name.
        /// </summary>
        public static string HostName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return "windows-msvc";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return "macos-none";
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return "linux-gnu";

            return "unknown";
        }
    }
}
