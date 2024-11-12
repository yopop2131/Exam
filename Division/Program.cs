using System;

class Program
{
    static void Main()
    {
        int dividend = GetValidInput("Enter the dividend (positive integer <= 10,000): ");
        int divisor = GetValidInput("Enter the divisor (positive integer <= 10,000): ");

        if (dividend < divisor)
        {
            Console.WriteLine("Error: The divisor must not be greater than the dividend.");
            return;
        }

        (int quotient, int remainder) = DivideWithoutOperator(dividend, divisor);
        DisplayResult(quotient, remainder);
    }

    // Method to get a valid input from the user
    static int GetValidInput(string prompt)
    {
        int validNumber;
        while (true)
        {
            Console.Write(prompt);
            string userInput = Console.ReadLine();

            // Try to parse as an integer
            if (int.TryParse(userInput, out validNumber))
            {
                if (validNumber > 0 && validNumber <= 10000)
                {
                    return validNumber;
                }
                else
                {
                    Console.WriteLine("Error: The number must be between 1 and 10,000.");
                }
            }
            // Try to parse as a decimal, and round it to the nearest integer
            else if (decimal.TryParse(userInput, out decimal decimalInput))
            {
                validNumber = (int)Math.Round(decimalInput);
                if (validNumber > 0 && validNumber <= 10000)
                {
                    return validNumber;
                }
                else
                {
                    Console.WriteLine("Error: The rounded number must be between 1 and 10,000.");
                }
            }
            else
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid positive number.");
            }
        }
    }

    // Method to perform division using repeated subtraction
    static (int quotient, int remainder) DivideWithoutOperator(int dividend, int divisor)
    {
        int quotient = 0;
        int remainder = dividend;

        // Repeated subtraction to find quotient
        while (remainder >= divisor)
        {
            remainder -= divisor;
            quotient++;
        }

        return (quotient, remainder);
    }

    // Method to display the quotient and remainder
    static void DisplayResult(int quotient, int remainder)
    {
        Console.WriteLine($"The quotient is: {quotient}");
        Console.WriteLine($"The remainder is: {remainder}");
    }
}
