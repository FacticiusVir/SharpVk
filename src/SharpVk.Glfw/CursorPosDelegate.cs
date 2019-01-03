namespace SharpVk.Glfw
{
    /// <summary>
    /// The function signature for keyboard key callback functions.
    /// </summary>
    /// <param name="window">
    /// The window that received the event.
    /// </param>
    /// <param name="xpos">
    /// The x position of the cursor
    /// </param>
    /// <param name="ypos">
    /// The y position of the cursor
    /// </param>
    public delegate void CursorPosDelegate(WindowHandle window, double xpos, double ypos);
}
