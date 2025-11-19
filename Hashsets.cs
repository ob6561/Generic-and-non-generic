using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    internal class Hashsets
    {
        public static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 2, 4, 3, 5 };

            HashSet<int> set = new HashSet<int>(numbers);
            int[] uniqueNumbers = new int[set.Count];
            set.CopyTo(uniqueNumbers);
            foreach (var n in uniqueNumbers)
            {
                Console.WriteLine(n);
            }

        }
    }
}
