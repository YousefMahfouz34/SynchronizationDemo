namespace SynchronizationDemo
{
    internal class RateCalculator
    {
        int rate;
        private static readonly Object _lock = new Object();
        private RateCalculator()
        {
            Console.WriteLine("Constructor");
            rate = 50;
        }

        private static RateCalculator _instance = new RateCalculator();
        public static RateCalculator Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new RateCalculator();
                    return _instance;
                }
            }
        }

        public int GetRate()
        {
            Console.WriteLine(rate);
            return rate;
        }
    }
}