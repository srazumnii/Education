using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_3
{
    public class Main
    {
        static int count = 5;
        static double x = 1;
        static object sync = new();

        public static void MyMethod(object? foo)
        {
            if (foo is null) return;
            Func<double, double> func = (Func<double, double>)foo;

            for (int i = 0; i < count; i++)
            {
                lock (sync)
                {
                    x = func(x);
                    Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
                    Monitor.Pulse(sync);
                    Monitor.Wait(sync);
                }
            }
        }
        public static double Cos(double x)
        {
            return Math.Cos(x);
        }

        public static double Acos(double x)
        {
            return Math.Round(Math.Acos(x));
        }
        public static void Execute()
        {
            Thread t1 = new Thread(MyMethod){ Name = "A" };
            Thread t2 = new Thread(MyMethod){ Name = "B" };

            t1.Start(Cos);
            t2.Start(Acos);

            t1.Join();
            t2.Join();
        }
    }
}
