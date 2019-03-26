using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snike_2
{
    class Food : GameObject
    {
        public Food(char sign) : base(sign)
        {
            Generate();
        }
        public void Generate()
        {
            Random Rd = new Random(DateTime.Now.Second);
            body.Clear();
            body.Add(new Point
            {
                X = Rd.Next(1, 39),
                Y = Rd.Next(1, 39)
            });
        }
    }
}
