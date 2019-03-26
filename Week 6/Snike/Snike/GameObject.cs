using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snike
{
    public class GameObject
    {
      
        public GameObject()
        {

        }
        public List<Point> body = new List<Point>();
        public List<PointBorder> pointBorders = new List<PointBorder>();
        public List<Point> col = new List<Point>();
        protected char sign;
        public GameObject(char sign)
        {
            this.sign = sign;
        }
        public void Draw()
        {
            for(int i = 0; i < body.Count; i++)
            {
                Console.SetCursorPosition(body[i].X, body[i].Y);
                Console.Write(sign);
            }
        }
        public void Clear()
        {
            for (int i = 0; i < body.Count; i++)
            {
                Console.SetCursorPosition(body[i].X, body[i].Y);
                Console.Write(' ');
            }
        }
        public void SnakeDraw()
        {
            for(int i = 0; i < body.Count; i++)
            {
                if(i == 0)
                {
                    Console.SetCursorPosition(body[0].X, body[0].Y);
                    Console.Write('O');
                }
                else
                {
                    Console.SetCursorPosition(body[i].X, body[i].Y);
                    Console.Write(sign);
                }
            }
        }
        public void BorderDraw()
        {
            for (int i = 0; i < pointBorders.Count; i++)
            {
                Console.SetCursorPosition(pointBorders[i].X, pointBorders[i].Y);
                Console.Write(sign);
            }
        }
    }
}
