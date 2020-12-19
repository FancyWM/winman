
using WinMan.Implementation.Win32;

namespace WinMan
{
    public static class Workspaces
    {
        public static IWorkspace GetCurrentWorkspace()
        {
            return new Win32Workspace();
        }
    }
}
