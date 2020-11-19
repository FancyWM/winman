using System;

namespace WinMan
{
    public interface IWindow
    {
        event Action<IWindow> Moving;
        event Action<IWindow> Moved;

        event Action<IWindow> Minimizing;
        event Action<IWindow> Minimized;

        event Action<IWindow> Restored;
        event Action<IWindow, bool, bool> Maximized;
        event Action<IWindow> Activated;
        event Action<IWindow> FullScreenEntered;
        event Action<IWindow> FullScreenExited;

        event Action<IWindow> Removed;

        string Title { get; set; }
        Point Position { get; }
        Point Size { get; }

        void Close();
        void Move(int x, int y);
        void Resize(int w, int h);
        void SetGeometry(int x, int y, int w, int h);

        bool IsDialog { get; }
        IWindow Parent { get; }

        void Restore();
        void EnterFullScreen();
        void ExitFullScreen();
        
        bool IsMinimized { get; }
        bool CanMinimize { get; }
        bool CanMaxmimize { get; }
        bool CanResize { get; }
        bool CanMove { get; }
        bool CanClose { get; }
        bool IsFullScreen { get; }
        bool CanFullScreen { get; }

        int Desktop { get; }
        int Monitor { get; }
    }
}
