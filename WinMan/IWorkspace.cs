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

        Point CursorLocation { get; }

        IWindow FocusedWindow { get; }

        IDisplayManager DisplayManager { get; }

        IVirtualDesktopManager VirtualDesktopManager { get; }

        void Open();

        IWindow FindWindow(IntPtr windowHandle);

        IWindow UnsafeCreateFromHandle(IntPtr windowHandle);

        IReadOnlyList<IWindow> GetSnapshot();

        IComparer<IWindow> CreateSnapshotZOrderComparer();

        /// <param name="destWindow"></param>
        /// <param name="srcWindow"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        ILiveThumbnail CreateLiveThumbnail(IWindow destWindow, IWindow srcWindow);

        void RefreshConfiguration();
    }
}
