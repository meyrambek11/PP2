using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {

            string file1 = @"C:\Users\Мейрамбек\Desktop\PP2\Path/Jake.txt";
            string file2 = @"C:\Users\Мейрамбек\Desktop\PP2\Path1/Jake.txt";

            if (File.Exists(@"C:\Users\Мейрамбек\Desktop\PP2\Path\Jake.txt"))
            {
                Console.WriteLine("File exist");
            }
            else
                Console.WriteLine("You can not do this operation");

            File.Copy(file1, file2);
            Console.WriteLine("Copied");

            if (File.Exists(@"C:\Users\Мейрамбек\Desktop\PP2\Path\Jake.txt"))
            {
                try
                {
                    File.Delete(@"C:\Users\Мейрамбек\Desktop\PP2\Path\Jake.txt");
                }
                catch(IOException)
                {
                    Console.WriteLine("Exception");
                    return;
                }
            }
            Console.WriteLine("Original File Deleted");
        }
    }
}
