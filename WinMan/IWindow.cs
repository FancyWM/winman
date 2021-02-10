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
    public delegate void WindowPositionChangedEventHandler(IWindow sender, Rectangle prevPosition);
    public delegate void WindowStateChangedEventHandler(IWindow sender, WindowState prevState);

    public interface IWindow : IEquatable<IWindow>
    {
        /// <summary>
        /// Event emitted when the window location starts changing as a result of 
        /// user interaction (resize or move).
        /// </summary>
        event WindowPositionChangedEventHandler PositionChangeStart;

        /// <summary>
        /// Event emitted when the user interaction driving the resize or move of 
        /// the window ends.
        /// </summary>
        event WindowPositionChangedEventHandler PositionChangeEnd;
        
        /// <summary>
        /// The location of the window has changed. This might be due to a user interaction
        /// or through some form of scripted behaviour. 
        /// </summary>
        event WindowPositionChangedEventHandler PositionChanged;

        /// <summary>
        /// The state of the window has changed.
        /// </summary>
        event WindowStateChangedEventHandler StateChanged;

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
        /// IsAlive is likely to be false.
        /// </summary>
        event WindowUpdatedEventHandler Removed;

        /// <summary>
        /// The window instance was destroyed.
        /// IsAlive will be false.
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
        /// Returns string.Empty once the window is dead (IsAlive=false).
        /// </summary>
        string Title { get; }
        /// <summary>
        /// The client rectangle of the window, relative to the workarea.
        /// Returns Rectangle.Empty once the window is dead (IsAlive=false).
        /// </summary>
        Rectangle Position { get; }
        /// <summary>
        /// The current state of the window.
        /// Returns WindowState.Minimized once the window is dead (IsAlive=false).
        /// </summary>
        WindowState State { get; }
        /// <summary>
        /// The minimum allowed size for this window.
        /// </summary>
        Point MinSize { get; }
        /// <summary>
        /// The maxmimum allowed size for this window.
        /// </summary>
        Point MaxSize { get; }
        /// <summary>
        /// True if the window is resizable.
        /// Returns false once the window is dead (IsAlive=false).
        /// </summary>
        bool CanResize { get; }
        /// <summary>
        /// True if the window can be moved.
        /// Returns false once the window is dead (IsAlive=false).
        /// </summary>
        bool CanMove { get; }
        /// <summary>
        /// True if the window supports minimization.
        /// Returns false once the window is dead (IsAlive=false).
        /// </summary>
        bool CanMinimize { get; }
        /// <summary>
        /// True if the window supports maximization.
        /// Returns false once the window is dead (IsAlive=false).
        /// </summary>
        bool CanMaximize { get; }
        /// <summary>
        /// Whether a live thumbnail of this window can be created.
        /// </summary>
        bool CanCreateLiveThumbnail { get; }
        /// <summary>
        /// True if the window is always drawn above other non-topmost windows.
        /// Returns false once the window is dead (IsAlive=false).
        /// </summary>
        bool IsTopmost { get; }
        /// <summary>
        /// Is this the foreground window.
        /// Returns false once the window is dead (IsAlive=false).
        /// </summary>
        bool HasFocus { get; }
        /// <summary>
        /// Is the window instance alive.
        /// </summary>
        bool IsAlive { get; }
        /// <summary>
        /// The OS-specific window handle.
        /// Returns IntPtr.Zero once the window is dead (IsAlive=false).
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
        void SetPosition(Rectangle newLocation);
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
        void RequestFocus();
    }
}
