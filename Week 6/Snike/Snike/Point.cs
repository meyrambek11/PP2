using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snike
{
    public class Point
    {
        public Point()
        {

        }
        int x, y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if(value <= 0)
                {
                    x = 38;
                }
                else if(value >= 39)
                {
                    x = 1;
                }
                else
                {
                    x = value;
                }
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value <= 0)
                {
                    y = 37;
                }
                else if (value >= 38)
                {
                    y = 1;
                }
                else
                {
                    y = value;
                }
            }
        }
    }
}
