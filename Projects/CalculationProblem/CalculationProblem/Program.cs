using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CalculationProblem
{
    internal static class Program
    {
        private static void Main()
        {
            var (rows, trapezes) = Solver.SolveIntegrals
            (
                out var elapsedRow,
                out var elapsedTrapeze
            );
            
            Console.WriteLine("Row results: \n");
            foreach (var solution in rows)
                Console.WriteLine(solution);
            Console.WriteLine($"\nElapsed Time: {elapsedRow}ms");
            
            Console.WriteLine("\n--------\n\nTrapeze results: \n");
            foreach (var solution in trapezes)
                Console.WriteLine(solution);
            Console.WriteLine($"\nElapsed Time: {elapsedTrapeze}ms");
        }
    }
}