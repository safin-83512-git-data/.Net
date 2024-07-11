using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

To provide serialization support in the `EmployeeLib` assembly, you need to make the classes serializable and implement methods for serialization and deserialization. Additionally, you'll need to update the version number of the assembly and re-deploy it to the GAC.

### Step 1: Modify EmployeeLib for Serialization Support

1. Make the classes serializable by adding the `[Serializable]` attribute.
2.Implement methods for serialization and deserialization using the `BinaryFormatter` class.
3.Update the version number of the assembly.

Here is the modified `EmployeeLib` code with serialization support:

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace EmployeeLib
{
    [Serializable]
    public class Date
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Date() { }

        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
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
            return Day > 0 && Day <= 31 && Month > 0 && Month <= 12 && Year > 0;
        }

        public override string ToString()
        {
            return $"{Day}/{Month}/{Year}";
        }

        public static int operator -(Date d1, Date d2)
        {
            return d1.Year - d2.Year;
        }

        public static int DifferenceInYears(Date d1, Date d2)
        {
            return d1 - d2;
        }
    }

    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public bool Gender { get; set; }
        public Date Birth { get; set; }
        public string Address { get; set; }

        public Person() { }

        public Person(string name, bool gender, Date birth, string address)
        {
            Name = name;
            Gender = gender;
            Birth = birth;
            Address = address;
        }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var birthDate = new DateTime(Birth.Year, Birth.Month, Birth.Day);
                var age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-age)) age--;
                return age;
            }
        }

        public void Accept()
        {
            Console.WriteLine("Enter Name:");
            Name = Console.ReadLine();

            Console.WriteLine("Enter Gender (true for Male, false for Female):");
            Gender = Convert.ToBoolean(Console.ReadLine());

            Birth = new Date();
            Birth.AcceptDate();

            Console.WriteLine("Enter Address:");
            Address = Console.ReadLine();
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"Name: {Name}\nGender: {Gender}\nBirth: {Birth}\nAddress: {Address}\nAge: {Age}";
        }
    }

    [Serializable]
    public class Employee : Person
    {
        private static int count = 1;
        public int Id { get; private set; }
        public double Salary { get; set; }
        public string Designation { get; set; }
        public DepartmentType Dept { get; set; }

        public Employee() : base()
        {
            Id = count++;
        }

        public Employee(string name, bool gender, Date birth, string address, double salary, string designation, DepartmentType dept)
            : base(name, gender, birth, address)
        {
            Id = count++;
            Salary = salary;
            Designation = designation;
            Dept = dept;
        }

        public void Accept()
        {
            base.Accept();

            Console.WriteLine("Enter Salary:");
            Salary = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Department (IT, HR, Admin):");
            Dept = (DepartmentType)Enum.Parse(typeof(DepartmentType), Console.ReadLine(), true);
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nID: {Id}\nSalary: {Salary}\nDesignation: {Designation}\nDepartment: {Dept}";
        }
    }

    [Serializable]
    public class Manager : Employee
    {
        public double Bonus { get; set; }

        public Manager() : base()
        {
            Designation = "Manager";
        }

        public Manager(string name, bool gender, Date birth, string address, double salary, double bonus)
            : base(name, gender, birth, address, salary, "Manager", DepartmentType.IT)
        {
            Bonus = bonus;
        }

        public void Accept()
        {
            base.Accept();
            Designation = "Manager";

            Console.WriteLine("Enter Bonus:");
            Bonus = Convert.ToDouble(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nBonus: {Bonus}";
        }
    }

    [Serializable]
    public class Supervisor : Employee
    {
        public int Subordinates { get; set; }

        public Supervisor() : base()
        {
            Designation = "Supervisor";
        }

        public Supervisor(string name, bool gender, Date birth, string address, double salary, int subordinates)
            : base(name, gender, birth, address, salary, "Supervisor", DepartmentType.Admin)
        {
            Subordinates = subordinates;
        }

        public void Accept()
        {
            base.Accept();
            Designation = "Supervisor";

            Console.WriteLine("Enter Number of Subordinates:");
            Subordinates = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nNumber of Subordinates: {Subordinates}";
        }
    }

    [Serializable]
    public class WageEmp : Employee
    {
        public int Hours { get; set; }
        public int Rate { get; set; }

        public WageEmp() : base()
        {
            Designation = "Wage";
        }

        public WageEmp(string name, bool gender, Date birth, string address, double salary, int hours, int rate)
            : base(name, gender, birth, address, salary, "Wage", DepartmentType.HR)
        {
            Hours = hours;
            Rate = rate;
        }

        public void Accept()
        {
            base.Accept();
            Designation = "Wage";

            Console.WriteLine("Enter Hours:");
            Hours = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Rate:");
            Rate = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nHours: {Hours}\nRate Per Hour: {Rate}";
        }
    }

    [Serializable]
    public class Company
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public LinkedList<Employee> EmpList { get; private set; }
        public double SalaryExpense { get; private set; }

        public Company()
        {
            Name = "Unknown";
            Address = "Unknown";
            EmpList = new LinkedList<Employee>();
            SalaryExpense = 0;
        }

        public Company(string name, string address)
        {
            Name = name;
            Address = address;
            EmpList = new LinkedList<Employee>();
            SalaryExpense = 0;
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
            EmpList.AddLast(e);
            CalculateSalaryExpense();
        }

        public bool RemoveEmployee(int id)
        {
            var node = FindEmployee(id);
            if (node != null)
            {
                EmpList.Remove(node);
                CalculateSalaryExpense();
                return true;
            }
            return false;
        }

        public LinkedListNode<Employee> FindEmployee(int id)
        {
            var current = EmpList.First;
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
            SalaryExpense = 0;
            foreach (var emp in EmpList)
            {
                SalaryExpense += emp.Salary;
            }
        }

        public void PrintEmployees()
        {
            foreach (var emp in EmpList)
            {
                emp.Print();
                Console.WriteLine();
            }
        }

        public static void SerializeCompany(Company company, string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                formatter.Serialize(stream, company);
            }
            Console.WriteLine($"Company data serialized to {fileName}.");
        }

        public static Company DeserializeCompany(string fileName)
        {
            Company company = null;
            if (File.Exists(fileName))
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    company = (Company)formatter.Deserialize(stream);
                }
            }
            else
            {
                Console.WriteLine($"File {fileName} not found. Returning null.");
            }
            return company;
        }
    }

    public enum DepartmentType
    {
        IT,
        HR,
        Admin
    }
}
