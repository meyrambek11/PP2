using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Media;

namespace Snike
{
    class Program
    { 
        static void User(int view)
        {
            string link = string.Format(@"C:\Users\Мейрамбек\Desktop\PP2\Week 6\Snike\Snike\Levels\username{0}.txt", view);
            FileStream fs = new FileStream(link, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line = sr.ReadToEnd();
            Console.WriteLine(line);
            fs.Close();
            sr.Close();
        }
        static void Start()
        {
            User(1);
            for(double i = 0; i < 999999999; i++)
            {

            }
            Console.Clear();
            User(2);
            for (double i = 0; i < 99999999; i++)
            {

            }
            Console.Clear();
            User(3);
            for (double i = 0; i < 99999999; i++)
            {

            }
            Console.Clear();
            User(4);
            for (double i = 0; i < 99999999; i++)
            {

            }
            Console.Clear();
            User(5);
            for (double i = 0; i < 99999999; i++)
            {

            }
            Console.Clear();

        }
        static void Main(string[] args)
        {
            SoundPlayer sound = new SoundPlayer();
            bool game = false;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Start();
            Console.Clear();
            sound.SoundLocation = @"C:\Users\Мейрамбек\Desktop\PP2\Week 6\Snike\Snike\Levels\theme-music.wav";
            sound.Play();
            Console.SetCursorPosition(10, 20);
            Console.WriteLine("Please,write your name:");
            Console.SetCursorPosition(17, 22);
            string username = Console.ReadLine();
            Console.Clear();
            GameState gameState = new GameState();
            gameState.name = username;

            gameState.Run();
            while (!game)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.F2:
                        gameState.Stop();
                        Seralization(gameState);
                        Console.SetCursorPosition(14, 20);
                        Console.WriteLine("Game Stop:");
                        Console.SetCursorPosition(5, 22);
                        Console.WriteLine("If you want continue press <F3>");
                        Console.SetCursorPosition(5, 24);
                        Console.WriteLine("If you want exit press <Escape>");
                        break;
                    case ConsoleKey.F3:
                        Console.Clear();
                        gameState.Run();
                        gameState = Deseralization();                      
                        break;
                    default:
                        gameState.PressedKey(keyInfo);
                        break;
                    case ConsoleKey.Escape:
                        game = true;
                        Console.Clear();
                        Console.SetCursorPosition(10, 20);
                        Console.WriteLine("!!!Game Over!!!");
                        Console.SetCursorPosition(7, 22);
                        Console.WriteLine(username + ", your score is: " + gameState.score);
                        break;
                }
            }
        }
        static void Seralization(GameState gameState)
        {
            XmlSerializer xs = new XmlSerializer(typeof(GameState));
            string fname = string.Format("Seralization.xml");
            FileStream fs = new FileStream(fname, FileMode.Create, FileAccess.Write);
            xs.Serialize(fs, gameState);
            fs.Close();
        }
        static GameState Deseralization()
        {
            GameState gameState = null;
            XmlSerializer xs = new XmlSerializer(typeof(GameState));
            string fname = string.Format("Seralization.xml");
            FileStream fs = new FileStream(fname, FileMode.Open, FileAccess.Read);
            gameState = xs.Deserialize(fs) as GameState;
            return gameState;
        }
    }
}
