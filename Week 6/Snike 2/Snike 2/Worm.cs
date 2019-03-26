using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snike_2
{
    class Worm : GameObject
    {
        public Worm(char sign) : base(sign)
        {
            body.Add(new Point { X = 20, Y = 20 });
        }
        public void Move(int dx, int dy)
        {
            Clear();
            col.Clear();
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            for (int i = 1; i < body.Count; i++)
            {           
                col.Add(new Point
                {
                    X = body[i].X,
                    Y = body[i].Y
                });
            }
            body[0].X = body[0].X + dx;
            body[0].Y = body[0].Y + dy;
        }
       public bool CheckRandom2(Point p)
        {
            bool ans = false;
            for(int i = 0; i < col.Count; i++)
            {
                if(p.X == col[i].X && p.Y == col[i].Y)
                {
                    ans = true;
                }
            }
            return ans;
        }
        public bool Checkbody(Point p)
        {
            bool dec = false;
            for (int i = 1; i< col.Count;i++)
            {
                if(p.X == col[i].X && p.Y == col[i].Y)
                {
                    dec = true;
                }
            }
            return dec;
        }
        public bool CheckColision(Point p)
        {
            bool res = false;
            if (p.X == body[0].X && p.Y == body[0].Y)
            {
                res = true;
            }
            return res;
        }
        public void Eat(Point p)
        {
            body.Add(new Point
            {
                X = p.X,
                Y = p.Y,
            });
        }
    }
}
