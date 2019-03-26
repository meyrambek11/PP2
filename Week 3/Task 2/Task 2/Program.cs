using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Task_2
{
    enum FSIMode // helps us save information separately, and we can then use it as a reference;
    {
        DirectoryInfo = 1,
        File = 2
    }
    class Lawer
    {
        public DirectoryInfo[] DirCon //We create new array for folders which called "DirCon";
        {
            get;//following this operation we can read values; 
            set;//following this operation we can write to values something;
        }
        public FileInfo[] FileCon //We create new array for files which called "FileCon";
        {
        
            get;//following this operation we can read values; 
            set;//following this operation we can write to values something;
        }

        public int SelectedIndex
        {
            get;//following this operation we can read values; 
            set;//following this operation we can write to values something;
        }
        public void Draw()// We create new function to show information and to do it any operation;
        {
            Console.BackgroundColor = ConsoleColor.Black;//Cleared information painted color black;
            Console.Clear();//We always cleared old information;
            for (int i = 0; i < DirCon.Length; i++)
            {
                if (i == SelectedIndex) //If we indicate Selected Index;
                {
                    Console.BackgroundColor = ConsoleColor.Red;//We paint indicated folder to red color;
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;//We paint another folders to black color;
                Console.WriteLine(i + 1 + ". " + DirCon[i].Name);//We show name of folders in array;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;//We paint another files to yellow color;
            for (int j = 0; j < FileCon.Length; j++)
            {
                if (j + DirCon.Length == SelectedIndex)//If we indicate Selected Index;
                {
                    Console.BackgroundColor = ConsoleColor.Red;//We paint indicated file to red color;
                }
                else
                    Console.BackgroundColor = ConsoleColor.Black;//We paint another files to black color;
                Console.WriteLine(j + DirCon.Length + 1 + ". " + FileCon[j].Name);//We show name of files in array;
            }
            Console.ForegroundColor = ConsoleColor.White;//We paint another folders to white color;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo Dr = new DirectoryInfo(@"C:\Users\Мейрамбек\Desktop\for operation");
            //DirectoryInfo contains a set of members used to create new folders, Here we indicated the way;
            Lawer l = new Lawer// We create new class and indicate folders,files int Index; 
            {
                DirCon = Dr.GetDirectories(),//We indicate adrress for array "DirCon" in Director "Dr" for folders;
                FileCon = Dr.GetFiles(),//We indicate adrress for array "FileCon" in Director "Dr" for files;
                SelectedIndex = 0// Initially selected index equal to 0;
            };
            l.Draw(); // We invite function "Draw" for class "l";

            FSIMode Mod = FSIMode.DirectoryInfo;// We create new FSI(enum) for folders;

            Stack<Lawer> control = new Stack<Lawer>();//We create new stack;
            control.Push(l);//We add class "l" to stack;

            bool work = false;//We creat bool to work with stack;
            while (!work)
            {
                if (Mod == FSIMode.DirectoryInfo)//If FSI(enum) is an Folder;
                {
                    control.Peek().Draw();//We invite for stack the function "Draw";
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Open: Enter || Back: Backspace || Deleted: D || Rename: R");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                ConsoleKeyInfo key = Console.ReadKey(); //ConsoleKeyInfo  is returned to us in response to calling the Console.ReadKey method;

                switch (key.Key) //After the switch keyword in brackets is a compared expression.And if a match is found, a certain case block will be executed;
                {
                    case ConsoleKey.UpArrow://For button "UpArrow";
                        if (control.Peek().SelectedIndex > 0)
                        {
                            control.Peek().SelectedIndex--;//Our SelectedIndex will rises;
                        }
                        break;
                    case ConsoleKey.DownArrow://For button "DownArrow";
                        if (control.Peek().DirCon.Length + control.Peek().FileCon.Length - 1 > control.Peek().SelectedIndex)
                        {
                            control.Peek().SelectedIndex++;//Our SelectedIndex will decrease;
                        }
                        break;
                    case ConsoleKey.Enter: //For button "Enter";
                        int index = control.Peek().SelectedIndex;
                        int a = control.Peek().DirCon.Length; //Sum of folders;
                        int b = control.Peek().FileCon.Length;//Sum of files;
                        if (index < a) //If information is an folder;
                        {
                            DirectoryInfo d = control.Peek().DirCon[index]; //We create new folder for new class and indicate the index(way);
                            Lawer nl =  new Lawer { //We create new class;
                            
                                DirCon = d.GetDirectories(),//We indicate adrress for array "DirCon" in Director "d" for folders;
                                FileCon = d.GetFiles(),//We indicate adrress for array "FileCon" in Director "d" for files;
                                SelectedIndex = 0 // Initially selected index equal to 0;
                            };
                            control.Push(nl);//We add class "nl" to stack;
                        }
                        else  
                        {
                            Mod = FSIMode.File; //If information is an file;
                            FileStream fs = new FileStream(control.Peek().FileCon[index - a].FullName, FileMode.Open, FileAccess.Read);
                            //FileStream provides options for reading from a file and writing to a file. Here we indicated the path, opened the file and read the information;
                            StreamReader sr = new StreamReader(fs); //Streamreader is a stream that allows us to count information;
                            Console.BackgroundColor = ConsoleColor.Black; //We paint text in the file;
                            Console.ForegroundColor = ConsoleColor.White;//We paint text in the file;
                            Console.Clear(); //We must cleaned old information;
                            Console.WriteLine(sr.ReadToEnd()); //We show all text in file;
                            fs.Close();// We closed the FileStream;
                            sr.Close();//We must closed the stream, Because it may be available for other operations;
                        }
                        break;
                    case ConsoleKey.Backspace: //For button "Backspace";
                        if (Mod == FSIMode.DirectoryInfo) //If information is an folder;
                        {
                            control.Pop();//We remove last window;
                        }
                        else
                        {
                            Mod = FSIMode.DirectoryInfo;//We invide our initially folder;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;
                    case ConsoleKey.D:
                        index = control.Peek().SelectedIndex;
                        a = control.Peek().DirCon.Length;//Sum of folders;
                        b = control.Peek().FileCon.Length;//Sum of files;
                        if (index < a) //If information is an folders;
                        {
                            Directory.Delete(control.Peek().DirCon[index].FullName,true);//We delete specified folders and indicate way for adress;
                        }
                        else // If information is an files;
                        {
                            File.Delete(control.Peek().FileCon[index - a].FullName); //We delete specified files and indicate way for adress;
                        }
                        control.Pop();//We remove last window;
                        if (control.Count == 0)//If we are in initial folder;
                        {
                            Lawer nl = new Lawer // We create new class and indicate folders, files int Index; 
                            {
                                DirCon = Dr.GetDirectories(),//We indicate adrress for array "DirCon" in Director "Dr" for folders;
                                FileCon = Dr.GetFiles(),//We indicate adrress for array "FileCon" in Director "Dr" for files;
                                SelectedIndex = 0 // Initially selected index equal to 0;
                            };
                            control.Push(nl); //We add class "nl" to stack;
                        }
                        else //If we aren't in initial folder;
                        {
                            index = control.Peek().SelectedIndex;
                            DirectoryInfo di = control.Peek().DirCon[index];//We create new folder for new class and indicate the index(way);
                            Lawer nl = new Lawer //We create new class;
                            {
                                DirCon = di.GetDirectories(),//We indicate adrress for array "DirCon" in Director "di" for folders
                                FileCon = di.GetFiles(),//We indicate adrress for array "FileCon" in Director "di" for files;
                                SelectedIndex = 0 // Initially selected index equal to 0;
                            };
                            control.Push(nl); //We add class "nl" to stack;
                        }
                        break;
                    case ConsoleKey.R: //For button "R";
                        index = control.Peek().SelectedIndex;
                        a = control.Peek().DirCon.Length;//Sum of folders;
                        b = control.Peek().FileCon.Length;//Sum of files;
                        string name, fulname; // We create new string;
                        int selectedMode;//We create new int;
                        if (index < a) // If information is an folder;
                        {
                            name = control.Peek().DirCon[index].Name; //We read specified folder's name as string;
                            fulname = control.Peek().DirCon[index].FullName; //We read specified folder's fulname as string;
                            selectedMode = 1;
                        }
                        else
                        {
                            name = control.Peek().FileCon[index - a].Name; //We read specified file's name as string;
                            fulname = control.Peek().FileCon[index - a].FullName; //We read specified file's fulname as string;
                            selectedMode = 2;
                        }
                        fulname = fulname.Remove(fulname.Length - name.Length); // We create new fulname's adress;
                        Console.WriteLine("ename: Please write a new name:");
                        string newname = Console.ReadLine(); // We must write new file or folder name;
                        if (selectedMode == 1) // If information is an folder;
                        {
                            new DirectoryInfo(control.Peek().DirCon[index].FullName).MoveTo(fulname + newname);//We move specified folder's name to new folder name;
                        }
                        else // If information is an file;
                        {
                            new FileInfo(control.Peek().FileCon[index - a].FullName).MoveTo(fulname + newname);//We move specified file's name to new file name;
                        }
                        control.Pop();//We remove last window;
                        if (control.Count == 0) //If we are in initial folder;
                        {
                            Lawer nl = new Lawer // We create new class and indicate folders, files int Index; 
                            {
                                DirCon = Dr.GetDirectories(), //We indicate adrress for array "DirCon" in Director "Dr" for folders;
                                FileCon = Dr.GetFiles(), //We indicate adrress for array "FileCon" in Director "Dr" for files;
                                SelectedIndex = 0 // Initially selected index equal to 0;
                            };
                            control.Push(nl); //We add class "nl" to stack;
                        }
                        else //If we aren't in initial folder;
                        {
                            index = control.Peek().SelectedIndex;
                            DirectoryInfo di = control.Peek().DirCon[index]; //We create new folder for new class and indicate the index(way);
                            Lawer nl = new Lawer //We create new class;
                            {
                                DirCon = di.GetDirectories(), //We indicate adrress for array "DirCon" in Director "di" for folders
                                FileCon = di.GetFiles(), //We indicate adrress for array "FileCon" in Director "di" for files;
                                SelectedIndex = 0 // Initially selected index equal to 0;
                            };
                            control.Push(nl); //We add class "nl" to stack;
                        }
                        break;


                    case ConsoleKey.Escape: //For button "Escape";
                        work = true; //We closed while operation;
                        break;
                }

            }

        }
    }
}
