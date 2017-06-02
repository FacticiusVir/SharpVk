// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2017
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

// This file was automatically generated and should not be edited directly.

using System;
using System.Runtime.InteropServices;

namespace SharpVk.Khx
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BindImageMemoryInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Image Image
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DeviceMemory Memory
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public DeviceSize MemoryOffset
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public uint[] DeviceIndices
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Rect2D[] SFRRects
        {
            get;
            set;
        }
        
        internal unsafe void MarshalTo(Interop.Khx.BindImageMemoryInfo* pointer)
        {
            pointer->SType = StructureType.BindImageMemoryInfoKhx;
            pointer->Next = null;
            pointer->Image = this.Image.handle;
            pointer->Memory = this.Memory.handle;
            pointer->MemoryOffset = this.MemoryOffset;
            pointer->DeviceIndexCount = (uint)(this.DeviceIndices?.Length ?? 0);
            if (this.DeviceIndices != null)
            {
                var fieldPointer = (uint*)(Interop.HeapUtil.AllocateAndClear<uint>(this.DeviceIndices.Length).ToPointer());
                for(int index = 0; index < (uint)(this.DeviceIndices.Length); index++)
                {
                    fieldPointer[index] = this.DeviceIndices[index];
                }
                pointer->DeviceIndices = fieldPointer;
            }
            else
            {
                pointer->DeviceIndices = null;
            }
            pointer->SFRRectCount = (uint)(this.SFRRects?.Length ?? 0);
            if (this.SFRRects != null)
            {
                var fieldPointer = (Rect2D*)(Interop.HeapUtil.AllocateAndClear<Rect2D>(this.SFRRects.Length).ToPointer());
                for(int index = 0; index < (uint)(this.SFRRects.Length); index++)
                {
                    fieldPointer[index] = this.SFRRects[index];
                }
                pointer->SFRRects = fieldPointer;
            }
            else
            {
                pointer->SFRRects = null;
            }
        }
    }
}
