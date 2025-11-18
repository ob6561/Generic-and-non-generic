using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    internal class Duplicates_removal_from_sorted_list
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter the number of elements in the sorted list: ");
            int n = int.Parse(Console.ReadLine());
            List<int> sortedList = new List<int>();
            Console.WriteLine("Enter the elements in sorted order:");
            for (int i = 0; i < n; i++)
            {
                sortedList.Add(int.Parse(Console.ReadLine()));
            }
            List<int> uniqueList = new List<int>();
            if (sortedList.Count > 0)
            {
                uniqueList.Add(sortedList[0]);
                for (int i = 1; i < sortedList.Count; i++)
                {
                    if (sortedList[i] != sortedList[i - 1])
                    {
                        uniqueList.Add(sortedList[i]);
                    }
                }
            }
            Console.WriteLine("List after removing duplicates: " + string.Join(", ", uniqueList));
        }
    }
}
