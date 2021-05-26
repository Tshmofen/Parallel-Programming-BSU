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

            var (minValue, optimalComposition) = builder.Perform();
            Console.WriteLine($"Min value = {minValue}");
            Console.WriteLine($"Optimal amount of block = {optimalComposition.Count}");
            
            Console.Write("\nComposition values: ");
            foreach (var value in optimalComposition)
                Console.Write($"{value} ");
        }
    }
}