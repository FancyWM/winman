using System;
using System.Collections.Generic;

namespace WinMan
{
    public interface IDisplayManager
    {
        event EventHandler<DisplayChangedEventArgs> Added;
        event EventHandler<DisplayChangedEventArgs> Removed;
        event EventHandler<DisplayRectangleChangedEventArgs> VirtualDisplayBoundsChanged;
        event EventHandler<PrimaryDisplayChangedEventArgs> PrimaryDisplayChanged;

        IWorkspace Workspace { get; }

        Rectangle VirtualDisplayBounds { get; }

        IDisplay PrimaryDisplay { get; }

        IReadOnlyList<IDisplay> Displays { get; }
    }
}