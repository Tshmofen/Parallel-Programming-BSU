using System;
using System.Diagnostics;
using System.Threading;

namespace StaduimProblem
{
    public static class StadiumSolver
    {
        public static double FillSeats(int seatsCount, int gatesCount)
        {
            var seats = new bool[seatsCount];
            var gateThreads = new Thread[gatesCount];

            for (var i = 0; i < gatesCount; i++)
            {
                var start = i * seatsCount / gatesCount;
                var end = (i + 1) * seatsCount / gatesCount;
                
                gateThreads[i] = new Thread(() =>
                {
                    for (var j = start; j < end; j++)
                    {
                        seats[j] = true;
                        Thread.Sleep(TimeSpan.FromTicks(10));
                    }
                });
            }
            var watch = new Stopwatch();
            
            watch.Start();
            foreach (var thread in gateThreads) thread.Start();
            foreach (var thread in gateThreads) thread.Join();
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
    }
}

