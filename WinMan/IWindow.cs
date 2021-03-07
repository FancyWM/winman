using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

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
        event WindowUpdatedEventHandler GotFocus;

        /// <summary>
        /// The window lost focus.
        /// </summary>
        event WindowUpdatedEventHandler LostFocus;

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
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        string Title { get; }
        /// <summary>
        /// The client rectangle of the window, relative to the workarea.
        /// Returns Rectangle.Empty once the window is dead (IsAlive=false).
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        Rectangle Position { get; }
        /// <summary>
        /// The current state of the window.
        /// Returns WindowState.Minimized once the window is dead (IsAlive=false).
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        /// <exception cref="InvalidOperationException">If the window cannot be changed to that state due to other reasons.</exception>
        WindowState State { get; }
        /// <summary>
        /// The minimum allowed size for this window.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        Point? MinSize { get; }
        /// <summary>
        /// The maxmimum allowed size for this window.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        Point? MaxSize { get; }

        Rectangle FrameMargins { get; }

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
        /// True if the window can be reordered in the visual hierarchy.
        /// </summary>
        bool CanReorder { get; }
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
        /// True if the window can be closed by the current process.
        /// </summary>
        bool CanClose { get; }
        /// <summary>
        /// Whether a live thumbnail of this window can be created.
        /// </summary>
        bool CanCreateLiveThumbnail { get; }
        /// <summary>
        /// True if the window is always drawn above other non-topmost windows.
        /// Returns false once the window is dead (IsAlive=false).
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        bool IsTopmost { get; }
        /// <summary>
        /// Is this the foreground window.
        /// Returns false once the window is dead (IsAlive=false).
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        bool IsFocused { get; }
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
        /// Returns the process the window belongs to.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        Process Process { get; }

        /// <summary>
        /// Gets the previous window in the workspace. The previous window is the window above this one.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        IWindow PreviousWindow { get; }

        /// <summary>
        /// Gets the next window in the workspace. The previous window is the window below this one.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        IWindow NextWindow { get; }

        /// <summary>
        /// Sends a close event to the window.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void Close();

        /// <summary>
        /// Changes the location of the window.
        /// </summary>
        /// <param name="newLocation"></param>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void SetPosition(Rectangle newLocation);
        /// <summary>
        /// Changes the state of the window.
        /// </summary>
        /// <param name="state"></param>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void SetState(WindowState state);
        /// <summary>
        /// Changes the topmost property of the window.
        /// </summary>
        /// <param name="topmost"></param>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void SetTopmost(bool topmost);

        /// <summary>
        /// Moves the current window to be positioned after the given one in the z-order.
        /// </summary>
        /// <param name="other"></param>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void InsertAfter(IWindow other);

        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void SendToBack();

        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void BringToFront();

        /// <summary>
        /// Activates the window.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void RequestFocus();
    }
}
