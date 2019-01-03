namespace SharpVk.Glfw
{
    /// <summary>
    /// The function signature for keyboard key callback functions.
    /// </summary>
    /// <param name="window">
    /// The window that received the event.
    /// </param>
    /// <param name="xoffset">
    /// Scroll x amount
    /// </param>
    /// <param name="yoffset">
    /// Scroll y amount
    /// </param>
    public delegate void ScrollDelegate(WindowHandle window, double xoffset, double yoffset);
}
