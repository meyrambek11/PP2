using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snike
{
    public class Food : GameObject
    {
        public Food() : base()
        {

        }
        public Food(char sign) : base(sign)
        {
            Generate();
        }
        public void Generate()
        {
            Random rd = new Random(DateTime.Now.Second);
            body.Clear();
            body.Add(new Point
            {
                X = rd.Next(1, 38),
                Y = rd.Next(1, 37)
            });
        }
    }
}
