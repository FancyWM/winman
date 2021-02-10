using System;
using System.Collections.Generic;

namespace WinMan
{
    public delegate void VirtualDesktopChangedEventHandler(IVirtualDesktop oldVirtualDesktop);

    public delegate void WindowPresenceChangedEventHandler(IWindow sender);

    public delegate void ActiveChangedEventHandler(IWindow oldActiveWindow);

    public delegate void UnhandledExceptionEventHandler(Exception exception);

    public interface IWorkspace : IDisposable
    {
        event WindowPresenceChangedEventHandler WindowManaging;
        event WindowPresenceChangedEventHandler WindowAdded;
        event WindowPresenceChangedEventHandler WindowRemoved;
        event UnhandledExceptionEventHandler UnhandledException;

        Rectangle WorkArea { get; }

        Point CursorLocation { get; }

        IWindow FocusedWindow { get; }

        IVirtualDesktopManager VirtualDesktopManager { get; }

        void Open();

        IWindow FindWindow(IntPtr windowHandle);

        IWindow UnsafeCreateFromHandle(IntPtr windowHandle);

        IReadOnlyList<IWindow> GetSnapshot();

        IEnumerable<IWindow> OrderByZOrder(IReadOnlyList<IWindow> windows);

        /// <param name="destWindow"></param>
        /// <param name="srcWindow"></param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException"></exception>
        ILiveThumbnail CreateLiveThumbnail(IWindow destWindow, IWindow srcWindow);
    }
}
