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

namespace SharpVk
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PipelineMultisampleStateCreateInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public PipelineMultisampleStateCreateFlags Flags
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SampleCountFlags RasterizationSamples
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Bool32 SampleShadingEnable
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public float MinSampleShading
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public SampleMask[] SampleMask
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Bool32 AlphaToCoverageEnable
        {
            get;
            set;
        }
        
        /// <summary>
        /// 
        /// </summary>
        public Bool32 AlphaToOneEnable
        {
            get;
            set;
        }
        
        internal unsafe void MarshalTo(Interop.PipelineMultisampleStateCreateInfo* pointer)
        {
            pointer->SType = StructureType.PipelineMultisampleStateCreateInfo;
            pointer->Next = null;
            pointer->Flags = this.Flags;
            pointer->RasterizationSamples = this.RasterizationSamples;
            pointer->SampleShadingEnable = this.SampleShadingEnable;
            pointer->MinSampleShading = this.MinSampleShading;
            if (this.SampleMask != null)
            {
                var fieldPointer = (SampleMask*)(Interop.HeapUtil.AllocateAndClear<SampleMask>(this.SampleMask.Length).ToPointer());
                for(int index = 0; index < (uint)(this.SampleMask.Length); index++)
                {
                    fieldPointer[index] = this.SampleMask[index];
                }
                pointer->SampleMask = fieldPointer;
            }
            else
            {
                pointer->SampleMask = null;
            }
            pointer->AlphaToCoverageEnable = this.AlphaToCoverageEnable;
            pointer->AlphaToOneEnable = this.AlphaToOneEnable;
        }
    }
}
