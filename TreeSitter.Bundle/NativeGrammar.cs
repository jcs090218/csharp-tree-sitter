using System.Runtime.InteropServices;

namespace TreeSitter.Bundle
{
    /// <summary>
    /// Dynamic load the dynamic link grammar files.
    /// </summary>
    public static class NativeGrammar
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr LanguageFn();

        public static IntPtr LoadRaw(string path, string symbol)
        {
            IntPtr lib = NativeLibrary.Load(path);

            var fn = Marshal.GetDelegateForFunctionPointer<LanguageFn>(
                NativeLibrary.GetExport(lib, symbol)
            );

            return fn(); // const TSLanguage*
        }

        public static TSLanguage Load(string path, string symbol)
        {
            return new TSLanguage(LoadRaw(path, symbol));
        }
    }
}
