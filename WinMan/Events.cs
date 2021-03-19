using System;
using System.Collections.Generic;

namespace WinMan
{
    public class WindowChangedEventArgs : EventArgs
    {
        public IWindow Source { get; }

        public WindowChangedEventArgs(IWindow source)
        {
            Source = source;
        }

        public override bool Equals(object obj)
        {
            return obj is WindowChangedEventArgs args &&
                   EqualityComparer<IWindow>.Default.Equals(Source, args.Source);
        }

        public override int GetHashCode()
        {
            return 924162744 + EqualityComparer<IWindow>.Default.GetHashCode(Source);
        }
    }

    public class WindowFocusChangedEventArgs : WindowChangedEventArgs
    {
        public bool HasFocus { get; }

        public WindowFocusChangedEventArgs(IWindow source, bool hasFocus) : base(source)
        {
            HasFocus = hasFocus;
        }

        public override bool Equals(object obj)
        {
            return obj is WindowFocusChangedEventArgs args &&
                   base.Equals(obj) &&
                   EqualityComparer<IWindow>.Default.Equals(Source, args.Source) &&
                   HasFocus == args.HasFocus;
        }

        public override int GetHashCode()
        {
            int hashCode = 413946563;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IWindow>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + HasFocus.GetHashCode();
            return hashCode;
        }
    }

    public class WindowPositionChangedEventArgs : WindowChangedEventArgs
    {
        public Rectangle NewPosition { get; }
        public Rectangle OldPosition { get; }

        public WindowPositionChangedEventArgs(IWindow source, Rectangle newPosition, Rectangle oldPosition) : base(source)
        {
            NewPosition = newPosition;
            OldPosition = oldPosition;
        }

        public override bool Equals(object obj)
        {
            return obj is WindowPositionChangedEventArgs args &&
                   base.Equals(obj) &&
                   EqualityComparer<IWindow>.Default.Equals(Source, args.Source) &&
                   NewPosition.Equals(args.NewPosition) &&
                   OldPosition.Equals(args.OldPosition);
        }

        public override int GetHashCode()
        {
            int hashCode = 611763349;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IWindow>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + NewPosition.GetHashCode();
            hashCode = hashCode * -1521134295 + OldPosition.GetHashCode();
            return hashCode;
        }
    }

    public class WindowStateChangedEventArgs : WindowChangedEventArgs
    {
        public WindowState NewState { get; }
        public WindowState OldState { get; }

        public WindowStateChangedEventArgs(IWindow source, WindowState newState, WindowState oldState) : base(source)
        {
            NewState = newState;
            OldState = oldState;
        }

        public override bool Equals(object obj)
        {
            return obj is WindowStateChangedEventArgs args &&
                   base.Equals(obj) &&
                   EqualityComparer<IWindow>.Default.Equals(Source, args.Source) &&
                   NewState == args.NewState &&
                   OldState == args.OldState;
        }

        public override int GetHashCode()
        {
            int hashCode = -203352597;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IWindow>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + NewState.GetHashCode();
            hashCode = hashCode * -1521134295 + OldState.GetHashCode();
            return hashCode;
        }
    }

    public class WindowTitleChangedEventArgs : WindowChangedEventArgs
    {
        public string NewTitle { get; }
        public string OldTitle { get; }

        public WindowTitleChangedEventArgs(IWindow source, string newTitle, string oldTitle) : base(source)
        {
            NewTitle = newTitle;
            OldTitle = oldTitle;
        }

        public override bool Equals(object obj)
        {
            return obj is WindowTitleChangedEventArgs args &&
                   base.Equals(obj) &&
                   EqualityComparer<IWindow>.Default.Equals(Source, args.Source) &&
                   NewTitle == args.NewTitle &&
                   OldTitle == args.OldTitle;
        }

