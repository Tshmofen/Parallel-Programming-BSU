using System;
using System.Diagnostics;
using System.Threading;

namespace StaduimProblem
{
    public class StadiumSolver
    {
        private readonly Stadium _stadium;

        public Stopwatch Watch { get; }
        
        public StadiumSolver(int sectorAmount, int sectorCapacity, int sectorGates)
        {
            _stadium = new Stadium(sectorAmount, sectorCapacity, sectorGates);
            Watch = new Stopwatch();
        }

        public void StartSimulation()
        {
            var threads = new Thread[_stadium.SectorsAmount];
            for (var i = 0; i < _stadium.SectorsAmount; i++)
            {
                var sector = i;
                threads[sector] = new Thread(() =>
                {
                    var peopleToFill = _stadium.SectorCapacity;
                    while (peopleToFill != 0)
                    {
                        Thread.Sleep(TimeSpan.FromTicks(1));
                        peopleToFill -= _stadium.FillSector(sector, peopleToFill);
                    }
                });
            }

            Watch.Start();
            for (var i = 0; i < _stadium.SectorsAmount; i++)
                threads[i].Start();
            for (var i = 0; i < _stadium.SectorsAmount; i++)
                threads[i].Join();
            Watch.Stop();
        }
    }
}