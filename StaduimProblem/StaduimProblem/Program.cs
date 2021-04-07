using System;

namespace StaduimProblem
{
    internal static class Program
    {
        private static void Main()
        {
            const int seatsCount = 120000;

            var minTime = double.MaxValue;
            var minN = 0;
            for (var n = 1; n < 30; n++)
            {
                var time = StadiumSolver.FillSeats(seatsCount, n);
                Console.WriteLine($"Gates = {n}, time to fill = {time}ms");
                if (time <= minTime)
                {
                    minTime = time;
                    minN = n;
                }
            }
            
            Console.WriteLine("\n-------\n");
            Console.WriteLine($"Min time = {minTime}ms\n with N = {minN}");
        }
    }
}