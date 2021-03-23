using System;

namespace StaduimProblem
{
    public class Stadium
    {
        private readonly int[] _sectorsFill;

        public int SectorsAmount { get; }
        public int SectorGates { get; }
        public int SectorCapacity { get; }

        public Stadium(int sectorAmount, int sectorCapacity, int sectorGates)
        {
            SectorsAmount = sectorAmount;
            SectorCapacity = sectorCapacity;
            SectorGates = sectorGates;

            _sectorsFill = new int[sectorAmount];
        }

        /// <summary>
        /// Fills the specified sector with the specified amount of people
        /// </summary>
        /// <param name="sector">Stadium sector</param>
        /// <param name="peopleAmount">Amount of people to send in sector</param>
        /// <returns>amount of people that been filled</returns>
        public int FillSector(int sector, int peopleAmount)
        {
            if (_sectorsFill[sector] == SectorCapacity)
            {
                Console.WriteLine("there");
                return peopleAmount;
            }

            var peopleToFill = (peopleAmount > SectorGates) ? SectorGates : peopleAmount;
            _sectorsFill[sector] += peopleAmount % (SectorGates + 1);

            var peopleOverflow = _sectorsFill[sector] - SectorCapacity;
            if (peopleOverflow > 0)
            {
                _sectorsFill[sector] = SectorCapacity;
                peopleToFill -= peopleOverflow;
            }

            return peopleToFill;
        }
    }
}