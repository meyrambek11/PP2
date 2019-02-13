using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _6
{
    class Program
    {
        public static void isPalindrome(string a)
        {
            

        }
        static void Main(string[] args)
        {
            FileStream fl = new FileStream(@"C: \Users\Мейрамбек\Desktop\PP2\Test\Hankok\Print.txt", FileMode.Open,FileAccess.Read);
            StreamReader sr = new StreamReader(fl);
            string a = sr.ReadLine();
            isPalindrome(a);
        }
    }
}
