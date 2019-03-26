using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Timers;

namespace Snike_2
{

    class Program
    {          
        public static void Seralization(GameState Numbers)
        {
            FileStream fs = new FileStream("Real.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer s = new XmlSerializer(typeof(GameState));
            s.Serialize(fs, Numbers);
            Console.WriteLine("Information about your game saved in Real.txt");
            fs.Close();
        }
        public static void GAME(GameState gameState,string name)
        {

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(name + ", you can play, GooD LucK:");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
           
            while (!gameState.work)
            {
                gameState.Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                gameState.PressedKey(consoleKeyInfo);
                if (gameState.work == true)
                {
                    Console.Clear();
                    //Console.CursorVisible = false;
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" !!!Game End!!! ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Your score is " + gameState.score);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Seralization(gameState);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("If you want to continue this game preess R");
                    Console.WriteLine("If you want exit press Esc");
                    Console.ForegroundColor = ConsoleColor.White;
                    
                }
            }
        }
        static void Main(string[] args)
        {
            
                Console.WriteLine("Please, write your username:");
                string name = Console.ReadLine();
                Console.Clear();
                Console.SetCursorPosition(0, 0);      
            
                GameState gameState = new GameState();
                gameState.name = name;
           
                GAME(gameState,name);
                bool game = false;
                while (!game)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    switch (key.Key)
                    {
                        case ConsoleKey.R:
                            Console.Clear();
                            GameState gamer = new GameState();
                            gamer.name = name;
                            GAME(gamer,name);
                            break;
                        case ConsoleKey.Escape:
                            game = true;
                            break;                        
                    }
                }
            }
    }
}
