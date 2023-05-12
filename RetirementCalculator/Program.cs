using System.Text.RegularExpressions;

namespace RetirementCalculator;

internal class RetirementCalculator
{
    private static void Main()
    {
        bool isValidInput;
        string? firstName = null;
        string? lastName = null;
        var age = 0;

        // Output containing a small description of the application for the user
        Console.WriteLine(
            "Hello! This application will calculate how many years remain until you enter retirement.");
        Console.WriteLine("In order to make this calculation, we will need to collect some information about you.");

        /* Do statement that sends the user input to the ValidateInput() method. The input is saved and the loop is
         exited upon valid input. */
        do
        {
            Console.Write("Enter your first name: ");
            var input = Console.ReadLine();

            isValidInput = ValidateInput(input, @"^\p{L}+$",
                "Error: Your first name must only contain letters. Please try again.");

            if (isValidInput) firstName = input;
        } while (!isValidInput);

        do
        {
            Console.Write("Enter your last name: ");
            var input = Console.ReadLine();

            isValidInput = ValidateInput(input, @"^\p{L}+$",
                "Error: Your last name must only contain letters. Please try again.");

            if (isValidInput) lastName = input;
        } while (!isValidInput);

        do
        {
            Console.Write("Enter your age: ");
            var input = Console.ReadLine();

            isValidInput = ValidateInput(input, @"^\d+$",
                "Error: Your age must only contain numbers. Please try again.");

            if (isValidInput) age = int.Parse(input!);
        } while (!isValidInput);

        var (yearsLeft, retireAge) = CalculateRetirementYears(age);
        
        Console.WriteLine($"The calculation is done, {firstName} {lastName}!");

        if (age < retireAge)
            Console.WriteLine($"It looks like you have {yearsLeft} years left, until you can retire.");
        else if (age > retireAge)
            Console.WriteLine($"It looks like you have been retired for {yearsLeft} years.");
        else
            Console.WriteLine("It looks like you will be retiring this year.");
    }

    /* This method takes a string input and an error message as parameters, and returns a
     boolean indicating whether the input is valid. */
    private static bool ValidateInput(string? input, string regex, string errorMessage)
    {
        if (!string.IsNullOrEmpty(input) && Regex.IsMatch(input, regex)) return true;

        Console.WriteLine(errorMessage);
        return false;
    }

    private static (int yearsLeft, int retireAge) CalculateRetirementYears(int currentAge)
    {
        const int retireAge = 65; // The age we assume the user qualifies for retirement
        var yearsLeft = retireAge - currentAge;

        if (yearsLeft < 0) yearsLeft = Math.Abs(yearsLeft);

        return (yearsLeft, retireAge);
    }
}