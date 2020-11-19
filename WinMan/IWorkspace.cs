using System;
using System.Collections.Generic;

namespace WinMan
{
    public interface IWorkspace : IDisposable
    {
        event Action<int> CurrentDesktopChanged;
        event Action<IWindow> WindowManaging;
        event Action<IWindow> WindowAdded;
        event Action<IWindow> WindowRemoved;
        event Action<Exception> UnhandledException;

        IEnumerable<IWindow> GetSnapshot();
        IEnumerable<IWindow> GetSnapshot(int desktop);

        void Open();

        int DesktopCount { get; }
        int DesktopRows { get; }

        Point GetDimensions();
        IWindow ActiveWindow { get; }
        int CurrentDesktop { get; }

        void SwitchToDesktop(int desktop);
    }
}
