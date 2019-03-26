using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Snike
{
    public class GameState
    {
        public Worm s = new Worm('o');
        public Food f = new Food('F');
        public Wall w = new Wall('#');
        public Border b = new Border('*');

        Timer timer = new Timer();

        public int score = 0;
        public string name;
        
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 180;
            timer.Start();

            f.Draw();
            w.Draw();
            b.BorderDraw();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.SetCursorPosition(0, 39);
            Console.Write(name + ", your score is: " + score);
            s.Clear();
            s.Move();
            s.SnakeDraw();

            CheckColission();
            Levels();
        }
        void CheckColission()
        {
            if(s.Collision(f.body[0]) == true)
            {
                score++;
                s.Eat(f.body[0]);
                f.Generate();
                f.Draw();
            }
            if (w.Collision(s.body[0]) == true || s.Check(s.body[0]) == true)
            {
                timer.Enabled = false;
                GameEnd();
            }
            if(w.Check(f.body[0]) == true || s.Check(f.body[0]) == true)
            {
                f.Generate();
                f.Draw();
                w.Draw();
                s.SnakeDraw();
            }
        }
        void Levels()
        {
            if (score > 1)
            {
                Level2();
            }
            if(score > 2)
            {
                Level3();
            }
        }
        public void Stop()
        {
            Console.Clear();
            timer.Elapsed -= Timer_Elapsed;
        }

        public void PressedKey(ConsoleKeyInfo consoleKey)
        {
            switch (consoleKey.Key)
            {
                case ConsoleKey.UpArrow:
                    s.Dx = 0;
                    s.Dy = -1;
                    break;
                case ConsoleKey.DownArrow:
                    s.Dx = 0;
                    s.Dy = 1;
                    break;
                case ConsoleKey.RightArrow:
                    s.Dx = 1;
                    s.Dy = 0;
                    break;
                case ConsoleKey.LeftArrow:
                    s.Dx = -1;
                    s.Dy = 0;
                    break;
                case ConsoleKey.Spacebar:
                    timer.Enabled = !timer.Enabled;
                    break;
            }

        }
        public void GameEnd()
        {
            Console.Clear();
            Console.SetCursorPosition(10, 20);
            Console.WriteLine("!!!Game Over!!!");
            Console.SetCursorPosition(7, 22);
            Console.WriteLine(name + ", your score is: " + score);
            Console.SetCursorPosition(8, 30);
            Console.WriteLine("For exit press Esc");
        }
        void Level2()
        {
            Console.Clear();
            w.body.Clear();
            b.pointBorders.Clear();
            w.Level(2);
            b.LevelBorder(2);
            timer.Interval = 120;
            w.Draw();
            b.BorderDraw();
            f.Draw();
            s.SnakeDraw();
            Console.SetCursorPosition(0, 39);
            Console.Write(name + ", your score: " + score);
            if (w.Collision(s.body[0]) == true || s.Check(s.body[0]) == true)
            {
                timer.Enabled = false;
                GameEnd();
            }
        }
        void Level3()
        {
            Console.Clear();
            w.body.Clear();
            b.pointBorders.Clear();
            w.Level(3);
            b.LevelBorder(3);
            timer.Interval = 100;
            w.Draw();
            b.BorderDraw();
            f.Draw();
            s.SnakeDraw();
            Console.SetCursorPosition(0, 39);
            Console.Write(name + ", your score: " + score);
            if (w.Collision(s.body[0]) == true || s.Check(s.body[0]) == true)
            {
                timer.Enabled = false;
                GameEnd();
            }

        }
    }
}
