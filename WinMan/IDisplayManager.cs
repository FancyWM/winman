using System;
using System.Collections.Generic;

namespace WinMan
{
    /// <summary>
    /// Allows enumeration the displays attached to the system.
    /// </summary>
    public interface IDisplayManager
    {
        /// <summary>
        /// A new display had been added.
        /// </summary>
        event EventHandler<DisplayChangedEventArgs> Added;
        /// <summary>
        /// A display has been removed.
        /// </summary>
        event EventHandler<DisplayChangedEventArgs> Removed;
        /// <summary>
        /// The bounds of the virtual display have changed.
        /// </summary>
        event EventHandler<DisplayRectangleChangedEventArgs> VirtualDisplayBoundsChanged;
        /// <summary>
        /// The primary display has been changed.
        /// </summary>
        event EventHandler<PrimaryDisplayChangedEventArgs> PrimaryDisplayChanged;

        IWorkspace Workspace { get; }

        /// <summary>
        /// The bounds of the virtual display;
        /// </summary>
        Rectangle VirtualDisplayBounds { get; }

        /// <summary>
        /// The current primary display.
        /// </summary>
        IDisplay PrimaryDisplay { get; }

        /// <summary>
        /// A snapshot list of all the attached displays;
        /// </summary>
        IReadOnlyList<IDisplay> Displays { get; }
    }
}