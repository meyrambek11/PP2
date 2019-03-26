using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snike
{
   public class PointBorder
    {
        public PointBorder()
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
                if (value < 0)
                {
                    x = 39;
                }
                else if (value >= 40)
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
                if (value < 0)
                {
                    y = 39;
                }
                else if (value >= 40)
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
