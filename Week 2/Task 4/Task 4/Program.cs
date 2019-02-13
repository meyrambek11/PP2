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

            string file1 = @"C:\Users\Мейрамбек\Desktop\Path\1.txt"; //We create new file in the folder which called "path" and indicate the way;
            string file2 = @"C:\Users\Мейрамбек\Desktop\Path1\1.txt";//We create new folder which called "path1", initially the folder is empty; 

            if (File.Exists(@"C:\Users\Мейрамбек\Desktop\Path\1.txt"))// If indicated file exists we may do any operation;
            {
                Console.WriteLine("File exist");
            }
            else
                Console.WriteLine("You can not do this operation");

            File.Copy(file1, file2);//We indicate adress of files and copied to another folder;
            Console.WriteLine("Copied");

            if (File.Exists(@"C:\Users\Мейрамбек\Desktop\Path\1.txt"))// If indicated file exists we may do any operation;
            {
                try
                {
                    File.Delete(@"C:\Users\Мейрамбек\Desktop\Path\1.txt");//We indicate the way of file and delete it;
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
