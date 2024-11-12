using System;

class Program
{
    // Main method - entry point of the program
    static void Main()
    {
        int multiplicand = GetValidInput("Enter the multiplicand (positive integer <= 10,000): ");
        int multiplier = GetValidInput("Enter the multiplier (positive integer <= 10,000): ");

        int product = Multiply(multiplicand, multiplier);
        DisplayProduct(multiplicand, multiplier, product);
    }

    // Get a valid positive integer input (<= 10,000) from the user
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

    // Function to multiply two numbers using repeated addition
    static int Multiply(int multiplicand, int multiplier)
    {
        int product = 0;

        // Use repeated addition for multiplication
        for (int i = 0; i < multiplier; i++)
        {
            product += multiplicand;
        }

        return product;
    }

    // Display the result of the multiplication
    static void DisplayProduct(int multiplicand, int multiplier, int product)
    {
        Console.WriteLine($"The product of {multiplicand} and {multiplier} is: {product}");
    }
}
