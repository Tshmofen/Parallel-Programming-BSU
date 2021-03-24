using System;

namespace CalculationProblem
{
    public static class Calculating
    {
        private static readonly double Error;

        static Calculating()
        {
            Error = 1 / Math.Pow(10, 6);
        }
        
        public static double FindSinX2Integral(double a)
        {
            double sum = 0;
            double previous;

            var minus = 1;
            var n = 0;
            var factorial = 1;
            
            do
            {
                var member = minus * Math.Pow(a, 4 * n + 3) / (factorial * (4 * n + 3));
                n++;
                minus *= -1;
                factorial *= (2*n + 1) * (2 * n);
                previous = sum;
                sum += member;
            } while (Math.Abs(sum - previous) > Error);

            return sum;
        }
    }
}