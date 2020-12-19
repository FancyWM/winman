using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace WinMan.Utilities
{
    internal sealed class WaitJobThread
    {
        private struct WaitJob
        {
            public Func<bool> Condition;
            public TaskCompletionSource<object> TaskCompletionSource;
        }

        private ConcurrentBag<WaitJob> jobs = new ConcurrentBag<WaitJob>();
        private AutoResetEvent waitForJobs = new AutoResetEvent(false);

        private Thread thread;
        private int granularity;

        public WaitJobThread(int granularity = 0)
        {
            if (granularity < 0)
            {
                throw new ArgumentException(nameof(granularity));
            }

            this.granularity = granularity;
            thread = new Thread(Worker);
        }

        public Task AddJob(Func<bool> condition)
        {
            TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
            jobs.Add(new WaitJob { Condition = condition, TaskCompletionSource = tcs });
            TryStart();
            waitForJobs.Set();
            return tcs.Task;
        }

        private void TryStart()
        {
            try
            {
                thread.Start();
            }
            catch (ThreadStateException)
            {
                // Ignore
            }
        }

        private void Worker()
        {
            while (true)
            {
                bool empty = true;

                LinkedList<WaitJob> addBackList = new LinkedList<WaitJob>();
                while (jobs.TryTake(out WaitJob job))
                {
                    empty = false;

                    bool cond;
                    try
                    {
                        cond = job.Condition();
                    }
                    catch (Exception e)
                    {
                        job.TaskCompletionSource.TrySetException(e);
                        continue;
                    }

                    if (cond)
                    {
                        job.TaskCompletionSource.TrySetResult(null);
                    }
                    else
                    {
                        addBackList.AddLast(job);
                    }
                }

                if (empty)
                {
                    waitForJobs.WaitOne();
                    continue;
                }

                foreach (var job in addBackList)
                {
                    jobs.Add(job);
                }

                if (granularity == 0)
                {
                    Thread.Yield();
                }
                else
                {
                    Thread.Sleep(granularity);
                }
            }
        }
    }
}
