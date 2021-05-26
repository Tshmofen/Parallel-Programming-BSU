using System.Collections.Generic;
using System.Linq;
using OptimalComposition.Packing;

namespace OptimalComposition
{
    public class CompositionBuilder
    {
        private readonly List<int> _executionTimes;
        private readonly int _competingProcessorsAmount;
        private readonly int _identicalProcessorsAmount;
        private readonly int _overhead;

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
        
        public (int minValue, List<int> optimalComposition) Perform()
        {
            var s = _executionTimes.Count;
            var p = _identicalProcessorsAmount;
            var n = _competingProcessorsAmount;

            var t = new int[s + 1];
            var m = new List<int>[s + 1];
            var l = new int[s + 1];

            m[0] = m[s] = new List<int>(_executionTimes);
            t[0] = GetT(p, n, m[s]);
            l[0] = s;

            var v = BuildDurations();

            for (var i = 1; i < v.Count; i++)
            {
               var composition = ContainerManager
                    .PerformNextFit(_executionTimes, v[i])
                    .Select(container => container.CurrentFill)
                    .ToList();
                l[i] = composition.Count;
                
                if (l[i] != l[i - 1])
                {
                    m[i] = composition;
                    t[i] = GetT(p, n, composition);
                    if (t[i] < t[0])
                    {
                        t[0] = t[i];
                        m[0] = m[i];
                    }
                }
                
                if (l[i] <= 2) break;
            }
            
            return (t[0], m[0]);
        }
        
        private List<int> BuildDurations()
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

        private int GetT(int p, int n, List<int> m)
        {
            var s = m.Count;
            
            var tS = _overhead + m.Max();
            var tB = s * _overhead + m.Sum();

            var k = s / p;
            var r = s % p;
            
            if (r == 0 || p == n && tB <= p * tS)
            {
                return tB + (n - 1) * tS;
            }

            return (k + 1) * tB + (r - 1) * tS;
        }
    }
}