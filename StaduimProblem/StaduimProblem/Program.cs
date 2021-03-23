using System;

namespace StaduimProblem
{
    internal static class Program
    {
        private static void Main()
        {
            const int sectorAmount = 12;
            const int sectorCapacity = 5000;
            int[] gateAmounts = {3, 10, 20, 30, 100, 1000, 5000};
            
            foreach (var sectorGates in gateAmounts)
            {
                var solver = new StadiumSolver(sectorAmount, sectorCapacity, sectorGates);
                solver.StartSimulation();
                Console.WriteLine($"{sectorGates} gates: {solver.Watch.Elapsed.TotalMilliseconds} ms");
            }
        }
    }
}