using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class Program
    {
        public static void F1()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C: \Users\Мейрамбек\Desktop\PP2\Test");
            FileSystemInfo[] x = dirInfo.GetFileSystemInfos();
            for(int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i].Name);
            }
        }
        public static void F2() {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C: \Users\Мейрамбек\Desktop\PP2\Test");
            FileSystemInfo[] x = dirInfo.GetFileSystemInfos();
            for (int i = 0; i < x.Length; i++)
            {
                if(x[i].GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(x[i].Name);
            }
            
        }
        public static void PrintInfo(FileSystemInfo [] x,ConsoleColor c)
        {
            Console.ForegroundColor = c;
            for(int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i].Name);
            }


        }
        
        public static void F4()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C: \Users\Мейрамбек\Desktop\PP2\Test");
            PrintInfo(dirInfo.GetDirectories(), ConsoleColor.Blue);
            PrintInfo(dirInfo.GetFiles(), ConsoleColor.Green);
            

        }

        static void Main(string[] args)
        {
            F4();
        }
    }
}
