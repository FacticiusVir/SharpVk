using SharpVk.Glfw;
using System;
using System.Linq;

namespace SharpVk
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new Program().Run();
        }

        private static void SetCallbacks(Window window)
        {
            Glfw3.SetCharCallback(window.Handle, new CharDelegate((handle, codepoint) => 
                Console.WriteLine("CharDelegate called (codepoint: " + codepoint + ")")));
            Glfw3.SetScrollCallback(window.Handle, new ScrollDelegate((handle, xoffset, yoffset) => 
                Console.WriteLine("ScrollDelegate called (xoffset: " + xoffset + ", yoffset: " + yoffset + ")")));
            Glfw3.SetCursorPosCallback(window.Handle, new CursorPosDelegate((handle, xpos, ypos) => 
                Console.WriteLine("CursorPosDelegate called (xpos: " + xpos + ", ypos: " + ypos + ")")));
            Glfw3.SetMouseButtonPosCallback(window.Handle, new MouseButtonDelegate((handle, button, action, mods ) => 
                Console.WriteLine("MouseButtonDelegate called (button: " + button + ", action: " + 
                Enum.GetName(typeof(InputAction), action) + ", mods: " + Enum.GetName(typeof(Modifier), mods) + ")")));  
        }
        private unsafe void Run()
        {
            var extensions = Instance.EnumerateExtensionProperties(null);

            var instance = Instance.Create(null, Glfw3.GetRequiredInstanceExtensions());

            var device = instance.EnumeratePhysicalDevices().First().CreateDevice(new DeviceQueueCreateInfo { QueueFamilyIndex = 0, QueuePriorities = new[] { 0f } }, null, null);

            device.GetQueue(0, 0);

            try
            {
                Glfw3.Init();

                using (var window = new Window(1920, 1080, "Test"))
                {
                    SetCallbacks(window);

                    while (!window.ShouldClose)
                    {
                        Glfw3.PollEvents();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                Glfw3.Terminate();
            }
        }
    }
}
