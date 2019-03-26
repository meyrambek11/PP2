using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {

            string a = Console.ReadLine(); //As we can't directly insert integers, firstly, we need to read it as string;
            int cnt = 0; // for counting amount of prime numbers
            int s = int.Parse(a); //Function "Parse" allows us to convert string to int;   
            string[] A = Console.ReadLine().Split(' '); //create new array and read our s integers like string;
            List<int> myArr = new List<int>(); //Create a new list;
            List<int> arr = new List<int>(); //Create a new list;
            for(int i = 0; i < s; i++)
            {
                int t = int.Parse(A[i]); // We convert our string into int;
                myArr.Add(t);  // adding every element of numb into new list
            }
            for (int j = 0; j < myArr.Count; j++) //to identify prime numbers
            {
                bool m = true; //I created it to determine the number of prime or not, initially all numbers are prime
                for (int k = 2; k < myArr[j]; k++)
                {
                    if (myArr[j] % k == 0) // So that the number was prime, it should be divided by itself and one
                    {
                        m = false; 
                        break;
                    }
                }
                if (m == true && myArr[j] > 1)
                {
                    arr.Add(myArr[j]); // i add prime numbers to new list;
                    cnt++;  // if number is prime then cnt++;
                }
            }
            Console.WriteLine(cnt); // To show sum of primes;
            for(int l = 0; l < arr.Count; l++)
            {
                Console.Write(arr[l] + " "); //to Show prime numbers;
            }
            Console.ReadKey();
        }
    }
}
