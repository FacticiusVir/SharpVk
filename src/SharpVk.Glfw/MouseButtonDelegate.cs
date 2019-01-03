namespace SharpVk.Glfw
{
    /// <summary>
    /// The function signature for keyboard key callback functions.
    /// </summary>
    /// <param name="window">
    /// The window that received the event.
    /// </param>
    /// <param name="button">
    /// Mouse button that issued the event
    /// </param>
    /// <param name="action">
    /// Action that comes from button
    /// </param>
    /// <param name="mods">
    /// Keyboard modifiers during that time
    /// </param>
    public delegate void MouseButtonDelegate(WindowHandle window, int button, InputAction action, Modifier mods);
}
