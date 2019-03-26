using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Student //We creat new class, then we add parametrs;
    {
        private string name;//We creat string for name of student; //"Public" allows гы to use parameters everywhere;
        private string id; //We creat string for ID of student;
        private int year; //We create new parametr int for year;
        public Student()
        {
            name = Console.ReadLine(); //read our strings;
            id = Console.ReadLine();
            year = int.Parse(Console.ReadLine());  
            year++;
        }
        public Student(string name, string id) //create new function for constructors; 
        {
            this.name = name; // we use "this" to indecate our string
            this.id = id;
            ToYear();
            
        }
        public void ToYear() //"Void" will not return anything, we give to year new value;
        {
            year = 1;
            year++;
        }
       
        
        public void Print() // "Void" will not return anything
        {
            Console.WriteLine("Name: " + name); //to show our results
            Console.WriteLine("Student's ID: " + id);
            Console.WriteLine("Year of study: " + year);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Student Brother = new Student(); // to announce our class, to create new class;
            Brother.Print(); // to induce function "Print" for new class "Brother";
            Console.WriteLine();

            Student Meyrambek = new Student("Meyrambek", "18BD115315"); //Values for constuction;
            Meyrambek.Print(); // to induce function "Print" for new class "Meyrambek"
            
            
        }
    }
}
