using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _8
{
    class Program
    {
        public static void Probel(int a)
        {
            for(int i = 0; i < a; i++)
            {
                Console.Write("   ");
            }
        }
        public static void Dir(DirectoryInfo All, int a)
        {
            foreach (FileInfo fl in All.GetFiles())
            {
                Probel(a);
                Console.WriteLine(fl.Name);
            }
            foreach (DirectoryInfo dr in All.GetDirectories())
            {
                Probel(a);
                Console.WriteLine(dr.Name);
                Dir(dr, a + 1);
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo All = new DirectoryInfo(@"C:\Users\Мейрамбек\Desktop\PP2");
            Dir(All, 0);        
        }
    }
}
