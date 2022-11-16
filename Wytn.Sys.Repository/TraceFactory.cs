
using RepoDb.Interfaces;

namespace Wytn.Sys.Repository
{
    public static class TraceFactory
    {
        private static object _syncLock = new object();
        private static ITrace _trace = null;

        public static ITrace CreateTracer()
        {
            if (_trace == null)
            {
                lock (_syncLock)
                {
                    if (_trace == null)
                    {
                        _trace = new SqlTrace();
                    }
                }
            }
            return _trace;
        }
    }
}
