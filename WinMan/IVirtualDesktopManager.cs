using System;
using System.Collections.Generic;

namespace WinMan
{
    public interface IVirtualDesktopManager
    {
        IWorkspace Workspace { get; }

        bool CanManageVirtualDesktops { get; }

        event EventHandler<DesktopChangedEventArgs> DesktopAdded;
        event EventHandler<DesktopChangedEventArgs> DesktopRemoved;
        event EventHandler<CurrentDesktopChangedEventArgs> CurrentDesktopChanged;

        IReadOnlyList<IVirtualDesktop> Desktops { get; }

        IVirtualDesktop CurrentDesktop { get; }

        IVirtualDesktop CreateDesktop();

        void PinWindow(IWindow window);

        void UnpinWindow(IWindow window);

        bool IsWindowPinned(IWindow window);
    }
}
