using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    internal class Largest_subarray
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the number of elements: ");
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Enter the elements:");
            for (int i = 0; i < n; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            int maxSum = int.MinValue;
            int startIndex = 0;
            int endIndex = 0;
            for (int i = 0; i < n; i++)
            {
                int currentSum = 0;
                for (int j = i; j < n; j++)
                {
                    currentSum += array[j];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startIndex = i;
                        endIndex = j;
                    }
                }
            }
            Console.WriteLine("Largest subarray sum is: " + maxSum);
            Console.WriteLine("Subarray elements are: " + string.Join(", ", array.Skip(startIndex).Take(endIndex - startIndex + 1)));
        }
    }
}
