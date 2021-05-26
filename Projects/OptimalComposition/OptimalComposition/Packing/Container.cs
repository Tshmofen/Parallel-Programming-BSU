namespace OptimalComposition.Packing
{
    public class Container
    {
        private int _filled;
        private int MaxFill { get; }
        private int Available => MaxFill - _filled;

        public int CurrentFill => _filled;
        
        public Container(int maxFill = 1)
        {
            _filled = 0;
            MaxFill = maxFill;
        }

        public bool Add(int number)
        {
            if (Available - number >= 0)
            {
                _filled += number;
                return true;
            }
            return false;
        }
    }
}