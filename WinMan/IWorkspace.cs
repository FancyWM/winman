using System;
using System.Collections.Generic;

namespace WinMan
{
    public delegate void VirtualDesktopAddedEventHandler(IVirtualDesktop virtualDesktop);

    public delegate void VirtualDesktopRemovedEventHandler(IVirtualDesktop virtualDesktop);

    public delegate void VirtualDesktopChangedEventHandler(IVirtualDesktop virtualDesktop, IVirtualDesktop oldVirtualDesktop);

    public delegate void WindowPresenceChangedEventHandler(IWindow sender);

    public delegate void ActiveChangedEventHandler(IWindow oldActiveWindow);

    public delegate void UnhandledExceptionEventHandler(Exception exception);

    public interface IWorkspace : IDisposable
    {
        event WindowPresenceChangedEventHandler WindowManaging;
        event WindowPresenceChangedEventHandler WindowAdded;
        event WindowPresenceChangedEventHandler WindowRemoved;
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
