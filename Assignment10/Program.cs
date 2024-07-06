using System;

namespace EmployeeClass
{
    // Supervisor class definition
    public class Supervisor : Employee
    {
        private int subordinates;

        // Default constructor
        public Supervisor() : base()
        {
            Designation = "Supervisor";
            subordinates = 0;
        }

        // Parameterized constructor
        public Supervisor(string name, bool gender, Date birth, string address, double salary, int subordinates)
            : base(name, gender, birth, address, salary, "Supervisor", DepartmentType.IT)
        {
            this.subordinates = subordinates;
        }

        // Property for Subordinates
        public int Subordinates
        {
            get { return subordinates; }
            set { subordinates = value; }
        }

        // Method to accept supervisor details from the console
        public new void Accept()
        {
            base.Accept();
            Designation = "Supervisor"; // Ensure designation is fixed as "Supervisor"

            Console.WriteLine("Enter Number of Subordinates:");
            Subordinates = Convert.ToInt32(Console.ReadLine());
        }

        // Method to print supervisor details to the console
        public new void Print()
        {
            Console.WriteLine(ToString());
        }

        // Override ToString method to return supervisor details as a string
        public override string ToString()
        {
            return $"{base.ToString()}\nNumber of Subordinates: {Subordinates}";
        }
    }

    // Main Program class for testing
    class Program
    {
        static void Main(string[] args)
        {
            // Create a supervisor object
            Supervisor supervisor = new Supervisor();

            // Accept supervisor details from user
            supervisor.Accept();

            // Print the supervisor details
            supervisor.Print();
        }
    }
}
