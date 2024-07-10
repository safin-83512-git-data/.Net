using System;

namespace EmployeeLib
{
    public class WageEmp : Employee
    {
        private int hours;
        private int rate;

        public WageEmp(string Designation) : base()
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

    public class Employee
    {
    }
}
