using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab1_2
{
    public class Main
    {
        public static void Execute()
        {
            Thread t1 = new Thread(new MyThread() { Name = "A" }.Print);
            Thread t2 = new Thread(new MyThread() { Name = "B", ParallelThread = t1 }.Print);
            t1.Start();
            t2.Start();
        }
    }

    public class MyThread
    {
        public string Name { get; init; }
        public Thread ParallelThread { get; set; }
        public void Print()
        {
            if (ParallelThread != null) ParallelThread.Join();
            for (int i = 1; i <= 100; i++)
            {
                Console.WriteLine($"{Name}: {i}");
            }
        }
    }
}
