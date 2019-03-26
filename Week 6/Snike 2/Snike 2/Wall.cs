using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snike_2
{
    class Wall : GameObject
    {
        public int lev = 1;
        public Wall(char sign) : base(sign)
        {
            Level(lev);
        }
        public void Level(int level)
        {
            string name = string.Format("Levels/level{0}.txt", level);
            StreamReader sr = new StreamReader(name);
            int r = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                for (int i = 0; i < line.Length; ++i)
                {
                    if (line[i] == '#')
                    {
                        body.Add(new Point
                        {
                            X = i,
                            Y = r
                        });
                    }
                }
                r++;
            }
            sr.Close();

        }
        public bool CheckEnd(Point p)
        {
            bool ans = false;
            for (int i = 0; i < body.Count; i++)
            {
                if (p.X == body[i].X && p.Y == body[i].Y)
                {
                    ans = true;
                }
            }
            return ans;
        }
        public bool CheckRandom(Point p)
        {
            bool ans = false;
            for (int i = 0; i < body.Count; i++)
            {
                if (p.X == body[i].X && p.Y == body[i].Y)
                {
                    ans = true;
                }
            }
            return ans;
        }


    }
}
