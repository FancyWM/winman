
using System.Collections.Generic;
using System.Linq;

namespace WinMan
{
    public static class WorkspaceExtensions
    {
        public static IReadOnlyList<IWindow> GetCurrentDesktopSnapshot(this IWorkspace workspace)
        {
            return workspace.GetSnapshot()
                .Where(workspace.VirtualDesktopManager.CurrentDesktop.HasWindow)
                .ToList();
        }
    }
}
