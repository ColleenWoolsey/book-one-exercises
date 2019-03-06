using System;
using System.Collections.Generic;

namespace random_numbers
{
    class Program
    {
        private static object rand;

        static void Main(string[] args)
        {
            Random random = new Random();
            // (10) - Means up to ten (between zero and nine including nine)
            List<int> numbers = new List<int> {
                random.Next(10),
                random.Next(10),
                random.Next(10),
                random.Next(10),
                random.Next(10),
            };
            foreach(int num in numbers){
                Console.WriteLine(num);
            }
            // Use a for loop to iterate over all numbers between 0 and numbers.Count - 1.
            // for (int i = 0; i <= numbers.Count - 1; i++)
            // {
            //     foreach(int num in numbers){
            //     Console.WriteLine(num);
            // }
            // }

            // Inside the body of the for loop determine if the current loop index is contained inside of the numbers list. Print a message to the console indicating whether the index is in the list.
            for (int i = 0; i <= numbers.Count - 1; i++)
                if(numbers.Contains(i)){
                    Console.WriteLine($"Numbers list contains {i}");
                } else {
                    Console.WriteLine($"Numbers list does not contain {i}");
                }
            }
        }        
    }

