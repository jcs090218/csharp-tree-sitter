using System.Runtime.InteropServices;

namespace TreeSitter
{
    public static class Native
    {
        /// <summary>
        /// Return the native dynamic link library.
        /// </summary>
        /// <exception cref="PlatformNotSupportedException"></exception>
        public static string DLibName(string baseName)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return $"{baseName}.dll";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                return $"lib{baseName}.dylib";

            // Linux and most Unix-like systems
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                return $"lib{baseName}.so";

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
    }
}
