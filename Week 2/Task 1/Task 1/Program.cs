using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_1
{
    class Program
    {
        public static void Solution(string name)//function that defines polindrome;
        {
            int cnt = 0;
            for (int i = 0; i < name.Length / 2; i++)
            {
                if (name[i] == name[name.Length - 1 - i])
                {
                    cnt++;
                }
            }
            if (cnt == name.Length / 2)//cnt must be equal to half of string length;
            {
                Console.WriteLine("Yes");
            }
            else
                Console.WriteLine("No");
        }

        static void Main(string[] args)
        {
            FileStream x = new FileStream(@"C:\Users\Мейрамбек\Desktop\Новая папка\Nouer.txt", FileMode.Open, FileAccess.Read);
            //FileStream provides options for reading from a file and writing to a file. Here we indicated the path, opened the file and read the information;
            StreamReader sr = new StreamReader(x); //Streamreader is a stream that allows us to count information;
            string name = sr.ReadLine();//we read the information as string;
            Solution(name);//opened the function to determine whether the word polindrome;
            sr.Close();//We must closed the stream, Because it may be available for other operations;
            x.Close();// We closed the FileStream;
        }
    }
}
