using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string b = Console.ReadLine(); //We need to read integer it as string;
            int a = int.Parse(b); // Function "Parse" allows us to convert string to int;
            string[] Arr = Console.ReadLine().Split(' '); // We read our (a) integers as string, then the function Split helps us to seperate our digits;
            List<int> A = new List<int>(); //We create new list;
            for(int i = 0; i < a; i++)
            {
                int k = int.Parse(Arr[i]); // We convert our string into int;
                A.Add(k); //We add every integer to new list;
            }
            
            for (int k = 0; k < A.Count; k++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(A[k] + " "); ///Showing each element twice;
                }
            }
        }
    }
}