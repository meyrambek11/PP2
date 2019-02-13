using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _10
{
    class Program
    {
        public static void Solution(string name)
        {
            int cnt = 0;
            for (int i = 0; i < name.Length / 2; i++)
            {
                if (name[i] == name[name.Length - 1 - i])
                {
                    cnt++;
                }
            }
            if (cnt == name.Length / 2)
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No");


        }

        static void Main(string[] args)
        {
            FileStream x = new FileStream(@"C:\Users\Мейрамбек\Desktop\Klass\Text.txt", FileMode.Open, FileAccess.Read);
            //FileStream x = new FileStream(@"C:\Users\Мейрамбек\Desktop\PP2\Test\Hankok\text.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(x);
            string name = sr.ReadLine();
            Solution(name);
            sr.Close();
            x.Close();
        }
    }
}
