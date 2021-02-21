namespace WinMan
{
    public interface IVirtualDesktop
    {
        event VirtualDesktopRemovedEventHandler Removed;

        IWorkspace Workspace { get; }

        bool IsCurrent { get; }

        int Index { get; }

        string Name { get; }

        void MoveWindow(IWindow window);

        bool HasWindow(IWindow window);

        void SwitchTo();

        void SetName(string newName);

        void Remove();
    }
}
