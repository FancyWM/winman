using System;

namespace WinMan
{
    public interface ILiveThumbnail : IDisposable
    {
        IWindow SourceWindow { get; }
        IWindow DestinationWindow { get; }
        Rectangle Location { get; set; }
    }
}