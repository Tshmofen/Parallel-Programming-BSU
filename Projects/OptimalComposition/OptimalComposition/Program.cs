using System;
using System.Collections.Generic;

namespace OptimalComposition
{
    internal static class Program
    {
        private static void Main()
        {
            var executionTimes = new List<int> {10, 20, 5, 20, 5, 10, 10, 5, 10, 5};
            const int competingProcessorsAmount = 5;
            const int identicalProcessorsAmount = 3;
            const int overhead = 4;

            var builder = new CompositionBuilder(
                executionTimes, 
                competingProcessorsAmount,
                identicalProcessorsAmount,
                overhead
                );

            foreach (var time in builder.BuildDurations())
                Console.WriteLine(time);
        }
    }
}