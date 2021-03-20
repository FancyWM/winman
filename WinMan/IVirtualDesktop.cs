using System;

namespace WinMan
{
    /// <summary>
    /// Represents a virtual desktop.
    /// </summary>
    public interface IVirtualDesktop
    {
        /// <summary>
        /// Raised once the desktops has been removed from the workspace.
        /// </summary>
        event EventHandler<DesktopChangedEventArgs> Removed;

        IWorkspace Workspace { get; }

        /// <summary>
        /// Is this the current virtual desktop.
        /// </summary>
        bool IsCurrent { get; }

        /// <summary>
        /// The numerical index of this desktop in the list of all desktops.
        /// </summary>
        int Index { get; }

        /// <summary>
        /// The name of this desktop.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Moves a window to this desktop.
        /// </summary>
        /// <param name="window"></param>
        /// <exception cref="ExternalException"></exception>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="InvalidVirtualDesktopReferenceException"></exception>
        void MoveWindow(IWindow window);

        /// <summary>
        /// Checks if the desktop contains this window.
        /// </summary>
        /// <exception cref="ExternalException"></exception>
        /// <exception cref="InvalidWindowReferenceException"></exception>
        /// <exception cref="InvalidVirtualDesktopReferenceException"></exception>
        bool HasWindow(IWindow window);

        /// <summary>
        /// Switches to this virtual desktop.
        /// </summary>
        /// <exception cref="ExternalException"></exception>
        /// <exception cref="InvalidVirtualDesktopReferenceException"></exception>
        void SwitchTo();

        /// <summary>
        /// Sets the name of this virtual desktop.
        /// </summary>
        /// <exception cref="ExternalException"></exception>
        /// <exception cref="InvalidVirtualDesktopReferenceException"></exception>
        void SetName(string newName);

        /// <summary>
        /// Removes this virtual desktop.
        /// </summary>
        /// <exception cref="ExternalException"></exception>
        /// <exception cref="InvalidVirtualDesktopReferenceException"></exception>
        void Remove();
    }
}
