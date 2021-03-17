namespace WinMan
{
    public delegate void DisplayWorkAreaChangedHandler(IDisplay display, Rectangle oldWorkArea);
    public delegate void DisplayBoundsChangedHandler(IDisplay display, Rectangle oldBounds);
    public delegate void DisplayScalingChangedHandler(IDisplay display, double oldScaling);

    public interface IDisplay
    {
        event DisplayChangedHandler Removed;

        event DisplayWorkAreaChangedHandler WorkAreaChanged;

        event DisplayBoundsChangedHandler BoundsChanged;

        event DisplayScalingChangedHandler ScalingChanged;

        Rectangle WorkArea { get; }

        Rectangle Bounds { get; }

        IWorkspace Workspace { get; }

        double Scaling { get; }
    }
}