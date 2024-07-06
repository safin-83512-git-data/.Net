using System;

namespace EmployeeClass
{
    // Enum for department types
    public enum DepartmentType
    {
        HR,
        IT,
        Finance,
        Marketing,
        Sales
    }

    // Date class definition (same as in the previous examples)
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public Date()
        {
            day = 1;
            month = 1;
            year = 2000;
        }

        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public int Day
        {
            get { return day; }
            set { day = value; }
        }

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public void AcceptDate()
        {
            Console.WriteLine("Enter Day:");
            Day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Month:");
            Month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Year:");
            Year = Convert.ToInt32(Console.ReadLine());
        }

        public void PrintDate()
        {
            Console.WriteLine(ToString());
        }

        public bool IsValid()
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
                return false;

            int[] daysInMonth = { 31, (IsLeapYear() ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (day > daysInMonth[month - 1])
                return false;

            return true;
        }

        private bool IsLeapYear()
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        public override string ToString()
        {
            return $"{Day:00}/{Month:00}/{Year}";
        }

        public static int CalculateAge(Date birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate.Month > today.Month || (birthDate.Month == today.Month && birthDate.Day > today.Day))
            {
                age--;
            }
            return age;
        }
    }

    // Person class definition
    public class Person
    {
        private string name;
        private bool gender;
        private Date birth;
        private string address;

        public Person()
        {
            name = "Unknown";
            gender = true;
            birth = new Date();
            address = "Unknown";
        }

        public Person(string name, bool gender, Date birth, string address)
        {
            this.name = name;
            this.gender = gender;
            this.birth = birth;
            this.address = address;
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

        public Date Birth
        {
            get { return birth; }
            set { birth = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public int Age
        {
            get { return Date.CalculateAge(birth); }
        }

        public void Accept()
        {
            Console.WriteLine("Enter Name:");
            Name = Console.ReadLine();

            Console.WriteLine("Enter Gender (true for Male, false for Female):");
            Gender = Convert.ToBoolean(Console.ReadLine());

            Console.WriteLine("Enter Birth Date:");
            birth.AcceptDate();

            Console.WriteLine("Enter Address:");
            Address = Console.ReadLine();
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Name: {Name}\nGender: {(Gender ? "Male" : "Female")}\nBirth Date: {Birth}\nAddress: {Address}\nAge: {Age}";
        }
    }

    // Employee class definition
    public class Employee : Person
    {
        private static int count = 0; // Static count for auto-generating ID
        private int id;
        private double salary;
        private string designation;
        private DepartmentType dept;

        // Default constructor
        public Employee()
        {
            id = ++count;
            salary = 0;
            designation = "Unknown";
            dept = DepartmentType.IT;
        }

        // Parameterized constructor
        public Employee(string name, bool gender, Date birth, string address, double salary, string designation, DepartmentType dept)
            : base(name, gender, birth, address)
        {
            id = ++count;
            this.salary = salary;
            this.designation = designation;
            this.dept = dept;
        }

        // Properties
        public int Id
        {
            get { return id; }
        }

        public double Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string Designation
        {
            get { return designation; }
            set { designation = value; }
        }

        public DepartmentType Dept
        {
            get { return dept; }
            set { dept = value; }
        }

        // Method to accept employee details from the console
        public new void Accept()
        {
            base.Accept(); // Accepting Person details

            Console.WriteLine("Enter Salary:");
            Salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Designation:");
            Designation = Console.ReadLine();

            Console.WriteLine("Enter Department (HR, IT, Finance, Marketing, Sales):");
            Dept = (DepartmentType)Enum.Parse(typeof(DepartmentType), Console.ReadLine(), true);
        }

        // Method to print employee details to the console
        public new void Print()
        {
            Console.WriteLine(ToString());
        }

        // Override ToString method to return employee details as a string
        public override string ToString()
        {
            return $"{base.ToString()}\nID: {Id}\nSalary: {Salary}\nDesignation: {Designation}\nDepartment: {Dept}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create an employee object
            Employee employee = new Employee();

            // Accept employee details from user
            employee.Accept();

            // Print the employee details
            employee.Print();
        }
    }
}
