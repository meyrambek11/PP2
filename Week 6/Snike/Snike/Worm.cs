using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snike
{
    public class Worm : GameObject
    {
        public int Dx
        {
            get;
            set;
        }
        public int Dy
        {
            get;
            set;
        }
        public Worm(): base()
        {

        }
        public Worm(char sign) : base (sign)
        {
            body.Add(new Point
            {
                X = 20,
                Y = 20,
            });
            Dy = Dx = 0;
        }
        public void Move()
        {
            Clear();
            col.Clear();
            for(int i=body.Count - 1; i > 0; i--)
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            for(int i = 1; i < body.Count; i++)
            {
                col.Add(new Point
                {
                    X = body[i].X,
                    Y = body[i].Y,
                });
            }

            body[0].X = body[0].X + Dx;
            body[0].Y = body[0].Y + Dy;           
        }

        public bool Collision(Point p)
        {
            bool res = false;
            if(p.X == body[0].X && p.Y == body[0].Y)
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
                Y = p.Y
            });
        }
        public bool Check(Point p)
        {
            bool res = false;
            for(int i = 0; i < col.Count; i++)
            {
                if(p.X == col[i].X && p.Y == col[i].Y)
                {
                    res = true;
                }
            }
            return res;
        }
        
    }
}
