using System;
using System.Threading;

using WinMan;

namespace WinManTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IWorkspace ws = Workspaces.GetCurrentWorkspace();
            ws.WindowManaging += OnWindowManaging;
            ws.WindowAdded += OnWindowAdded;
            ws.WindowRemoved += OnWindowRemoved;
            ws.Open();

            Thread.Sleep(1000000);
        }

        private static void OnWindowRemoved(IWindow obj)
        {
            Console.WriteLine("Removed " + obj);
        }

        private static void OnWindowManaging(IWindow obj)
        {
            obj.Moved += OnWindowMoved;
            Console.WriteLine("Managing " + obj);
        }

        private static void OnWindowAdded(IWindow obj)
        {
            obj.Moved += OnWindowMoved;
            Console.WriteLine("Added " + obj);
        }

        private static void OnWindowMoved(IWindow obj)
        {
            Console.WriteLine("Moved " + obj + " to " + obj.Position);
        }
    }
}
