using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student //We creat new class, then we add parametrs;
    {
        public string name;//We creat string for name of student; //"Public" allows гы to use parameters everywhere;
        public string id; //We creat string for ID of student;
        public string year; //We nead to read as string;
        public Student(string name, string id) //create new function for constructors; 
        {
            this.name = name; // we use "this" to indecate our string
            this.id = id;
        }
        public Student()
        {
            name = Console.ReadLine(); //read our strings;
            id = Console.ReadLine();
            year = Console.ReadLine();
        }
        public void Print() // "Void" will not return anything
        {
            int a = int.Parse(year); //We replace our string to int using "Parse";
            int c = a + 1;
            Console.WriteLine("Name: " + name); //to show our results
            Console.WriteLine("Student's ID: " + id);
            Console.WriteLine("Year of study: " + c);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Student Brother = new Student(); // to announce our class, to create new class;
            Brother.Print(); // to induce function "Print" for new class "Brother";
        }
    }
}
