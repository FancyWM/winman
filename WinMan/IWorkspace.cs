using System;
using System.Collections.Generic;

namespace WinMan
{
    public delegate void VirtualDesktopChangedEventHandler(IVirtualDesktop oldVirtualDesktop);

    public delegate void PresenceChangedEventHandler(IWindow sender);

    public delegate void UnhandledExceptionEventHandler(Exception exception);

    public interface IWorkspace : IDisposable
    {
        event VirtualDesktopChangedEventHandler VirtualDesktopChanged;
        event PresenceChangedEventHandler WindowManaging;
        event PresenceChangedEventHandler WindowAdded;
        event PresenceChangedEventHandler WindowRemoved;
        event UnhandledExceptionEventHandler UnhandledException;

        IReadOnlyList<IWindow> GetSnapshot();

        void Open();

        Rectangle WorkArea { get; }

        IWindow ActiveWindow { get; }

        IVirtualDesktop ActiveDesktop { get; }
    }
}
