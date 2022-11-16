using System;

using RepoDb;
using RepoDb.Interfaces;

namespace Wytn.Sys.Repository
{
    public class SqlTrace : ITrace
    {
        public void AfterAverage(TraceLog log) { }
        public void AfterAverageAll(TraceLog log) { }
        public void AfterBatchQuery(TraceLog log) { }
        public void AfterCount(TraceLog log) { }
        public void AfterCountAll(TraceLog log) { }
        public void AfterDelete(TraceLog log) { }
        public void AfterDeleteAll(TraceLog log) { }
        public void AfterExecuteNonQuery(TraceLog log) { }
        public void AfterExecuteQuery(TraceLog log) { }
        public void AfterExecuteReader(TraceLog log) { }
        public void AfterExecuteScalar(TraceLog log) { }
        public void AfterExists(TraceLog log) { }
        public void AfterInsert(TraceLog log) { }
        public void AfterInsertAll(TraceLog log) { }
        public void AfterMax(TraceLog log) { }
        public void AfterMaxAll(TraceLog log) { }
        public void AfterMerge(TraceLog log) { }
        public void AfterMergeAll(TraceLog log) { }
        public void AfterMin(TraceLog log) { }
        public void AfterMinAll(TraceLog log) { }
        public void AfterQuery(TraceLog log) { }
        public void AfterQueryAll(TraceLog log) { }
        public void AfterQueryMultiple(TraceLog log) { }
        public void AfterSum(TraceLog log) { }
        public void AfterSumAll(TraceLog log) { }
        public void AfterTruncate(TraceLog log) { }
        public void AfterUpdate(TraceLog log) { }
        public void AfterUpdateAll(TraceLog log) { }
        public void BeforeAverage(CancellableTraceLog log) { Console.WriteLine($"BeforeAverage: {log.Statement}"); }
        public void BeforeAverageAll(CancellableTraceLog log) { Console.WriteLine($"BeforeAverageAll: {log.Statement}"); }
        public void BeforeBatchQuery(CancellableTraceLog log) { Console.WriteLine($"BeforeBatchQuery: {log.Statement}"); }
        public void BeforeCount(CancellableTraceLog log) { Console.WriteLine($"BeforeCount: {log.Statement}"); }
        public void BeforeCountAll(CancellableTraceLog log) { Console.WriteLine($"BeforeCountAll: {log.Statement}"); }
        public void BeforeDelete(CancellableTraceLog log) { Console.WriteLine($"BeforeDelete: {log.Statement}"); }
        public void BeforeDeleteAll(CancellableTraceLog log) { Console.WriteLine($"BeforeDeleteAll: {log.Statement}"); }
        public void BeforeExecuteNonQuery(CancellableTraceLog log) { Console.WriteLine($"BeforeExecuteNonQuery: {log.Statement}"); }
        public void BeforeExecuteQuery(CancellableTraceLog log) { Console.WriteLine($"BeforeExecuteQuery: {log.Statement}"); }
        public void BeforeExecuteReader(CancellableTraceLog log) { Console.WriteLine($"BeforeExecuteReader: {log.Statement}"); }
        public void BeforeExecuteScalar(CancellableTraceLog log) { Console.WriteLine($"BeforeExecuteScalar: {log.Statement}"); }
        public void BeforeExists(CancellableTraceLog log) { Console.WriteLine($"BeforeExists: {log.Statement}"); }
        public void BeforeInsert(CancellableTraceLog log) { Console.WriteLine($"BeforeInsert: {log.Statement}"); }
        public void BeforeInsertAll(CancellableTraceLog log) { Console.WriteLine($"BeforeInsertAll: {log.Statement}"); }
        public void BeforeMax(CancellableTraceLog log) { Console.WriteLine($"BeforeMax: {log.Statement}"); }
        public void BeforeMaxAll(CancellableTraceLog log) { Console.WriteLine($"BeforeMaxAll: {log.Statement}"); }
        public void BeforeMerge(CancellableTraceLog log) { Console.WriteLine($"BeforeMerge: {log.Statement}"); }
        public void BeforeMergeAll(CancellableTraceLog log) { Console.WriteLine($"BeforeMergeAll: {log.Statement}"); }
        public void BeforeMin(CancellableTraceLog log) { Console.WriteLine($"BeforeMin: {log.Statement}"); }
        public void BeforeMinAll(CancellableTraceLog log) { Console.WriteLine($"BeforeMinAll: {log.Statement}"); }
        public void BeforeQuery(CancellableTraceLog log) { Console.WriteLine($"BeforeQuery: {log.Statement}"); }
        public void BeforeQueryAll(CancellableTraceLog log) { Console.WriteLine($"BeforeQuery: {log.Statement}"); }
        public void BeforeQueryMultiple(CancellableTraceLog log) { Console.WriteLine($"BeforeQuery: {log.Statement}"); }
        public void BeforeSum(CancellableTraceLog log) { Console.WriteLine($"BeforeQuery: {log.Statement}"); }
        public void BeforeSumAll(CancellableTraceLog log) { Console.WriteLine($"BeforeSumAll: {log.Statement}"); }
        public void BeforeTruncate(CancellableTraceLog log) { Console.WriteLine($"BeforeTruncate: {log.Statement}"); }
        public void BeforeUpdate(CancellableTraceLog log) { Console.WriteLine($"BeforeUpdate: {log.Statement}"); }
        public void BeforeUpdateAll(CancellableTraceLog log) { Console.WriteLine($"BeforeUpdateAll: {log.Statement}"); }
    }
}
