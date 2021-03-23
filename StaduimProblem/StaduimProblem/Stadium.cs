namespace StaduimProblem
{
    public class Stadium
    {
        private readonly Sector[] _sectors;

        public int SectorsAmount { get; }
        public int SectorCapacity { get; }

        public Stadium(int sectorsAmount, int sectorCapacity)
        {
            SectorsAmount = sectorsAmount;
            SectorCapacity = sectorCapacity;

            _sectors= new Sector[sectorsAmount];
            for (var i = 0; i < sectorsAmount; i++)
                _sectors[i] = new Sector(sectorCapacity);
        }

        public Sector GetSector(int sector) => _sectors[sector];
    }
}