using System;
using Equations.Threading;

namespace Equations
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            const int equationsNum = 100000;
            const int threadsNum = 1;
            var equations = Generator.GenerateEquations(equationsNum);
            
            Console.WriteLine($"Equations num: {equationsNum}\n");
            // By default threads num are equal to available processor threads
            ParallelSolver.SolveEquations(equations);
            Console.WriteLine($"{ParallelSolver.AvailableThreads} " +
                              $"threads : {ParallelSolver.Watch.ElapsedMilliseconds}ms");
            ParallelSolver.SolveEquations(equations, threadsNum);
            Console.WriteLine($"{threadsNum}" +
                              $" threads : {ParallelSolver.Watch.ElapsedMilliseconds}ms");
        }
    }
}