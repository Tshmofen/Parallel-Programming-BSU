using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;

namespace Equations.Threading
{
    public static class ParallelSolver
    {
        public static readonly int AvailableThreads = Environment.ProcessorCount;
        // watch stores time of each SolveEquation perform
        public static readonly Stopwatch Watch = new();
        
        public static (Complex, Complex)[] SolveEquations(Complex[][] equations, int threadsNum = -1)
        {
            if (threadsNum == -1) threadsNum = AvailableThreads;
            var solutions = new (Complex, Complex)[equations.Length];
            var threads = new Thread[threadsNum];
            
            for (var i = 0; i < threadsNum; i++)
            {
                var start = i * equations.Length / threadsNum;
                var end = (i + 1) * equations.Length / threadsNum;
                threads[i] = new Thread(() =>
                {
                    for (var j = start; j < end; j++)
                    {
                        solutions[j] = Solver.EquationSolver.Solve
                        (
                            equations[j][0],
                            equations[j][1],
                            equations[j][2]
                        );
                    }
                });
            }
            
            Watch.Start();
            foreach (var thread in threads) thread.Start();
            foreach (var thread in threads) thread.Join();
            Watch.Stop();

            return solutions;
        }
    }
}