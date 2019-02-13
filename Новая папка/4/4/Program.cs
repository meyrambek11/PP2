using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _4
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            FileStream Numbers = new FileStream(@"C:\Users\Мейрамбек\Desktop\PP2\Test\Hankok\text.txt",FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(Numbers);
            FileStream Num = new FileStream(@"C:\Users\Мейрамбек\Desktop\PP2\Test\Hankok\Print.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(Num);
            string x = sr.ReadLine();
            int cnt = 0;
            for(int i = 0; i < x.Length; i++)
            {
                if(x[i] == ' ')
                {
                    cnt++;
                }
            }
            string[] N = x.Split(' ');
            for(int i = 0; i < cnt + 1; i++)
            {
                bool m = true;
                int a = int.Parse(N[i]);
                    for(int j = 2; j < a; j++)
                    {
                        if(a%j == 0)
                        {
                        m = false;
                        }
                    }
                if(a > 1 && m == true)
                {
                    sw.Write(a + " ");
                    Console.Write(a + " ");
                }
            }
            sr.Close();
            Numbers.Close();
            sw.Close();
            Num.Close();
        }

    }
}
