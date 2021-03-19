using System;

namespace WinMan
{
    public interface IDisplay
    {
        event EventHandler<DisplayChangedEventArgs> Removed;

        event EventHandler<DisplayRectangleChangedEventArgs> WorkAreaChanged;

        event EventHandler<DisplayRectangleChangedEventArgs> BoundsChanged;

        event EventHandler<DisplayScalingChangedEventArgs> ScalingChanged;

        Rectangle WorkArea { get; }

        Rectangle Bounds { get; }

        IWorkspace Workspace { get; }

        double Scaling { get; }
    }
}