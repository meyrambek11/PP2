using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream Numbers = new FileStream(@"C:\Users\Мейрамбек\Desktop\Новая папка\Nouer.txt", FileMode.Open, FileAccess.Read);
            //FileStream provides options for reading from a file and writing to a file. Here we indicated the path, opened the file and read the information;
            StreamReader sr = new StreamReader(Numbers);//Streamreader is a stream that allows us to count information;
            FileStream Num = new FileStream(@"C:\Users\Мейрамбек\Desktop\Новая папка\Borusia\Muller.txt", FileMode.Create, FileAccess.Write);
            //FileStream provides options for reading from a file and writing to a file. Here we indicated the new path, created the new file and write the information in new fail;
            StreamWriter sw = new StreamWriter(Num); //Streamwriter is a stream that allows us to write the information to new file;
            string x = sr.ReadLine();//we read the information as string;
            //int cnt = 0;
            /*for (int i = 0; i < x.Length; i++)
            {
                if (x[i] == ' ')
                {
                    cnt++;
                }
            }*/
            string[] N = x.Split(' '); // We create new array and read our information like string;
            for (int i = 0; i < N.Length; i++)
            {
                bool m = true;//We created it to determine the number of prime or not, initially all numbers are prime;
                int a = int.Parse(N[i]);//Function "Parse" allows us to convert string to int;
                for (int j = 2; j < a; j++)
                {
                    if (a % j == 0)// So that the number was prime, it should be divided by itself and one;
                    {
                        m = false;//It shows that numbers are not prime;
                        break;
                    }
                }
                if (a > 1 && m == true) // Prime numbers must more than 1 and 0;
                {
                    sw.Write(a + " ");//We write this information to new file;
                    Console.Write(a + " ");// We show prime numbers;
                }
            }
            sr.Close();//We must closed the stream, Because it may be available for other operations;
            Numbers.Close();// We closed the FileStream;
            sw.Close();//We must closed the stream, Because it may be available for other operations;
            Num.Close();// We closed the FileStream;



        }
    }
}
