using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Snike
{
    public class Border : GameObject
    {
        public Border() : base()
        {

        }
        public Border(char sign) : base(sign)
        {
            LevelBorder(1);
        }
        public void LevelBorder(int num)
        {
            string fs = string.Format("Levels/level{0}.txt", num);
            StreamReader sr = new StreamReader(fs);
            int r = 0;
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                for(int i = 0; i < line.Length; i++)
                {
                    if(line[i] == '*')
                    {
                        pointBorders.Add(new PointBorder
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
    }
}
