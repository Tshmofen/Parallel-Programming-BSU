using System;
using Extreme.Mathematics;

namespace CalculationProblem
{
    public static class Calculating
    {
        private static readonly BigRational Error;

        static Calculating()
        {
            Error = 1 / BigRational.Pow(10, 6);
        }
        
        public static BigRational IntegralSinX2Row(int a)
        {
            BigRational sum = 0;
            BigRational previous;
            BigRational factorial = 1;
            
            var minus = 1;
            var n = 0;
            
            do
            {
                var member = minus * BigRational.Pow(a, 4 * n + 3) / (factorial * (4 * n + 3));
                n++;
                minus *= -1;
                factorial *= (2*n + 1) * (2 * n);
                previous = sum;
                sum += member;
            } while (BigRational.Abs(sum - previous) > Error);

            return sum;
        }

        public static double IntegralSinX2Trapeze(int a, int n)
        {
            var h = (double)a / n;
            var sum = (SinX2(0) + SinX2(h * n)) / 2;
            
            for (var i = 0; i < n; i++)
            {
                sum += SinX2(h * i);
            }

            return h * sum;
        }

        private static double SinX2(double x)
        {
            return Math.Sin(x * x);
        } 
    }
}