        public override int GetHashCode()
        {
            int hashCode = 194042067;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IWindow>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NewTitle);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OldTitle);
            return hashCode;
        }
    }

    public class WindowTopmostChangedEventArgs : WindowChangedEventArgs
    {
        public bool IsTopmost { get; }

        public WindowTopmostChangedEventArgs(IWindow source, bool isTopmost) : base(source)
        {
            IsTopmost = isTopmost;
        }

        public override bool Equals(object obj)
        {
            return obj is WindowTopmostChangedEventArgs args &&
                   base.Equals(obj) &&
                   EqualityComparer<IWindow>.Default.Equals(Source, args.Source) &&
                   IsTopmost == args.IsTopmost;
        }

        public override int GetHashCode()
        {
            int hashCode = -316675295;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IWindow>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + IsTopmost.GetHashCode();
            return hashCode;
        }
    }

    public class DesktopChangedEventArgs : EventArgs
    {
        public IVirtualDesktop Source { get; }

        public DesktopChangedEventArgs(IVirtualDesktop source)
        {
            Source = source;
        }

        public override bool Equals(object obj)
        {
            return obj is DesktopChangedEventArgs args &&
                   EqualityComparer<IVirtualDesktop>.Default.Equals(Source, args.Source);
        }

        public override int GetHashCode()
        {
            return 924162744 + EqualityComparer<IVirtualDesktop>.Default.GetHashCode(Source);
        }
    }

    public class CurrentDesktopChangedEventArgs : DesktopChangedEventArgs
    {
        public IVirtualDesktop NewDesktop => Source;

        public IVirtualDesktop OldDesktop { get; }

        public CurrentDesktopChangedEventArgs(IVirtualDesktop newDesktop, IVirtualDesktop oldDesktop) : base(newDesktop)
        {
            OldDesktop = oldDesktop;
        }

        public override bool Equals(object obj)
        {
            return obj is CurrentDesktopChangedEventArgs args &&
                   EqualityComparer<IVirtualDesktop>.Default.Equals(Source, args.Source) &&
                   EqualityComparer<IVirtualDesktop>.Default.Equals(NewDesktop, args.NewDesktop) &&
                   EqualityComparer<IVirtualDesktop>.Default.Equals(OldDesktop, args.OldDesktop);
        }

        public override int GetHashCode()
        {
            int hashCode = 1187749605;
            hashCode = hashCode * -1521134295 + EqualityComparer<IVirtualDesktop>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + EqualityComparer<IVirtualDesktop>.Default.GetHashCode(NewDesktop);
            hashCode = hashCode * -1521134295 + EqualityComparer<IVirtualDesktop>.Default.GetHashCode(OldDesktop);
            return hashCode;
        }
    }

    public class DisplayChangedEventArgs : EventArgs
    {
        public IDisplay Source { get; }

        public DisplayChangedEventArgs(IDisplay source)
        {
            Source = source;
        }

        public override bool Equals(object obj)
        {
            return obj is DisplayChangedEventArgs args &&
                   EqualityComparer<IDisplay>.Default.Equals(Source, args.Source);
        }

        public override int GetHashCode()
        {
            return 924162744 + EqualityComparer<IDisplay>.Default.GetHashCode(Source);
        }
    }

    public class DisplayRectangleChangedEventArgs : DisplayChangedEventArgs
    {
        public Rectangle NewBounds { get; }
        public Rectangle OldBounds { get; }

        public DisplayRectangleChangedEventArgs(IDisplay source, Rectangle newBounds, Rectangle oldBounds) : base(source)
        {
            NewBounds = newBounds;
            OldBounds = oldBounds;
        }

        public override bool Equals(object obj)
        {
            return obj is DisplayRectangleChangedEventArgs args &&
                   EqualityComparer<IDisplay>.Default.Equals(Source, args.Source) &&
                   NewBounds.Equals(args.NewBounds) &&
                   OldBounds.Equals(args.OldBounds);
        }

        public override int GetHashCode()
        {
            int hashCode = -2075636957;
            hashCode = hashCode * -1521134295 + EqualityComparer<IDisplay>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + NewBounds.GetHashCode();
            hashCode = hashCode * -1521134295 + OldBounds.GetHashCode();
            return hashCode;
        }
    }

    public class DisplayScalingChangedEventArgs : DisplayChangedEventArgs
    {
        public double NewScaling { get; }
        public double OldScaling { get; }

        public DisplayScalingChangedEventArgs(IDisplay source, double newScaling, double oldScaling) : base(source)
        {
            NewScaling = newScaling;
            OldScaling = oldScaling;
        }

        public override bool Equals(object obj)
        {
            return obj is DisplayScalingChangedEventArgs args &&
                   EqualityComparer<IDisplay>.Default.Equals(Source, args.Source) &&
                   NewScaling == args.NewScaling &&
                   OldScaling == args.OldScaling;
        }

        public override int GetHashCode()
        {
            int hashCode = 1968793037;
            hashCode = hashCode * -1521134295 + EqualityComparer<IDisplay>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + NewScaling.GetHashCode();
            hashCode = hashCode * -1521134295 + OldScaling.GetHashCode();
            return hashCode;
        }
    }

    public class PrimaryDisplayChangedEventArgs : DisplayChangedEventArgs
    {
        public IDisplay NewPrimaryDisplay => Source;
        public IDisplay OldPrimaryDisplay { get; }

        public PrimaryDisplayChangedEventArgs(IDisplay newPrimaryDisplay, IDisplay oldPrimaryDisplay) : base(newPrimaryDisplay)
        {
            OldPrimaryDisplay = oldPrimaryDisplay;
        }

        public override bool Equals(object obj)
        {
            return obj is PrimaryDisplayChangedEventArgs args &&
                   EqualityComparer<IDisplay>.Default.Equals(Source, args.Source) &&
                   EqualityComparer<IDisplay>.Default.Equals(NewPrimaryDisplay, args.NewPrimaryDisplay) &&
                   EqualityComparer<IDisplay>.Default.Equals(OldPrimaryDisplay, args.OldPrimaryDisplay);
        }

        public override int GetHashCode()
        {
            int hashCode = 337860155;
            hashCode = hashCode * -1521134295 + EqualityComparer<IDisplay>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + EqualityComparer<IDisplay>.Default.GetHashCode(NewPrimaryDisplay);
            hashCode = hashCode * -1521134295 + EqualityComparer<IDisplay>.Default.GetHashCode(OldPrimaryDisplay);
            return hashCode;
        }
    }
}