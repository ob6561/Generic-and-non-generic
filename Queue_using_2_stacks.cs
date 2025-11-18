using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_and_non_generic
{
    internal class Queue_using_2_stacks
    {
        public static void Main(string[] args)
        {
            
            var queueNewest = new Stack<int>();
            var queueOldest = new Stack<int>();

            
            void ShiftStacks()
            {
                if (queueOldest.Count == 0)
                {
                    while (queueNewest.Count > 0)
                    {
                        queueOldest.Push(queueNewest.Pop());
                    }
                }
            }

            void Enqueue(int item)
            {
                queueNewest.Push(item);
            }

            int Dequeue()
            {
                ShiftStacks();
                if (queueOldest.Count == 0)
                    throw new InvalidOperationException("Queue is empty.");

                return queueOldest.Pop();
            }

            int Peek()
            {
                ShiftStacks();
                if (queueOldest.Count == 0)
                    throw new InvalidOperationException("Queue is empty.");

                return queueOldest.Peek();
            }

            
            Enqueue(10);
            Enqueue(20);
            Enqueue(30);

            Console.WriteLine(Peek());    
            Console.WriteLine(Dequeue()); 

            Enqueue(40);

            Console.WriteLine(Dequeue()); 
            Console.WriteLine(Dequeue()); 
            Console.WriteLine(Dequeue());
        }
    }
}
