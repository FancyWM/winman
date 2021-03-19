using System;
using System.Collections.Generic;

namespace WinMan
{
    public interface IWorkspace : IDisposable
    {
        event EventHandler<WindowChangedEventArgs> WindowManaging;
        event EventHandler<WindowChangedEventArgs> WindowAdded;
        event EventHandler<WindowChangedEventArgs> WindowRemoved;
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
        /// Some workspace changes might require dirty checking to implement. 
        /// Use this to change the watch interval to a lower value for when a more
        /// real-time observation is necessary. The higher this value is, the less
        /// system resources will be used.
        /// 
        /// Alternatively, you may also call <see cref="RefreshConfiguration"/>, to manually do the same.
        /// </summary>
        TimeSpan WatchInterval { get; set; }

        /// <summary>
        /// Attaches system hooks and creates required data structures. 
        /// <see cref="WindowManaging"/> events will be emitted for windows currently
        /// present in the workspace before this call returns.
        /// </summary>
        void Open();

        /// <summary>
        /// Finds a top-level visible window by its native window handle.
        /// </summary>
        IWindow FindWindow(IntPtr windowHandle);

        /// <summary>
        /// Creates an <see cref="IWindow"/> instance for the corresponding handle.
        /// This instance may not compare equal to other <see cref="IWindow"/> references to the same OS window.
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
        /// Manually instructs the underlying implementation to dirty-check the current workspace.
        /// </summary>
        void RefreshConfiguration();
    }
}
