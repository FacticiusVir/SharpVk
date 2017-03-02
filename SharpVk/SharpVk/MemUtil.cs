using System;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SharpVk
{
    /// <summary>
    /// 
    /// </summary>
    public static class MemUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static uint SizeOf<T>()
        {
            return SizeOfCache<T>.SizeOf;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private static class SizeOfCache<T>
        {
            public static readonly uint SizeOf;

            static SizeOfCache()
            {
                SizeOf = (uint)Marshal.SizeOf(typeof(T));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dest"></param>
        /// <param name="value"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static void WriteToPtr<T>(IntPtr dest, T[] value, int startIndex, int count)
            where T : struct
        {
            if (count > 0)
            {
                int elementSize = (int)SizeOf<T>();
                int transferSize = elementSize * count;
                int startOffset = elementSize * startIndex;

                byte* pointer = (byte*)dest.ToPointer();
                pointer += startOffset;

                var handle = GCHandle.Alloc(value, GCHandleType.Pinned);

                byte* handlePointer = (byte*)handle.AddrOfPinnedObject().ToPointer();

                //HACK Replace with by-platform optimisations
                for (int index = 0; index < transferSize; index++)
                {
                    pointer[index] = handlePointer[index];
                }

                handle.Free();
            }
        }
    }
}
