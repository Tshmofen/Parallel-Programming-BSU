using System.Collections.Generic;
using System.Linq;

namespace OptimalComposition
{
    public class CompositionBuilder
    {
        private readonly List<int> _executionTimes;
        private int _competingProcessorsAmount;
        private int _identicalProcessorsAmount;
        private int _overhead;

        public CompositionBuilder(
            List<int> executionTimes,
            int competingProcessorsAmount,
            int identicalProcessorsAmount,
            int overhead
            )
        {
            _executionTimes = executionTimes;
            _competingProcessorsAmount = competingProcessorsAmount;
            _identicalProcessorsAmount = identicalProcessorsAmount;
            _overhead = overhead;
        }

        public List<int> BuildDurations()
        {
            var s = _executionTimes.Count;
            
            var durationsMatrix = new int[s + 1][];
            for (var i = 0; i < durationsMatrix.Length; i++)
                durationsMatrix[i] = new int[s + 1];
            
            for (var j = 1; j <= s; j++)
            {
                durationsMatrix[s][j] = _executionTimes[j - 1];
            }
            
            for (var k = 1; s - k >= 2; k++)
            {
                for (var j = 1; j <= s - k; j++)
                {
                    durationsMatrix[s - k][j] = durationsMatrix[s - k + 1][j] + _executionTimes[j - 1 + k];
                }
            }

            var maxTime = _executionTimes.Max();
            var durations = durationsMatrix
                .SelectMany(line => line)
                .Where(duration => duration >= maxTime)
                .Distinct()
                .OrderBy(duration => duration)
                .ToList();

            return durations;
        }
    }
}