using System.Collections.Generic;

namespace WinMan
{
    public delegate void DisplayChangedHandler(IDisplay display);

    public interface IDisplayManager
    {
        event DisplayChangedHandler Added;
        event DisplayChangedHandler Removed;

        IWorkspace Workspace { get; }

        Rectangle VirtualDisplayBounds { get; }

        IDisplay PrimaryDisplay { get; }

        IReadOnlyList<IDisplay> Displays { get; }
    }
}