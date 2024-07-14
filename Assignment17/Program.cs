using System;
using System.Collections.Generic;

namespace EmployeeLib
{
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

        public static int CalculateDifference(Date date1, Date date2)
        {
            return Math.Abs(date1.Year - date2.Year);
        }

        public static int operator -(Date date1, Date date2)
        {
            return CalculateDifference(date1, date2);
        }
    }

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

    public enum DepartmentType
    {
        HR,
        IT,
        Finance,
        Marketing,
        Sales
    }

    public class Employee : Person
    {
        private static int count = 0;
        private int id;
        private double salary;
        private string designation;
        private DepartmentType dept;

        public Employee() : base()
        {
            id = ++count;
            salary = 0;
            designation = "Unknown";
            dept = DepartmentType.IT;
        }

        public Employee(string name, bool gender, Date birth, string address, double salary, string designation, DepartmentType dept)
            : base(name, gender, birth, address)
        {
            id = ++count;
            this.salary = salary;
            this.designation = designation;
            this.dept = dept;
        }

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

        public new void Accept()
        {
            base.Accept();

            Console.WriteLine("Enter Salary:");
            Salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Department (0: HR, 1: IT, 2: Finance, 3: Marketing, 4: Sales):");
            Dept = (DepartmentType)Convert.ToInt32(Console.ReadLine());
        }

        public new void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nID: {Id}\nSalary: {Salary}\nDesignation: {Designation}\nDepartment: {Dept}";
        }
    }

    public class Manager : Employee
    {
        private double bonus;

        public Manager() : base()
        {
            Designation = "Manager";
            bonus = 0;
        }

        public Manager(string name, bool gender, Date birth, string address, double salary, double bonus)
            : base(name, gender, birth, address, salary, "Manager", DepartmentType.IT)
        {
            this.bonus = bonus;
        }

        public double Bonus
        {
            get { return bonus; }
            set { bonus = value; }
        }

        public new void Accept()
        {
            base.Accept();
            Designation = "Manager";

            Console.WriteLine("Enter Bonus:");
            Bonus = Convert.ToDouble(Console.ReadLine());
        }

        public new void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nBonus: {Bonus}";
        }
    }

    public class Supervisor : Employee
    {
        private int subordinates;

        public Supervisor() : base()
        {
            Designation = "Supervisor";
            subordinates = 0;
        }

        public Supervisor(string name, bool gender, Date birth, string address, double salary, int subordinates)
            : base(name, gender, birth, address, salary, "Supervisor", DepartmentType.IT)
        {
            this.subordinates = subordinates;
        }

        public int Subordinates
        {
            get { return subordinates; }
            set { subordinates = value; }
        }

        public new void Accept()
        {
            base.Accept();
            Designation = "Supervisor";

            Console.WriteLine("Enter Number of Subordinates:");
            Subordinates = Convert.ToInt32(Console.ReadLine());
        }

        public new void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nSubordinates: {Subordinates}";
        }
    }

    public class WageEmp : Employee
    {
        private int hours;
        private int rate;

        public WageEmp() : base()
        {
            Designation = "Wage";
            hours = 0;
            rate = 0;
        }

        public WageEmp(string name, bool gender, Date birth, string address, double salary, int hours, int rate)
            : base(name, gender, birth, address, salary, "Wage", DepartmentType.IT)
        {
            this.hours = hours;
            this.rate = rate;
        }

        public int Hours
        {
            get { return hours; }
            set { hours = value; }
        }

        public int Rate
        {
            get { return rate; }
            set { rate = value; }
        }

        public new void Accept()
        {
            base.Accept();
            Designation = "Wage";

            Console.WriteLine("Enter Hours Worked:");
            Hours = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Rate Per Hour:");
            Rate = Convert.ToInt32(Console.ReadLine());
        }

        public new void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nHours Worked: {Hours}\nRate Per Hour: {Rate}";
        }
    }

    public class Company
    {
        private string name;
        private string address;
        private LinkedList<Employee> empList;
        private double salaryExpense;

        public Company()
        {
            name = "Unknown";
            address = "Unknown";
            empList = new LinkedList<Employee>();
            salaryExpense = 0;
        }

        public Company(string name, string address)
        {
            this.name = name;
            this.address = address;
            empList = new LinkedList<Employee>();
            salaryExpense = 0;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public LinkedList<Employee> EmpList
        {
            get { return empList; }
        }

        public double SalaryExpense
        {
            get { return salaryExpense; }
        }

        public void Accept()
        {
            Console.WriteLine("Enter Company Name:");
            Name = Console.ReadLine();

            Console.WriteLine("Enter Company Address:");
            Address = Console.ReadLine();
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Company Name: {Name}\nAddress: {Address}\nMonthly Salary Expense: {SalaryExpense}";
        }

        public void AddEmployee(Employee e)
        {
            empList.AddLast(e);
            CalculateSalaryExpense();
        }

        public bool RemoveEmployee(int id)
        {
            var node = FindEmployee(id);
            if (node != null)
            {
                empList.Remove(node);
                CalculateSalaryExpense();
                return true;
            }
            return false;
        }

        public LinkedListNode<Employee> FindEmployee(int id)
        {
            var current = empList.First;
            while (current != null)
            {
                if (current.Value.Id == id)
                {
                    return current;
                }
                current = current.Next;
            }
            return null;
        }

        public void CalculateSalaryExpense()
        {
            salaryExpense = 0;
            foreach (var emp in empList)
            {
                salaryExpense += emp.Salary;
            }
        }

        public void PrintEmployees()
        {
            foreach (var emp in empList)
            {
                emp.Print();
                Console.WriteLine();
            }
        }
    }
}
