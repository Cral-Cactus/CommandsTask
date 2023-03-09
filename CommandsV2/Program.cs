using System;
using System.Collections.Generic;
using System.Linq;

namespace Commands
{
    internal class Program
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            while (true)
            {
                string[] action = Console.ReadLine().ToLower().Split();

                switch (action[0])
                {
                    case "push":
                        if (action.Length < 2)
                        {
                            Console.WriteLine("Error: Push command requires an argument");
                            continue;
                        }

                        int element = int.Parse(action[1]);
                        nums.Add(element);
                        break;

                    case "pop":
                        int lastElement = nums.Last();
                        Console.WriteLine(lastElement);

                        nums.Remove(lastElement);
                        break;

                    case "shift":
                        int lastElement2 = nums.Last();
                        int firstElement = nums.First();

                        nums.Remove(lastElement2);
                        nums.Insert(0, lastElement2);
                        nums.Add(firstElement);
                        break;

                    case "remove":
                        if (action.Length < 2)
                        {
                            Console.WriteLine("Error: Remove command requires an argument");
                            continue;
                        }

                        int removePos = int.Parse(action[1]);
                        nums.RemoveAt(removePos);
                        break;

                    case "addmany":
                        if (action.Length < 2)
                        {
                            Console.WriteLine("Error: addMany command requires an argument");
                            continue;
                        }

                        int position = int.Parse(action[1]);

                        List<int> elements = new List<int>();

                        for (int i = 2; i < action.Length; i++)
                        {
                            elements.Add(int.Parse(action[i]));
                        }

                        nums.InsertRange(position, elements);
                        break;

                    case "print":
                        nums.Reverse();
                        Console.WriteLine(string.Join(", ", nums));
                        return;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}
