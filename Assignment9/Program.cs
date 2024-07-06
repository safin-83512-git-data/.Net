using System;

namespace EmployeeClass
{
    // Manager class definition
    public class Manager : Employee
    {
        private double bonus;

        // Default constructor
        public Manager() : base()
        {
            Designation = "Manager";
            bonus = 0;
        }

        // Parameterized constructor
        public Manager(string name, bool gender, Date birth, string address, double salary, double bonus)
            : base(name, gender, birth, address, salary, "Manager", DepartmentType.IT)
        {
            this.bonus = bonus;
        }

        // Property for Bonus
        public double Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        // Method to accept manager details from the console
        public new void Accept()
        {
            base.Accept();
            Designation = "Manager"; // Ensure designation is fixed as "Manager"

            Console.WriteLine("Enter Bonus:");
            Bonus = Convert.ToDouble(Console.ReadLine());
        }

        // Method to print manager details to the console
        public new void Print()
        {
            Console.WriteLine(ToString());
        }

        // Override ToString method to return manager details as a string
        public override string ToString()
        {
            return $"{base.ToString()}\nBonus: {Bonus}";
        }
    }

    // Main Program class for testing
    class Program
    {
        static void Main(string[] args)
        {
            // Create a manager object
            Manager manager = new Manager();

            // Accept manager details from user
            manager.Accept();

            // Print the manager details
            manager.Print();
        }
    }
}
