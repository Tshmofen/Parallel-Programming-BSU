using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace StaduimProblem
{
    public class StadiumSolver
    {
        private readonly Stadium _stadium;

        public Stopwatch Watch { get; }
        
        public StadiumSolver(int sectorAmount, int sectorCapacity)
        {
            _stadium = new Stadium(sectorAmount, sectorCapacity);
            Watch = new Stopwatch();
        }

        public void StartSimulation(int gatesOnSector)
        {
            var gatesAmount = gatesOnSector * _stadium.SectorsAmount;
            var threads = new Thread[gatesAmount];
            for (var i = 0; i < _stadium.SectorsAmount; i++)
            {
                for (var j = 0; j < gatesOnSector; j++)
                {
                    var sector = _stadium.GetSector(i);
                    threads[i * gatesOnSector + j] = new Thread(() =>
                    {
                        while (sector.SendMan()) { }
                    });
                }
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