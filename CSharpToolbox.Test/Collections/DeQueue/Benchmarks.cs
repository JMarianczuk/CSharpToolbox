using System;
using System.Collections.Generic;
using System.Diagnostics;
using CSharpToolbox.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpToolbox.Test.Collections.DeQueue
{
    [TestClass]
    [Ignore]
    public class Benchmarks
    {
        private List<int> List;
        private Queue<int> Queue;
        private DoubleEndedQueue<int> DeQueue;

        private Stopwatch Watch; 

        [TestInitialize]
        public void Init()
        {
            List = new List<int>();
            Queue = new Queue<int>();
            DeQueue = new DoubleEndedQueue<int>();

            Watch = new Stopwatch();
        }

        private const int MaxSize = 1000 * 1000;

        [Ignore]
        [TestMethod]
        public void InsertionTest()
        {
            Watch.Start();
            for (int i = 0; i < MaxSize; i += 1)
            {
                List.Add(i);
            }
            Watch.Stop();
            var listTime = Watch.Elapsed;

            Watch.Restart();
            for (int i = 0; i < MaxSize; i += 1)
            {
                Queue.Enqueue(i);
            }
            Watch.Stop();
            var queueTime = Watch.Elapsed;

            Watch.Restart();
            for (int i = 0; i < MaxSize; i += 1)
            {
                DeQueue.PushBack(i);
            }
            Watch.Stop();
            var dequeueTime = Watch.Elapsed;

            Console.WriteLine($"list: {listTime}");
            Console.WriteLine($"queue: {queueTime}");
            Console.WriteLine($"dequeue: {dequeueTime}");
        }
    }
}