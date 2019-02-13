using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _12
{
    enum FSIMode
    {
        DirectoryInfo = 1,
        File = 2
    }
    class Lawer
    {
        public DirectoryInfo[] DirCon
        {
            get;
            set;
        }
        public FileInfo[] FileCon
        {
            get;
            set;
        }
        public int selectedIndex
        {
            get;
            set;
        }
        public void Draw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for (int i = 0; i < DirCon.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(DirCon[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int j = 0; j < FileCon.Length; j++)
            {
                if (j == selectedIndex - DirCon.Length)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(FileCon[j].Name);
            }
            Console.ForegroundColor = ConsoleColor.White;

        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo Dir = new DirectoryInfo(@"C:\Users\Мейрамбек\Desktop\Новая папка");
            Lawer l = new Lawer
            {
                DirCon = Dir.GetDirectories(),
                FileCon = Dir.GetFiles(),
                selectedIndex = 0
            };
            l.Draw();
            Stack<Lawer> control = new Stack<Lawer>();
            control.Push(l);
            FSIMode Mod = FSIMode.DirectoryInfo;

            bool work = false;
            while (!work)
            {
                if (Mod == FSIMode.DirectoryInfo)
                {
                    control.Peek().Draw();
                }
                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (control.Peek().selectedIndex > 0)
                        {
                            control.Peek().selectedIndex--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (control.Peek().selectedIndex < control.Peek().DirCon.Length + control.Peek().FileCon.Length - 1)
                        {
                            control.Peek().selectedIndex++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        int index = control.Peek().selectedIndex;
                        if(index < control.Peek().DirCon.Length)
                        {
                            DirectoryInfo d = control.Peek().DirCon[index];
                            Lawer nl = new Lawer
                            {
                                DirCon = d.GetDirectories(),
                                FileCon = d.GetFiles(),
                                selectedIndex = 0
                            };
                            control.Push(nl);
                        }
                        else
                        {
                            FileStream fl = new FileStream(control.Peek().FileCon[index - control.Peek().DirCon.Length].FullName, FileMode.Open, FileAccess.Read);
                            StreamReader sr = new StreamReader(fl);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Clear();
                            Console.Write(sr.ReadToEnd());
                        }
                        break;
                }
            }

        }
    }
}
