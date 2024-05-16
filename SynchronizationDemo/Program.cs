namespace SynchronizationDemo
{
    internal class Program
    {
        static List<string> _list = new List<string>();
        static void Main(string[] args)
        {
            //Thread thread = new Thread(_ =>
            //{
            //    ThreadUnsafe.ProcessPatsh1();
            //});
            //    thread.Start();
            //    Thread thread2 = new Thread(_ =>
            //    {
            //        ThreadUnsafe.ProcessPatsh2();
            //    });
            //    thread2.Start();
            new Thread(AddItem).Start();
            new Thread(AddItem).Start();
            new Thread(AddItem).Start();
            new Thread(AddItem).Start();
            new Thread(AddItem).Start();


        }
        static void AddItem()
        {
            lock (_list) _list.Add("Item " + _list.Count);
            string[] items;
            lock (_list) items = _list.ToArray();
            foreach (string s in items) Console.WriteLine(s);
        }
    }

}
public class ThreadUnsafe
    {
        static readonly object locker = new object();
      
        public static void ProcessPatsh1()
        {
            for (int i = 1; i <= 1000; i++)
            {
                lock (locker)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
          
        }
        public static void ProcessPatsh2()
        {
            for (int i = 1001; i <= 2000; i++)
            {
                lock (locker)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(i);
                    Console.ForegroundColor = ConsoleColor.White;

                }
            }
          
        }
        
    }

