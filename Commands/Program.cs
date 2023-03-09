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

                if (action[0] == "push")
                {
                    if (action.Length < 2)
                    {
                        Console.WriteLine("Error: Push command requires an argument");
                        continue;
                    }

                    int element = int.Parse(action[1]);
                    nums.Add(element);
                }
                else if (action[0] == "pop")
                {
                    int lastElement = nums.Last();
                    Console.WriteLine(lastElement);

                    nums.Remove(lastElement);
                }
                else if (action[0] == "shift")
                {
                    int lastElement = nums.Last();
                    int firstElement = nums.First();

                    nums.Remove(lastElement);
                    nums.Insert(0, lastElement);
                    nums.Add(firstElement);
                }
                else if (action[0] == "remove")
                {
                    if (action.Length < 2)
                    {
                        Console.WriteLine("Error: Remove command requires an argument");
                        continue;
                    }

                    int removePos = int.Parse(action[1]);
                    nums.RemoveAt(removePos);
                }
                else if (action[0] == "addMany")
                {
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
                }
                else if (action[0] == "print")
                {
                    nums.Reverse();

                    Console.WriteLine(string.Join(", ", nums));
                    break;
                }
            }
        }
    }
}