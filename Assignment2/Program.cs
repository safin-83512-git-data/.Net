using System;

namespace CommandLineCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("Usage: CommandLineCalculator <num1> <operation> <num2>");
                return;
            }

            double num1 = Convert.ToDouble(args[0]);
            string operation = args[1];
            double num2 = Convert.ToDouble(args[2]);
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
                    return;
            }

            Console.WriteLine("Result: " + result);
        }
    }
}
