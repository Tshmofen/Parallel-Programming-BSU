using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace CalculationProblem
{
    public static class Solver
    {
        public static (List<double>, List<double>) SolveIntegrals(out long elapsedRow, out long elapsedTrapeze)
        {
            var rowSolutions = new List<double>();
            var trapezeSolutions = new List<double>();
            
            var watchRow = new Stopwatch();
            var watchTrapeze = new Stopwatch();
            
            var threadRow = new Thread(() =>
            {
                watchRow.Start();
                for (var i = 1; i < 10; i++)
                    rowSolutions.Add((double)Calculating.IntegralSinX2Row(i));
                watchRow.Stop();
            });
            var threadTrapeze = new Thread(() =>
            {
                watchTrapeze.Start();
                for (var i = 1; i < 10; i++)
                    trapezeSolutions.Add((double)Calculating.IntegralSinX2Trapeze(i, 200));
                watchTrapeze.Stop();
            });
            
            threadRow.Start();
            threadTrapeze.Start();
            threadRow.Join();
            threadTrapeze.Join();

            elapsedRow = watchRow.ElapsedMilliseconds;
            elapsedTrapeze = watchTrapeze.ElapsedMilliseconds;
            return (rowSolutions, trapezeSolutions);
        }
    }
}