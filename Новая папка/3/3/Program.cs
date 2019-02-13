using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _3
{
    class Program
    {
        

        static void Main(string[] args)
        {
            DirectoryInfo Dr = new DirectoryInfo(@"C:\Users\Мейрамбек\Desktop\PP2");
            //FileSystemInfo[] x = Dr.GetFileSystemInfos();
            var x = Dr.GetFileSystemInfos();
            /*for(int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i].Name);
            }*/
            foreach(var t in x)
            {
                Console.WriteLine(t.Name);
            }

        }
    }
}
