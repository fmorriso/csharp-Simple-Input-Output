#define DO_THIS
using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("What is your first name?");
        string? firstName = null;
        while (string.IsNullOrEmpty(firstName))
        {
            firstName = Console.ReadLine();
            if (string.IsNullOrEmpty(firstName)) Console.WriteLine("No response dectected. Try again");
        }
        Console.WriteLine($"Hello {firstName}");

        // determine if eligible to vote using age
        int age = GetValidAge();
        if (age >= 18)
        {
            Console.WriteLine($"Hello {firstName}! You can vote");
        }
        else
        {
            Console.WriteLine($"Hello {firstName}! Sorry you can't vote");
        }

        // determine eligibility to run for President of the United States
        bool isUsCitizen = GetCitizenship();
        if (age >= 35 && isUsCitizen)
        {
            Console.WriteLine("You are eligible to run for President");
        }
        else
        {
            if (isUsCitizen)
            {
                Console.WriteLine($"You are too young ({age}) to run for President");
            }
            else
            {
                Console.WriteLine("You must be a US citizen to run for President");
            }
        }
#if DO_THIS
        Console.WriteLine("Press any key to quit");
        Console.ReadKey();
#else
        Console.WriteLine("else");
        Console.ReadKey();
#endif

    }

    /// <summary>
    /// Prompts for whether or not a person is a citizen of the United States of America
    /// </summary>
    /// <returns>True if the person is a citizen; False if not a citizen.</returns>
    private static bool GetCitizenship()
    {
        bool result = true;
        bool needResponse = true;
        while (needResponse)
        {
            Console.WriteLine("Are you a United States citizen (Y/N)?");
            string? response = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(response))
            {                
                Console.WriteLine("Invalid response.  Valid responses are Y or N");
            }
            else if (response.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                result = true;
                needResponse = false;
            }
            else if (response.Equals("N", StringComparison.OrdinalIgnoreCase))
            {
                result = false;
                needResponse = false;
            }
            else
            {
                Console.WriteLine("Invalid response.  Valid responses are Y or N");
            }
        }


        return result;
    }

    private static int GetValidAge()
    {
        int age = 0;
        bool needValidAge = true;
        const int MINAGE = 1, MAXAGE = 130;

        while (needValidAge)
        {
            try
            {
                Console.WriteLine("Enter your age: ");
                string? resp = null;
                while (resp == null)
                {
                    resp = Console.ReadLine();
                    if (string.IsNullOrEmpty(resp)) throw new Exception("No response dectected. Try again");
                }
                age = Convert.ToInt32(resp);
                if (age < MINAGE || age > MAXAGE)
                {
                    throw new Exception($"{age} is outside the allowable age range of {MINAGE} to {MAXAGE}. Try again.");
                }
                needValidAge = false;
            }
            catch (FormatException)
            {
                Console.WriteLine("Only whole numbers are allowed. Try again.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        return age;
    }
}