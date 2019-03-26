using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task_2
{
    class Program
    {
        static void function()
        {
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("Запущен " + Thread.CurrentThread.Name);
            }

        }

        static void Main(string[] args)
        {
            /*Thread t1 = new Thread(function);
            t1.Name = "t1";
            Thread t2 = new Thread(function);
            t2.Name = "t2";
            Thread t3 = new Thread(function);
            t3.Name = "t3";

            Thread[] tmas = new Thread[3];
            tmas[0] = t1;
            tmas[1] = t2;
            tmas[2] = t3;

            for(int i = 0; i < 3; i++)
            {
                tmas[i].Start();
            }*/
            Thread[] th = new Thread[3];
            th[0] = new Thread(function);
            th[0].Name = "Theard 1";
            th[0].Start();
            th[1] = new Thread(function);
            th[1].Name = "Theard 2";
            th[1].Start();
            th[2] = new Thread(function);
            th[2].Name = "Theard 3";
            th[2].Start();

        }
    }
}
