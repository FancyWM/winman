
using System.Collections.Generic;
using System.Linq;

namespace WinMan
{
    public static class WorkspaceExtensions
    {
        /// <summary>
        /// Returns a snapshot of the windows on the current desktop.
        /// </summary>
        public static IReadOnlyList<IWindow> GetCurrentDesktopSnapshot(this IWorkspace workspace)
        {
            return workspace.GetSnapshot()
                .Where(workspace.VirtualDesktopManager.CurrentDesktop.HasWindow)
                .ToList();
        }
    }
}
