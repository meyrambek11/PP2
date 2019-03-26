using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snike
{
    public class Wall : GameObject
    {
        public Wall() : base()
        {

        }
        public Wall(char sign) : base(sign)
        {
            Level(1);
        }
        public void Level(int num)
        {
            string link = string.Format("Levels/level{0}.txt", num);
            StreamReader sr = new StreamReader(link);
            int r = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == '#')
                    {
                        body.Add(new Point
                        {
                            X = i,
                            Y = r,
                        });
                    }
                }
                r++;
            }
            sr.Close();            
        }
        public bool Collision(Point p)
        {
            bool res = false;
            for(int i = 0; i < body.Count; i++)
            {
                if(p.X == body[i].X && p.Y == body[i].Y)
                {
                    res = true;
                }
            }
            return res;
        }
        public bool Check(Point p)
        {
            bool res = false;
            for(int i = 0; i < body.Count; i++)
            {
                if(p.X == body[i].X && p.Y == body[i].Y)
                {
                    res = true;
                }
            }
            return res;
        }
    }
}
