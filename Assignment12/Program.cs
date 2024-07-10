using System;
using System.Collections.Generic;

namespace EmployeeLib
{
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
