using System;

namespace DateClass
{
    class Date
    {
        private int day;
        private int month;
        private int year;

        // Default constructor
        public Date()
        {
            day = 1;
            month = 1;
            year = 2000;
        }

        // Parameterized constructor
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        // Properties
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

        // Method to accept date from console
        public void AcceptDate()
        {
            Console.WriteLine("Enter Day:");
            Day = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Month:");
            Month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Year:");
            Year = Convert.ToInt32(Console.ReadLine());
        }

        // Method to print date to console
        public void PrintDate()
        {
            Console.WriteLine(ToString());
        }

        // Method to check validity of date
        public bool IsValid()
        {
            if (year < 1 || month < 1 || month > 12 || day < 1)
                return false;

            int[] daysInMonth = { 31, (IsLeapYear() ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (day > daysInMonth[month - 1])
                return false;

            return true;
        }

        // Method to check if the year is a leap year
        private bool IsLeapYear()
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }

        // Override ToString method to return date as a string
        public override string ToString()
        {
            return $"{Day:00}/{Month:00}/{Year}";
        }

        // Static method to get difference between two dates in years
        public static int DifferenceInYears(Date date1, Date date2)
        {
            return Math.Abs(date1.year - date2.year);
        }

        // Overload "-" operator to get difference between two dates in years
        public static int operator -(Date date1, Date date2)
        {
            return DifferenceInYears(date1, date2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create two date objects
            Date date1 = new Date();
            Date date2 = new Date(25, 12, 2020);

            // Accept date1 details from user
            date1.AcceptDate();

            // Print the dates
            Console.WriteLine("Date 1:");
            date1.PrintDate();
            Console.WriteLine("Date 2:");
            date2.PrintDate();

            // Check validity
            Console.WriteLine($"Date 1 is valid: {date1.IsValid()}");
            Console.WriteLine($"Date 2 is valid: {date2.IsValid()}");

            // Print difference in years
            Console.WriteLine($"Difference in years (using static method): {Date.DifferenceInYears(date1, date2)}");
            Console.WriteLine($"Difference in years (using operator overload): {date1 - date2}");
        }
    }
}
