namespace StaduimProblem
{
    public class Sector
    {
        private readonly object _locker; 
            
        private readonly int _sectorCapacity;
        private int _currentAmount;
        
        public Sector(int sectorCapacity)
        {
            _locker = new object();
            _sectorCapacity = sectorCapacity;
        }
        
        public bool SendMan()
        {
            lock(_locker) {
                if (_currentAmount == _sectorCapacity) return false;
                _currentAmount++;
                    return true;
            }
        }
    }
}