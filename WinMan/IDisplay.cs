using System;

namespace WinMan
{
    /// <summary>
    /// Represents a display that is attached to the system and can contain windows.
    /// </summary>
    public interface IDisplay
    {
        /// <summary>
        /// The display has been removed.
        /// </summary>
        event EventHandler<DisplayChangedEventArgs> Removed;

        /// <summary>
        /// The work area has changed.
        /// </summary>
        event EventHandler<DisplayRectangleChangedEventArgs> WorkAreaChanged;

        /// <summary>
        /// The bounds have changed.
        /// </summary>
        event EventHandler<DisplayRectangleChangedEventArgs> BoundsChanged;

        /// <summary>
        /// The display scaling has changed.
        /// </summary>
        event EventHandler<DisplayScalingChangedEventArgs> ScalingChanged;

        IWorkspace Workspace { get; }

        /// <summary>
        /// The current work area.
        /// </summary>
        Rectangle WorkArea { get; }

        /// <summary>
        /// The current display bounds.
        /// </summary>
        Rectangle Bounds { get; }

        /// <summary>
        /// The current scaling factor assigned to this display.
        /// </summary>
        double Scaling { get; }
    }
}