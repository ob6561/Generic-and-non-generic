using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    internal class Longest_consecutive_sequence
    {
        static int LongestConsecutive(int[] nums)
        {
            HashSet<int> set = new HashSet<int>(nums);
            int longest = 0;

            foreach (int x in nums)
            {
                
                if (!set.Contains(x - 1))
                {
                    int current = x;
                    int length = 1;

                    
                    while (set.Contains(current + 1))
                    {
                        current++;
                        length++;
                    }

                    if (length > longest)
                        longest = length;
                }
            }

            return longest;
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements in the array:");
            int n = int.Parse(Console.ReadLine());
            int[] nums = new int[n];
            Console.WriteLine("Enter the elements of the array:");
            string[] input = Console.ReadLine().Split(' ');
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(input[i]);
            }
            int result = LongestConsecutive(nums);
            Console.WriteLine("Length of the longest consecutive sequence: " + result);
            
        }
    }
}
