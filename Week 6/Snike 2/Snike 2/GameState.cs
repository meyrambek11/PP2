using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snike_2
{
    public class GameState
    {
       // Timer timer = new Timer();
        public bool work = false;
        public int score = 0;
     
        public string name;
        public GameState(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
        Worm w = new Worm('O');
        Food f = new Food('F');
        Wall b = new Wall('#');
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        public void Draw()
        {
            w.SnikeDraw();
            f.Draw();
            b.Draw();
            
        }
        void CheckWall()
        {
            if (b.CheckRandom(f.body[0]) == true || w.CheckRandom2(f.body[0]) == true)
            {
                f.Generate();
            }
        }
       void CheckGame()
        {
            if (b.CheckEnd(w.body[0]) == true || w.Checkbody(w.body[0]) == true)
            {
                work = true;
            }

        }
        void CheckFood()
        {
            if (w.CheckColision(f.body[0]) == true)
            {
                this.score += 10;
                
                w.Eat(f.body[0]);
                f.Generate();

               
            }
        }
        void AddLevels()
        {
            if(score > 10)
            {
                b.Level(b.lev + 1);
            }
            if(score > 50)
            {
                b.Level(b.lev + 2);
            }
        }
        public void PressedKey(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    w.Move(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    w.Move(0, 1);
                    break;
                case ConsoleKey.RightArrow:
                    w.Move(1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    w.Move(-1, 0);
                    break;
            }
            CheckFood();
            CheckGame();
            CheckWall();
            AddLevels();
        }
    }
     
}
