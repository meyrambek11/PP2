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

        class mytheard
        {
            public string name = "";
            public Thread theardField;

            public mytheard(string name)
            {
                this.name = name;
                theardField = new Thread(StartTheard);
                theardField.Start();
               
            }
            public void StartTheard()
            {

                for (int i = 1; i <= 4; i++)
                {
                    Console.WriteLine(this.name + " выводить " + i);
                    Thread.Sleep(0);
                }
                Console.WriteLine(this.name + " завершился");               
            }
        }

        static void Main(string[] args)
        {
            mytheard t1 = new mytheard("Bale");
            mytheard t2 = new mytheard("Ramos");
            mytheard t3 = new mytheard("Isco");

            //t1.StartTheard();
            //t2.StartTheard();
            //t3.StartTheard();

        }
    }
}
