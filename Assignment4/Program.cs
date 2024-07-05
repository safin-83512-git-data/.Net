using System;

namespace StudentStructure
{
    struct Student
    {
        private string name;
        private bool gender;
        private int age;
        private int std;
        private char div;
        private double marks;

        public Student(string name, bool gender, int age, int std, char div, double marks)
        {
            this.name = name;
            this.gender = gender;
            this.age = age;
            this.std = std;
            this.div = div;
            this.marks = marks;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public int Std
        {
            get { return std; }
            set { std = value; }
        }

        public char Div
        {
            get { return div; }
            set { div = value; }
        }

        public double Marks
        {
            get { return marks; }
            set { marks = value; }
        }

        public void AcceptDetails()
        {
            Console.WriteLine("Enter Name:");
            Name = Console.ReadLine();

            Console.WriteLine("Enter Gender (true for Male, false for Female):");
            Gender = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Enter Age:");
            Age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Standard:");
            Std = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Division:");
            Div = Convert.ToChar(Console.ReadLine());

            Console.WriteLine("Enter Marks:");
            Marks = Convert.ToDouble(Console.ReadLine());
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Gender: {Gender}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Standard: {Std}");
            Console.WriteLine($"Division: {Div}");
            Console.WriteLine($"Marks: {Marks}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.AcceptDetails();
            student.PrintDetails();
        }
    }
}
