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
            try
            {
                Console.WriteLine("Please enter any number greater than 0");
                string userChoiceStr = Console.ReadLine();
                int userChoice = Convert.ToInt32(userChoiceStr);
                int[] newArr = new int[userChoice];
                int[] popArr = Populate(newArr);
                int sumResult = GetSum(popArr);
                int prodResult = GetProduct(popArr, sumResult);
                decimal quotResult = GetQuotient(prodResult);
                Console.WriteLine($"The array you made is size {userChoice}");
                Console.WriteLine($"The numbers in it are: {string.Join(", ", newArr)}");
                Console.WriteLine($"It's sum is {sumResult}");
                Console.WriteLine($"{sumResult} times {prodResult/sumResult} = {prodResult}");
                Console.WriteLine($"{prodResult} divided by {prodResult / quotResult} = {Decimal.Round(quotResult, 2)}");
            }
            catch (FormatException f)
            {
                Console.WriteLine(f.Message);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static int[] Populate(int[] myArr)
        {
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.WriteLine($"Please enter a number: ({i+1} of {myArr.Length})");
                // Get a number from the user for each position in the array, convert them to ints, and populate the array
                string userChoice = Console.ReadLine();
                int numChoice = Convert.ToInt32(userChoice);
                myArr[i] = numChoice;
            }
            return myArr;
        }

        static int GetSum(int[] myArr)
        {
            int sum = 0;
            foreach (int num in myArr)
            {
                sum += num;
            }
            return sum;
        }

        static int GetProduct(int[] myArr, int arrSum)
        {
            try
            {
                // Have the user select a random number in the range of their array
                Console.WriteLine($"Please select a number between one and {myArr.Length}");
                int userChoice = Convert.ToInt32(Console.ReadLine());
                int product;
                // Multiply the sum of the array and multiply by the user's array at the chosen index
                product = arrSum * myArr[userChoice];
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        static decimal GetQuotient(int myProd)
        {
            try
            {
                // Get a number from the user and turn it into a integer
                Console.WriteLine($"What number would you like to divide {myProd} by?");
                int userChoice = Convert.ToInt32(Console.ReadLine());
                // Divide the product by the users chosen integer
                decimal result = decimal.Divide(myProd, userChoice);
                return result;
            }
            catch (DivideByZeroException e)
            {
                // If user chooses 0, output the error message and return 0
                Console.WriteLine(e.Message);
                return 0;
            }
        }


    }
}
