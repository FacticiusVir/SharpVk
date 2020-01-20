// The MIT License (MIT)
// 
// Copyright (c) Andrew Armstrong/FacticiusVir 2020
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

namespace SharpVk
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct TimelineSemaphoreSubmitInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public ulong[] WaitSemaphoreValues
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public ulong[] SignalSemaphoreValues
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        internal unsafe void MarshalTo(SharpVk.Interop.TimelineSemaphoreSubmitInfo* pointer)
        {
            pointer->Next = null;
            pointer->WaitSemaphoreValueCount = (uint)(Interop.HeapUtil.GetLength(this.WaitSemaphoreValues));
            if (this.WaitSemaphoreValues != null)
            {
                var fieldPointer = (ulong*)(Interop.HeapUtil.AllocateAndClear<ulong>(this.WaitSemaphoreValues.Length).ToPointer());
                for(int index = 0; index < (uint)(this.WaitSemaphoreValues.Length); index++)
                {
                    fieldPointer[index] = this.WaitSemaphoreValues[index];
                }
                pointer->WaitSemaphoreValues = fieldPointer;
            }
            else
            {
                pointer->WaitSemaphoreValues = null;
            }
            pointer->SignalSemaphoreValueCount = (uint)(Interop.HeapUtil.GetLength(this.SignalSemaphoreValues));
            if (this.SignalSemaphoreValues != null)
            {
                var fieldPointer = (ulong*)(Interop.HeapUtil.AllocateAndClear<ulong>(this.SignalSemaphoreValues.Length).ToPointer());
                for(int index = 0; index < (uint)(this.SignalSemaphoreValues.Length); index++)
                {
                    fieldPointer[index] = this.SignalSemaphoreValues[index];
                }
                pointer->SignalSemaphoreValues = fieldPointer;
            }
            else
            {
                pointer->SignalSemaphoreValues = null;
            }
        }
    }
}
