using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_3
{
    class Program
    {
        public static void Probel(int a)//The function that allows us to put spaces in front of information;
        {
            for (int i = 0; i < a; i++)
            {
                Console.Write("     ");
            }
        }
        public static void Dir(DirectoryInfo All, int a)//We create function  to show information about the folder and first index equal to zero;
        {
            foreach (FileInfo fl in All.GetFiles())//If information will be file in GetFiles, we show name of file;
            {
                Probel(a);
                Console.WriteLine(fl.Name);
            }
            foreach (DirectoryInfo dr in All.GetDirectories())//If information will be folder in GetDirectories, we show name of folder and reopen this folder and repeat the function;
            {
                Probel(a);
                Console.WriteLine(dr.Name);
                Dir(dr, a + 1);// We again invite the function "Dir", but we increase index of function for spaces;
            }
        }
        static void Main(string[] args)
        {
            DirectoryInfo All = new DirectoryInfo(@"C:\Users\Мейрамбек\Desktop\PP2");
            //DirectoryInfo contains a set of members used to create new folders, Here we indicated the way;
            Dir(All, 0);// We invite the function "Dir";
        }
    }
}
