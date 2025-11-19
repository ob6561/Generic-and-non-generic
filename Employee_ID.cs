using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    internal class Employee_ID
    {
        public static void Main(string[] args)
        {
            
            Dictionary<int, string> employees = new Dictionary<int, string>();

            
            employees.Add(1, "Om");
            employees.Add(2, "Ravi");
            employees.Add(3, "Rohan");
            employees.Add(4, "Sunny");

            
            var sortedEmployees = employees
                .OrderBy(e => e.Value)
                .ToList();
            Console.WriteLine("Employees sorted by name:");
            foreach (var emp in sortedEmployees)
            {
                Console.WriteLine($"ID: {emp.Key}, Name: {emp.Value}");
            }
        }
    }
}
