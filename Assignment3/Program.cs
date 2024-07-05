using System;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueCalculating = true;

            do
            {
                Console.WriteLine("Enter first number:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter operation (+, -, *, /):");
                string operation = Console.ReadLine();

                Console.WriteLine("Enter second number:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                double result = 0;
                switch (operation)
                {
                    case "+":
                        result = num1 + num2;
                        break;
                    case "-":
                        result = num1 - num2;
                        break;
                    case "*":
                        result = num1 * num2;
                        break;
                    case "/":
                        result = num1 / num2;
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        continue;
                }

                Console.WriteLine("Result: " + result);

                Console.WriteLine("Do you want to perform another calculation? (y/n)");
                continueCalculating = Console.ReadLine().ToLower() == "y";

            } while (continueCalculating);
        }
    }
}
