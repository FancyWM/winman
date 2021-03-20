using System;
using System.Collections.Generic;

namespace WinMan
{
    public interface IWorkspace : IDisposable
    {
        /// <summary>
        /// The window was initially present when <see cref="Open"/> was first called.
        /// </summary>
        event EventHandler<WindowChangedEventArgs> WindowManaging;
        /// <summary>
        /// The window was just added to the workspace.
        /// </summary>
        event EventHandler<WindowChangedEventArgs> WindowAdded;
        /// <summary>
        /// The window was just removed to the workspace.
        /// </summary>
        event EventHandler<WindowChangedEventArgs> WindowRemoved;
        /// <summary>
        /// An exception raised during event handling or in the OS-specific workspace implementation was 
        /// thrown and uncaught.
        /// </summary>
        event UnhandledExceptionEventHandler UnhandledException;

        /// <summary>
        /// Has <see cref="Open"/> been called.
        /// </summary>
        bool IsOpen { get; }

        /// <summary>
        /// Returns the current cursor location.
        /// </summary>
        Point CursorLocation { get; }

        /// <summary>
        /// A reference to the currently focused window or null, if no top-level visible window is focused.
        /// </summary>
        IWindow FocusedWindow { get; }

        /// <summary>
        /// The <see cref="IDisplayManager"/> instance.
        /// </summary>
        IDisplayManager DisplayManager { get; }

        /// <summary>
        /// The <see cref="IVirtualDesktopManager"/> instance.
        /// </summary>
        IVirtualDesktopManager VirtualDesktopManager { get; }

        /// <summary>
        /// Some workspace implementations might require dirty checking to detect changes. 
        /// The higher this value is, the less system resources will be used.
        /// 
        /// Alternatively, you may also call <see cref="RefreshConfiguration"/>, to run a change-detection cycle manually.
        /// </summary>
        TimeSpan WatchInterval { get; set; }

        /// <summary>
        /// Attaches system hooks and creates required data structures. 
        /// <see cref="WindowManaging"/> events will be emitted for windows currently
        /// present in the workspace before this call returns.
        /// </summary>
        void Open();

        /// <summary>
        /// Finds a window by its native window handle.
        /// </summary>
        IWindow FindWindow(IntPtr windowHandle);

        /// <summary>
        /// Creates an <see cref="IWindow"/> instance for the corresponding handle.
        /// This instance may not compare equal to other <see cref="IWindow"/> references to the same OS window.
        /// Use this only for throaway instances where you need to read a certain property of the window.
        /// Events will not be raised on this instance, as it is not tied to the workspace backend.
        /// </summary>
        IWindow UnsafeCreateFromHandle(IntPtr windowHandle);

        /// <summary>
        /// Returns a snapshot of the windows in the current workspace.
        /// </summary>
        IReadOnlyList<IWindow> GetSnapshot();

        /// <summary>
        /// Creates a comparer that uses a snapshot of the current workspace to compare windows.
        /// </summary>
        IComparer<IWindow> CreateSnapshotZOrderComparer();

        /// <summary>
        /// Manually instructs the underlying implementation to run an change-detection cycle on the workspace.
        /// </summary>
        void RefreshConfiguration();
    }
}
