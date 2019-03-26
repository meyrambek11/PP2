using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task_1_1
{
   public class Numbers
    {
        public int a;
        public int b;
        public double t;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Numbers Num = new Numbers();
            Num.a = int.Parse(Console.ReadLine());
            Num.b = int.Parse(Console.ReadLine());
            Num.t = Num.a + Num.b;
            Seralization(Num);
           Numbers Num2 =  Deseralization();
            Console.WriteLine("Deseralization's answer: " + Num2.a + " + " + Num2.b + " = " + Num2.t);
           
        }
        public static void Seralization(Numbers Num)
        {
            FileStream fs = new FileStream("Real.txt", FileMode.Create, FileAccess.Write);
            XmlSerializer s = new XmlSerializer(typeof(Numbers));
            s.Serialize(fs, Num);
            fs.Close();
        }
        public static Numbers Deseralization()
        {
            FileStream fs = new FileStream("Real.txt", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Numbers));
            Numbers Num = xs.Deserialize(fs) as Numbers;
            fs.Close();
            return Num;
        }
    }
}
