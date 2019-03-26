using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task_2_2
{
    [Serializable]
    public class Mark
    {
        public int point;
        public string grate;
        public Mark(int a)
        {
            this.point = a;
        }
        public Mark()
        {

        }
        public string GetGrade()
        {
            if(point >= 90 && point < 95)
            {
                grate = "A-";
                return "A-";
            }
            else if(point >= 95 && point <= 100)
            {
                grate = "A";
                return "A";
            }
            else if (point >= 85 && point <= 89)
            {
                grate = "B+";
                return "B+";
            }
            else if (point >= 80 && point <= 84)
            {
                grate = "B";
                return "B";
            }
            else if (point >= 75 && point <= 79)
            {
                grate = "B-";
                return "B-";
            }
            grate = "C";
            return "C";
        }
        public override string ToString()
        {
            String res = "Point: " + point + " grate " + GetGrade();
            return res;
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mark m = new Mark();
            m.point = int.Parse(Console.ReadLine());
            Console.WriteLine(m.ToString());
            List<Mark> l = new List<Mark>();
            l.Add(m);
            Serialization(l);
            List<Mark> l2 = Deserialization();
            for(int i = 0; i < l.Count; i++)
            {
                Console.WriteLine("Deserialization's answer: " + l2[i].ToString());
            }
            
        }
        private static void Serialization(List<Mark> KS)
        {
            FileStream fs = new FileStream("Oral.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            xs.Serialize(fs, KS);
            fs.Close();
        }
        public static List<Mark> Deserialization()
        {
            FileStream fs = new FileStream("Oral.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
            List<Mark> l = xs.Deserialize(fs) as List<Mark>;
            fs.Close();
            return l;
        }
    }
}
