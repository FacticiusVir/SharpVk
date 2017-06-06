﻿using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace SharpVk.TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            var instance = Instance.Create(new InstanceCreateInfo
            {
            }, null);

            var physicalDevice = instance.EnumeratePhysicalDevices().First();

            var layers = Instance.EnumerateLayerProperties();

            var extensions = Instance.EnumerateExtensionProperties(null);

            uint hostVisibleMemory = physicalDevice.GetMemoryProperties().MemoryTypes.First(x => x.PropertyFlags.HasFlag(MemoryPropertyFlags.HostVisible)).HeapIndex;

            var device = physicalDevice.CreateDevice(new DeviceCreateInfo
            {
                QueueCreateInfos = new[]
                {
                    new DeviceQueueCreateInfo
                    {
                        QueueFamilyIndex = 0,
                        QueuePriorities = new float[]{ 0 }
                    }
                }
            });

            var sharedMemory = device.AllocateMemory(new MemoryAllocateInfo
            {
                MemoryTypeIndex = hostVisibleMemory,
                AllocationSize = 1 << 19
            });

            var inBuffer = device.CreateBuffer(new BufferCreateInfo
            {
                QueueFamilyIndices = new uint[] { 0 },
                SharingMode = SharingMode.Exclusive,
                Usage = BufferUsageFlags.TransferSource,
                Flags = BufferCreateFlags.None,
                Size = 1024
            });

            inBuffer.BindMemory(sharedMemory, 0);

            var outBuffer = device.CreateBuffer(new BufferCreateInfo
            {
                QueueFamilyIndices = new uint[] { 0 },
                SharingMode = SharingMode.Exclusive,
                Usage = BufferUsageFlags.TransferDestination,
                Flags = BufferCreateFlags.None,
                Size = 1024
            });

            outBuffer.BindMemory(sharedMemory, 2048);

            IntPtr inBufferPtr = sharedMemory.Map(0, 1024, MemoryMapFlags.None);

            Marshal.Copy(Enumerable.Range(0, 256).ToArray(), 0, inBufferPtr, 256);

            sharedMemory.Unmap();

            var commandPool = device.CreateCommandPool(new CommandPoolCreateInfo
            {
                Flags = CommandPoolCreateFlags.Transient,
                QueueFamilyIndex = 0
            });

            //var transferCommandBuffer = device.AllocateCommandBuffers(new CommandBufferAllocateInfo
            //{
            //    CommandBufferCount = 1,
            //    CommandPool = commandPool,
            //    Level = CommandBufferLevel.Primary
            //});

            commandPool.Destroy();

            outBuffer.Destroy();

            inBuffer.Destroy();

            sharedMemory.Free();

            device.Destroy();

            instance.Destroy();
        }
    }
}