using System;
using EmployeeLib;
using System.Collections.Generic;

namespace EmployeeConsoleApp
{
    class Program
    {
        static Company company = new Company();

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Remove Employee");
                Console.WriteLine("3. Find Employee by ID");
                Console.WriteLine("4. Display Company Info");
                Console.WriteLine("5. Display All Employees");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        RemoveEmployee();
                        break;
                    case 3:
                        FindEmployee();
                        break;
                    case 4:
                        DisplayCompanyInfo();
                        break;
                    case 5:
                        DisplayAllEmployees();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            } while (choice != 0);
        }

        static void AddEmployee()
        {
            Console.WriteLine("Select Employee Type:");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Supervisor");
            Console.WriteLine("3. Wage Employee");
            Console.Write("Enter your choice: ");
            int empType = Convert.ToInt32(Console.ReadLine());

            Employee emp = null;

            switch (empType)
            {
                case 1:
                    emp = new Manager();
                    break;
                case 2:
                    emp = new Supervisor();
                    break;
                case 3:
                    emp = new WageEmp();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    return;
            }

            emp.Accept();
            company.AddEmployee(emp);
        }

        static void RemoveEmployee()
        {
            Console.Write("Enter Employee ID to remove: ");
            int id = Convert.ToInt32(Console.ReadLine());
            if (company.RemoveEmployee(id))
            {
                Console.WriteLine("Employee removed successfully.");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void FindEmployee()
        {
            Console.Write("Enter Employee ID to find: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var node = company.FindEmployee(id);
            if (node != null)
            {
                node.Value.Print();
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DisplayCompanyInfo()
        {
            company.Print();
        }

        static void DisplayAllEmployees()
        {
            company.PrintEmployees();
        }
    }
}
