using System;
using System.Numerics;

namespace Equations
{
    public static class Generator
    {
        private static readonly Random Rand = new();
        
        public static Complex[][] GenerateEquations(int length)
        {
            var equations = new Complex[length][];
            
            for(var i = 0; i < equations.Length; i++)
            {
                equations[i] = new Complex[3];
                
                equations[i][0] = GenerateCoefficient();
                equations[i][1] = GenerateCoefficient();
                equations[i][2] = GenerateCoefficient();
                
                if (equations[i][0] == default) equations[i][0] = Complex.One;
            }

            return equations;
        }

        private static Complex GenerateCoefficient()
        {
            var real = GenerateSign() * Math.Sqrt(Rand.NextDouble());
            var imaginary = GenerateSign() * Math.Sqrt(Rand.NextDouble());
            return new Complex(real, imaginary);
        }

        private static int GenerateSign() => (Rand.Next() % 2 == 1) ? -1 : 1;
    }
}