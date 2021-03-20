using System;
using System.Collections.Generic;

namespace WinMan
{
    /// <summary>
    /// Allows enumeration of the virtual desktops in this workspace.
    /// </summary>
    public interface IVirtualDesktopManager
    {
        IWorkspace Workspace { get; }

        /// <summary>
        /// True if the environment can be manipulated with this instance.
        /// </summary>
        bool CanManageVirtualDesktops { get; }
        
        /// <summary>
        /// Raised when a new desktop has been added to the workspace.
        /// </summary>
        event EventHandler<DesktopChangedEventArgs> DesktopAdded;
        /// <summary>
        /// Raised when a desktop has been removed from the workspace.
        /// </summary>
        event EventHandler<DesktopChangedEventArgs> DesktopRemoved;
        /// <summary>
        /// Raised when the current desktop is changed.
        /// </summary>
        event EventHandler<CurrentDesktopChangedEventArgs> CurrentDesktopChanged;

        /// <summary>
        /// Returns a snapshot of the current virtual desktops in the workspace.
        /// </summary>
        IReadOnlyList<IVirtualDesktop> Desktops { get; }

        /// <summary>
        /// The current virtual desktop.
        /// </summary>
        IVirtualDesktop CurrentDesktop { get; }

        /// <summary>
        /// Creates a new virtual desktop and returns a reference to it.
        /// </summary>
        /// <exception cref="ExternalException"></exception>
        IVirtualDesktop CreateDesktop();

        /// <summary>
        /// Pins a window across all virtual desktops.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void PinWindow(IWindow window);

        /// <summary>
        /// Unpins a previously pinned window.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        void UnpinWindow(IWindow window);

        /// <summary>
        /// Checks if a window has previously been pinned.
        /// </summary>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="ExternalException"></exception>
        bool IsWindowPinned(IWindow window);
    }
}
