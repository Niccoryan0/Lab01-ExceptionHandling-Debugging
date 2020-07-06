using System;

namespace Lab01a_ExceptionHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartSequence();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops! Looks like there was some kind of error.");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("That's all folks! Thanks for visiting.");
            }
        }

        static void StartSequence()
        {
            Console.WriteLine("Please enter any number greater than 0");
            string userChoiceStr = Console.ReadLine();
            int userChoice = Convert.ToInt32(userChoiceStr);
            int[] newArr = new int[userChoice];
            Populate(newArr);
            // GetSum(arr);
            // GetProduct(arr);
            // GetQuotient(arr);
        }


    }
}
