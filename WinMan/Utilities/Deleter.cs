using System;

namespace WinMan.Utilities
{
    internal class Deleter : IDisposable
    {
        private Action disposeAction;

        public Deleter(Action disposeAction)
        {
            this.disposeAction = disposeAction ?? throw new ArgumentNullException(nameof(disposeAction));
        }

        private void DisposeImpl()
        {
            if (disposeAction != null)
            {
                disposeAction();
                disposeAction = null;
            }
        }

        ~Deleter()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            DisposeImpl();
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            DisposeImpl();
            GC.SuppressFinalize(this);
        }
    }
}
