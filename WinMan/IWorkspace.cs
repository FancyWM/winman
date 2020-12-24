using System;
using System.Collections.Generic;

namespace WinMan
{
    public delegate void VirtualDesktopChangedEventHandler(IVirtualDesktop oldVirtualDesktop);

    public delegate void PresenceChangedEventHandler(IWindow sender);

    public delegate void ActiveChangedEventHandler(IWindow oldActiveWindow);

    public delegate void UnhandledExceptionEventHandler(Exception exception);

    public interface IWorkspace : IDisposable
    {
        event PresenceChangedEventHandler WindowManaging;
        event PresenceChangedEventHandler WindowAdded;
        event PresenceChangedEventHandler WindowRemoved;
        event UnhandledExceptionEventHandler UnhandledException;

        IReadOnlyList<IWindow> GetSnapshot(bool currentDesktopOnly = false);

        IEnumerable<IWindow> OrderByZOrder(IReadOnlyList<IWindow> windows);

        void Open();

        Rectangle WorkArea { get; }

        IWindow ActiveWindow { get; }

        IVirtualDesktopManager VirtualDesktops { get; }
    }
}
