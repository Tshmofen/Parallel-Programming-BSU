using System.Numerics;

namespace Equations.Solver
{
    public static class EquationSolver
    {
        public static (Complex, Complex) Solve(Complex a, Complex b = default, Complex c = default)
        {
            var d = b * b - 4 * a * c;
            var x1 = (-b + Complex.Sqrt(d)) / (2 * a);
            var x2 = (-b - Complex.Sqrt(d)) / (2 * a);
            return (x1, x2);
        }
    }
}

