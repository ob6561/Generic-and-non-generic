using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    internal class Path_containing_loop_or_not
    {
        static bool HasLoop(string moves)
        {
            int x = 0, y = 0;
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            visited.Add((x, y));

            foreach (char c in moves)
            {
                switch (c)
                {
                    case 'U': y++; break;
                    case 'D': y--; break;
                    case 'L': x--; break;
                    case 'R': x++; break;
                    default:
                        
                        break;
                }

                var current = (x, y);

                
                if (visited.Contains(current))
                {
                    return true;
                }

                visited.Add(current);
            }

            return false;
        }
        static void Main()
        {
            Console.WriteLine("Enter path using U, D, L, R (e.g., UURDDL):");
            string path = Console.ReadLine().Trim();

            bool hasLoop = HasLoop(path);

            if (hasLoop)
                Console.WriteLine("The path contains a loop (revisited a coordinate).");
            else
                Console.WriteLine("The path does NOT contain a loop.");
        }
    }
}
