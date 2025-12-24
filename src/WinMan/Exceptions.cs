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

    public class InvalidDisplayReferenceException : InvalidReferenceException
    {
        public string DeviceID { get; }
        public IntPtr Handle { get; }

        public InvalidDisplayReferenceException(string deviceID)
            : base($"The device {deviceID} is not available.")
        {
            DeviceID = deviceID;
        }

        public InvalidDisplayReferenceException(string deviceID, Exception innerException)
            : base($"The device {deviceID} is not available.", innerException)
        {
            DeviceID = deviceID;
        }

        public InvalidDisplayReferenceException(IntPtr handle)
            : this($"0x{handle.ToString("X8")}")
        {
            Handle = handle;
        }

        public InvalidDisplayReferenceException(IntPtr handle, Exception innerException)
            : this($"0x{handle.ToString("X8")}", innerException)
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
