using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJob
{
    public static class StaticServer
    {
        private static ReaderWriterLockSlim locker = new ReaderWriterLockSlim();
        private static int counter = 0;
        public static int Read()
        {
            try
            {
                locker.EnterReadLock();
                return counter;
            }
            finally
            {
                locker.ExitReadLock();
            }
        }
        public static void AddToCounter(int i)
        {
            try
            {
                locker.EnterWriteLock();
                counter += i;
            }
            finally
            {
                locker.ExitWriteLock();
            }
        }
    }
}
