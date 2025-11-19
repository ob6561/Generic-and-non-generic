using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    internal class Decimal_to_Binary
    {
        static void Main()
        {
            Console.Write("Enter a decimal number: ");
            int number = int.Parse(Console.ReadLine());

            string binary = DecimalToBinary(number);

            Console.WriteLine($"Binary representation: {binary}");
        }

        static string DecimalToBinary(int number)
        {
            if (number == 0)
                return "0";
            Stack<int> stack = new Stack<int>();
            int n = number;
            while (n > 0)
            {
                int remainder = n % 2;
                stack.Push(remainder);
                n /= 2;
            }
            var result = new System.Text.StringBuilder();
            while (stack.Count > 0)
            {
                result.Append(stack.Pop());
            }

            return result.ToString();
        }
    }
}
