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
            int[] popArr = Populate(newArr);
            // int sumResult = GetSum(popArr);
            // int prodResult = GetProduct(popArr, prodInt);
            // int quotResult = GetQuotient(prodResult);
            Console.WriteLine($"The array you made is size {userChoice}");
            Console.WriteLine($"The numbers in it are: {string.Join(", ", newArr)}");
            // Console.WriteLine($"It's sum is {sumResult}");
            // Console.WriteLine($"{sumResult} times {prodInt} = {prodResult}");
            // Console.WriteLine($"{prodResult} divided by {quotInt} = {quotResult}");
        }

        static 

    }
}
