using System.Collections.Generic;

namespace WinMan
{
    public delegate void DisplayChangedHandler(IDisplay display);
    public delegate void VirtualDisplayBoundsChangedHandler(Rectangle oldBounds);
    public delegate void PrimaryDisplayChangedHandler(IDisplay oldDisplay);

    public interface IDisplayManager
    {
        event DisplayChangedHandler Added;
        event DisplayChangedHandler Removed;
        event VirtualDisplayBoundsChangedHandler VirtualDisplayBoundsChanged;
        event PrimaryDisplayChangedHandler PrimaryDisplayChanged;

        IWorkspace Workspace { get; }

        Rectangle VirtualDisplayBounds { get; }

        IDisplay PrimaryDisplay { get; }

        IReadOnlyList<IDisplay> Displays { get; }
    }
}