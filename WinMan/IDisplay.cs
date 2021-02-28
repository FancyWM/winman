namespace WinMan
{
    public interface IDisplay
    {
        event DisplayChangedHandler Removed;

        Rectangle WorkArea { get; }

        Rectangle Bounds { get; }

        IWorkspace Workspace { get; }
    }
}