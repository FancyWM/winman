using System;

namespace WinMan
{
    public abstract class InvalidReferenceException : Exception
    {
        protected internal InvalidReferenceException()
        {
        }

        protected internal InvalidReferenceException(string message) : base(message)
        {
        }

        protected internal InvalidReferenceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }

    public class InvalidMonitorReferenceException : InvalidReferenceException
    {
        public IntPtr Handle { get; }

        public InvalidMonitorReferenceException(IntPtr handle)
            : base($"The monitor previously identified by the handle 0x{handle.ToString("X8")} has been destroyed.")
        {
            Handle = handle;
        }

        public InvalidMonitorReferenceException(IntPtr handle, Exception innerException)
            : base($"The monitor previously identified by the handle 0x{handle.ToString("X8")} has been destroyed.", innerException)
        {
            Handle = handle;
        }
    }

    public class InvalidVirtualDesktopReferenceException : InvalidReferenceException
    {
        public IntPtr Handle { get; }

        public InvalidVirtualDesktopReferenceException(IntPtr handle)
            : base($"The virtual desktop previously identified by the handle 0x{handle.ToString("X8")} has been destroyed.")
        {
            Handle = handle;
        }

        public InvalidVirtualDesktopReferenceException(IntPtr handle, Exception innerException)
            : base($"The virtual desktop identified by the handle 0x{handle.ToString("X8")} has been destroyed.", innerException)
        {
            Handle = handle;
        }
    }

    public class InvalidWindowReferenceException : InvalidReferenceException
    {
        public IntPtr Handle { get; }

        public InvalidWindowReferenceException(IntPtr handle)
            : base($"The window previously identified by the handle 0x{handle.ToString("X8")} has been destroyed.")
        {
            Handle = handle;
        }

        public InvalidWindowReferenceException(IntPtr handle, Exception innerException)
            : base($"The window previously identified by the handle 0x{handle.ToString("X8")} has been destroyed.", innerException)
        {
            Handle = handle;
        }
    }
}
