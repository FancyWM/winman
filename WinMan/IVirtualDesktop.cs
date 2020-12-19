using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinMan
{
    public interface IVirtualDesktop
    {
        bool IsCurrent { get; }

        void Add(IWindow window);

        bool Contains(IWindow window);
    }
}
