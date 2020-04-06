using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5Garage
{
    public static class Utils
    {
        internal static string AskForInput(string prompt)
        {
            string input;
            do
            {
                Console.WriteLine(prompt);
                input = Console.ReadLine();
                Console.WriteLine();
                if (!string.IsNullOrEmpty(input))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nPlease enter in correct form!");
                }
            } while (true);

            return input;
        }

        internal static uint AskForNumber(string prompt)
        {
            bool answer;
            uint number;
            do
            {
                string value = AskForInput(prompt);
                answer = uint.TryParse(value, out number);
                if (!answer)
                {
                    Console.WriteLine("Please enter a valid number only!");
                }
            } while (!answer);
            return number;
        }
    }
}


