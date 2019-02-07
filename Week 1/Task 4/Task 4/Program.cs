using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            string b = Console.ReadLine(); //We need to read it as string
            int a = int.Parse(b); // Function "Parse" allows us to convert string to int;
            int[,] A = new int[a, a];  // Created 2D array;
             /* 
             00 01 02 03
             10 11 12 13
             20 21 22 23
             30 31 32 33 */ //Like that;
            for (int i = 0; i <= a; i++)
            {
                for (int j = 0; j < i; j++) //Increase 'j' till j < i and to those positions put "[*]";
                {
                    Console.Write("[*]"); // Showing elements in [i,j<i];
                }
                Console.WriteLine();
            }
        }
    }
}
