using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Net.Mail;

namespace HowToCode
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSort(500);
            //Console.WriteLine("Give the number for which factorial is required");
            //int input = Convert.ToInt32(Console.ReadLine());
            //Using BigInteger data type
            //GetFactorial(input);
            //Using Array
            //GetFactorial(input, true);
        }

        static void BubbleSort(int totalItems)
        {
            int[] inputArray = new int[totalItems];
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                inputArray[i] = new Random(i + 100).Next();
            }

            bool swap = false;

            Console.WriteLine("[{0}]", string.Join(", ", inputArray));
            do
            {
                swap = false;
                for (int i = 0; i < inputArray.Length - 1; i++)
                {
                    if (inputArray[i] > inputArray[i + 1])
                    {
                        int temp = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = temp;
                        swap = true;
                    }
                }
            }
            while (swap);

            Console.WriteLine("[{0}]", string.Join(", ", inputArray));

            //Optimized way
            int loopLength = inputArray.Length - 1;
            do
            {
                swap = false;

                for (int i = 0; i < loopLength; i++)
                {
                    if (inputArray[i] > inputArray[i + 1])
                    {
                        int temp = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = temp;
                        swap = true;
                    }
                }
                loopLength = loopLength - 1;
            }
            while (swap);

            Console.WriteLine("[{0}]", string.Join(", ", inputArray));


            //Further Optimized way
            loopLength = inputArray.Length - 1;
            int newn = 0;
            do
            {
                newn = 0;
                for (int i = 0; i < loopLength; i++)
                {
                    if (inputArray[i] > inputArray[i + 1])
                    {
                        int temp = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = temp;
                        newn = i;
                    }
                }
                loopLength = newn;
            }
            while (newn != 0)   ;

            Console.WriteLine("[{0}]", string.Join(", ", inputArray));

            //Using Cocktail Shaker method with running the loop from both ends
            swap = false;

            Console.WriteLine("[{0}]", string.Join(", ", inputArray));
            do
            {
                swap = false;
                for (int i = 0; i < inputArray.Length - 1; i++)
                {
                    if (inputArray[i] > inputArray[i + 1])
                    {
                        int temp = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = temp;
                        swap = true;
                    }
                }
                if(!swap)
                {
                    break;
                }
                for (int i = inputArray.Length-1; i <= 0; i++)
                {
                    if (inputArray[i] > inputArray[i - 1])
                    {
                        int temp = inputArray[i];
                        inputArray[i] = inputArray[i + 1];
                        inputArray[i + 1] = temp;
                        swap = true;
                    }
                }
            }
            while (swap);

            Console.WriteLine("[{0}]", string.Join(", ", inputArray));

        }



        /// <summary>
        /// Get the factorial of a given number using BigInteger
        /// </summary>
        /// <param name="input">Input integer provided by user</param>
		static void GetFactorial(int input)
        {
            BigInteger output = 1;
            if (input >= 0)
            {
                for (int i = 1; i <= input; i++)
                {
                    output = output * i;
                }

                Console.WriteLine(output);
                Console.Read();
            }
            else
            {
                Console.WriteLine("Factorial of negative number doesn't exist.");
                Console.Read();
            }
        }

        /// <summary>
        /// Get the factorial of a given number using Array
        /// </summary>
        /// <param name="input">Input integer provided by user</param>
        /// <param name="usingArray">Boolean variable to check to use array or not.</param>
		static void GetFactorial(int input, bool usingArray)
        {
            //Create array to store output digits
            int[] res = new int[10000];

            //Initialize the first value of array with 1 and size of the array
            res[0] = 1;
            int res_size = 1;

            for (int i = 2; i <= input; i++)
            {
                res_size = Multiply(i, res, res_size);
            }

            for (int i = res_size - 1; i >= 0; i--)
            {
                Console.Write(res[i]);
            }
            Console.Read();
        }


        /// <summary>
        /// Mulitply the numbers and hold the digits on each position of array
        /// </summary>
        /// <param name="i">The number which need to be multiplied</param>
        /// <param name="res">Array which is used to hold the value of factorial</param>
        /// <param name="res_size">Size of the array</param>
        /// <returns></returns>
		private static int Multiply(int i, int[] res, int res_size)
        {
            //Carry in case 
            int carry = 0;

            for (int j = 0; j < res_size; j++)
            {
                //Calculate the product by multiplying the numbers and adding the carry
                int prod = res[j] * i + carry;
                res[j] = prod % 10;

                carry = prod / 10;
            }

            //Increment the array size and add the value of carry in the same
            while (carry != 0)
            {
                res[res_size] = carry % 10;
                carry = carry / 10;
                res_size++;
            }

            return res_size;
        }
    }
}
