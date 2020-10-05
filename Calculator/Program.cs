using System;
using CalculatorLibrary;


namespace CalculatorProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitApp = false;
                Calculator calculator = new Calculator();

            Console.WriteLine("------------------------");
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while (!exitApp)
            {
                _ = new Result();


                Console.Write("Enter first number and press Enter: ");
                string userInput1 = Console.ReadLine();

                double convertedNumber1 = 0;
                while (!double.TryParse(userInput1, out convertedNumber1))
                {
                    Console.Write("Invalid Input Please Enter a valid integer: ");
                    userInput1 = Console.ReadLine();
                }

                Console.Write("Enter second number and press Enter: ");
                string userInput2 = Console.ReadLine();

                double convertedNumber2 = 0;
                while (!double.TryParse(userInput2, out convertedNumber2))
                {
                    Console.Write("Invalid Input Please Enter a valid integer: ");
                    userInput2 = Console.ReadLine();
                }


                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tr - Remainder/Modulo \n");
                Console.Write("Selected: ");

                string op = Console.ReadLine();

                try
                {
                    Result result = calculator.DoOperation(convertedNumber1, convertedNumber2, op);
                    if (double.IsNaN(result.result) || double.IsInfinity(result.result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine($"Result of {userInput1} {result.op} {userInput2}: {result.result:0.##}\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An unexcpected error occured.\n - Details: {e.Message}");
                }

                Console.WriteLine("------------------------\n");


                Console.Write("Press 'q' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "q")
                {
                    exitApp = true;
                    calculator.Finish();
                }
            }
            return;
        }
    }
}
