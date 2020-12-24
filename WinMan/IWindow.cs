using System;

namespace WinMan
{
    public enum WindowState
    {
        Minimized,
        Restored,
        Maximized,
    }

    public delegate void WindowUpdatedEventHandler(IWindow sender);
    public delegate void LocationChangedEventHandler(IWindow sender, Rectangle oldLocation);
    public delegate void StateChangedEventHandler(IWindow sender, WindowState oldState);

    public interface IWindow : IEquatable<IWindow>
    {
        /// <summary>
        /// Event emitted when the window location starts changing as a result of 
        /// user interaction (resize or move).
        /// </summary>
        event LocationChangedEventHandler LocationChangeStart;

        /// <summary>
        /// Event emitted when the user interaction driving the resize or move of 
        /// the window ends.
        /// </summary>
        event LocationChangedEventHandler LocationChangeEnd;
        
        /// <summary>
        /// The location of the window has changed. This might be due to a user interaction
        /// or through some form of scripted behaviour. 
        /// </summary>
        event LocationChangedEventHandler LocationChanged;

        /// <summary>
        /// The state of the window has changed.
        /// </summary>
        event StateChangedEventHandler StateChanged;

        /// <summary>
        /// The IsTopmost property of the window has changed.
        /// </summary>
        event WindowUpdatedEventHandler TopmostChanged;

        /// <summary>
        /// The window became the foreground window.
        /// </summary>
        event WindowUpdatedEventHandler Activated;

        /// <summary>
        /// The window was added to the workspace.
        /// </summary>
        event WindowUpdatedEventHandler Added;

        /// <summary>
        /// The window was removed from the workspace.
        /// </summary>
        event WindowUpdatedEventHandler Removed;

        /// <summary>
        /// The window instance was destroyed.
        /// </summary>
        event WindowUpdatedEventHandler Destroyed;

        /// <summary>
        /// The internal synchronisation object.
        /// </summary>
        object SyncRoot { get; }

        /// <summary>
        /// The IWorkspace which returned this IWindow instance.
        /// </summary>
        IWorkspace Workspace { get; }
        /// <summary>
        /// The title of the window.
        /// </summary>
        string Title { get; }
        /// <summary>
        /// The client rectangle of the window, relative to the workarea.
        /// </summary>
        Rectangle Location { get; }
        /// <summary>
        /// The current state of the window.
        /// </summary>
        WindowState State { get; }
        /// <summary>
        /// True if the window is always drawn above other non-topmost windows.
        /// </summary>
        bool IsTopmost { get; }
        /// <summary>
        /// True if this instance is a valid reference to an OS window.
        /// </summary>
        bool IsValid { get; }
        /// <summary>
        /// The OS-specific window handle.
        /// </summary>
        IntPtr Handle { get; }

        /// <summary>
        /// Sends a close event to the window.
        /// </summary>
        void Close();
        
        /// <summary>
        /// Changes the location of the window.
        /// </summary>
        /// <param name="newLocation"></param>
        void SetLocation(Rectangle newLocation);
        /// <summary>
        /// Changes the state of the window.
        /// </summary>
        /// <param name="state"></param>
        void SetState(WindowState state);
        /// <summary>
        /// Changes the topmost property of the window.
        /// </summary>
        /// <param name="topmost"></param>
        void SetTopmost(bool topmost);

        /// <summary>
        /// Activates the window.
        /// </summary>
        void Focus();

        /// <summary>
        /// Returns the 0-based index of the monitor to which
        /// the window is assigned.
        /// </summary>
        int Monitor { get; }
    }
}
