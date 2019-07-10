using System;
using System.Runtime.InteropServices;

namespace SharpVk.Interop
{
    /// <summary>
    /// 
    /// </summary>
    public class NativeLibrary
        : IProcLookup
    {
        private readonly IntPtr library;

        private static class Kernel32
        {
            [DllImport("kernel32")]
            public static extern IntPtr LoadLibrary(string fileName);

            [DllImport("kernel32")]
            public static extern IntPtr GetProcAddress(IntPtr module, string procName);
        }

        private static class LibDl
        {
            [DllImport("libdl.so")]
            public static extern IntPtr dlopen(string fileName, int flags);

            [DllImport("libdl.so")]
            public static extern IntPtr dlsym(IntPtr handle, string name);

            public const int RtldNow = 2;
        }

        private static class LibDlOSX
        {
            [DllImport("libdl.dylib")]
            public static extern IntPtr dlopen(string fileName, int flags);

            [DllImport("libdl.dylib")]
            public static extern IntPtr dlsym(IntPtr handle, string name);

            public const int RtldNow = 2;
        }

        /// <summary>
        /// 
        /// </summary>
        public NativeLibrary()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                this.library = Kernel32.LoadLibrary("vulkan-1.dll");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                this.library = LibDl.dlopen("libvulkan.so.1", LibDl.RtldNow);

                if(this.library == IntPtr.Zero)
                {
                    this.library = LibDl.dlopen("libvulkan.so", LibDl.RtldNow);
                }
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                this.library = LibDlOSX.dlopen("libvulkan.dylib.1", LibDlOSX.RtldNow);

                if(this.library == IntPtr.Zero)
                {
                    this.library = LibDlOSX.dlopen("libvulkan.dylib", LibDlOSX.RtldNow);
                }
            }
            else
            {
                throw new NotSupportedException($"{RuntimeInformation.OSDescription} is not a supported platform for SharpVK.");
            }
        }

        /// <summary>
        /// Gets a function pointer for the specificed Vulkan command.
        /// </summary>
        /// <param name="name">
        /// The name of the command.
        /// </param>
        /// <returns>
        /// A function pointer to the native procedure call.
        /// </returns>
        public IntPtr GetProcedureAddress(string name)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Kernel32.GetProcAddress(this.library, name);

            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return LibDl.dlsym(this.library, name);

            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return LibDlOSX.dlsym(this.library, name);

            }
            else
            {
                throw new NotSupportedException($"{RuntimeInformation.OSDescription} is not a supported platform for SharpVK.");
            }
        }
    }
}
