using System;

namespace PersonClass
{
    class Date
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

    class Person
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

    class Program
    {
        static void Main(string[] args)
        {
            // Create a person object
            Person person = new Person();

            // Accept person details from user
            person.Accept();

            // Print the person details
            person.Print();
        }
    }
}
