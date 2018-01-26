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
            Console.WriteLine("Give the number for which factorial is required");
            int input = Convert.ToInt32(Console.ReadLine());
            GetFactorial(input);
            GetFactorial(input, true);
        }        

		static void GetFactorial(int input)
		{
			BigInteger output = 1;
			for (int i = 1; i <= input; i++)
			{
				output = output * i;
			}

			Console.WriteLine(output);
			Console.Read();
		}

		static void GetFactorial(int input, bool usingArray)
		{
			int[] res = new int[10000];

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

		private static int Multiply(int i, int[] res, int res_size)
		{
			int carry = 0;

			for (int j = 0; j < res_size; j++)
			{
				int prod = res[j] * i + carry;
				res[j] = prod % 10;

				carry = prod / 10;
			}

			while (carry!=0)
			{
				res[res_size] = carry % 10;
				carry = carry / 10;
				res_size++;
			}

			return res_size;
		}
	}
}
