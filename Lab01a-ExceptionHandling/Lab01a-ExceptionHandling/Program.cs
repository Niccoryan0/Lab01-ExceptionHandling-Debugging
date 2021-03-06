﻿using System;

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
                Console.WriteLine("Welcome to the show! But not like... a fun show. A math show.");
                Console.WriteLine("Now, please enter any number greater than 0 (but for your own sake, make it less than 20)");
                string userChoiceStr = Console.ReadLine();
                int userChoice = Convert.ToInt32(userChoiceStr);
                // Create the array
                int[] newArr = new int[userChoice];
                // Populate array with values
                int[] popArr = Populate(newArr);
                // Call each of the methods to get values for sum, product and quotient
                int sumResult = GetSum(popArr);
                int prodResult = GetProduct(popArr, sumResult);
                decimal quotResult = GetQuotient(prodResult);
                // Display results to user
                Console.WriteLine($"The array you made is size: {userChoice}");
                Console.WriteLine($"The numbers in it are: {string.Join(", ", newArr)}");
                Console.WriteLine($"It's sum is {sumResult}");
                Console.WriteLine($"{sumResult} times {prodResult/sumResult} is {prodResult}");
                Console.WriteLine($"{prodResult} divided by {Decimal.Round(prodResult / quotResult)} is {Decimal.Round(quotResult, 2)}");
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
                // Get a number from the user for each position in the array, convert them to ints, and populate the array at i with the number
                Console.WriteLine($"Please enter a number less than 1000 ({i+1} of {myArr.Length})");
                string userChoice = Console.ReadLine();
                // Convert to integer
                int numChoice = int.Parse(userChoice);
                // Kick em out if they break the rules.
                if (numChoice > 1000)
                {
                    throw (new Exception($"{numChoice} is too high! I said keep it under 1000 buddy."));
                } else if (numChoice > 10000)
                {
                    throw (new Exception($"What in tarnation!? Pretty sure {numChoice} is well above 1000! Get outta here."));
                }
                // Populate the array with the value if it made it this far
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
            if (sum < 20)
            {
                throw (new Exception($"Value of sum ({sum}) is too low."));
            }
            return sum;
        }

        static int GetProduct(int[] myArr, int arrSum)
        {
            try
            {
                // Have the user select a random number in the range of their array, minus one for indexing
                Console.WriteLine($"Please select a number between one and {myArr.Length}");
                int userChoice = Int32.Parse(Console.ReadLine()) - 1;
                int product;
                // Multiply the sum of the array and multiply by the user's array at the chosen index
                product = arrSum * myArr[userChoice];
                return product;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                throw e;
            }
        }

        static decimal GetQuotient(int myProd)
        {
            try
            {
                // Get a number from the user and turn it into a integer
                Console.WriteLine($"What number would you like to divide {myProd} by?");

                int userChoice = int.Parse(Console.ReadLine());
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
