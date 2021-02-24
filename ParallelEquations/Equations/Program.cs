using System;
using Equations.Threading;

namespace Equations
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var equations = Generator.GenerateEquations(100000);
            
            // Threads num are equal to available processor threads
            ParallelSolver.SolveEquations(equations);
            Console.WriteLine($"{ParallelSolver.AvailableThreads} " +
                              $"threads : {ParallelSolver.Watch.ElapsedMilliseconds}ms\n");

            const int threadsNum = 1;
            ParallelSolver.SolveEquations(equations, threadsNum);
            Console.WriteLine($"{threadsNum}" +
                              $" threads : {ParallelSolver.Watch.ElapsedMilliseconds}ms");
        }
    }
}