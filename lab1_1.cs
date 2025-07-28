using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Education
{
    public class lab1_1
    {
        public static void Execute()
        {
            Thread t1 = new Thread(new MyThread() { arg1 = 18, arg2 = 4 }.Print) { Name = "A" };
            Thread t2 = new Thread(new MyThread() { arg1 = 0, arg2 = 7 }.Print) { Name = "B" };
            t1.Start();
            t2.Start();
        }
    }

    public class MyThread
    {
        public required int arg1 { get; init; }
        public required int arg2 { get; init; }
        public void Print()
        {
            List<int> args = new List<int>() { arg1, arg2 };
            args.Sort();

            for (int i = args[0]; i <= args[1]; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
            }
        }
    }
}
