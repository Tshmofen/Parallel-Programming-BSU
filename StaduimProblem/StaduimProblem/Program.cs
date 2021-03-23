using System;

namespace StaduimProblem
{
    internal static class Program
    {
        private static void Main()
        {
            const int sectorCapacity = 5000;
            (int, int)[] gateAmounts = {(12, 1), (12, 2), (12, 5),
                (12, 10), (12, 100), (12, 500), (12, 1000), (12, 5000)};
            
            Console.WriteLine($"Each sector has {sectorCapacity} seats\n");
            foreach (var (sectorAmount, gatesOnSector) in gateAmounts)
            {
                var solver = new StadiumSolver(sectorAmount, sectorCapacity);
                solver.StartSimulation(gatesOnSector);
                Console.WriteLine($"{sectorAmount} sectors and {gatesOnSector} gates on sector:" +
                                  $" {solver.Watch.Elapsed.TotalMilliseconds} ms to fill up all sectors");
            }
        }
    }
}