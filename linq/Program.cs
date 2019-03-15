using System;
using System.Linq;
using System.Collections.Generic;

namespace linq
{
    
    public class Program
    {
        public static void Main(string[] args)
        {
// Restriction/Filtering Operations
    // Find the words in the collection that start with the letter 'L'
        List<string> fruitList = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

        IEnumerable<string> Lwords = from fruit in fruitList
            where fruit.Substring(0,1) =="L"
            select fruit;
            Console.WriteLine("***** Restriction/Filtering Operations *****");
            Console.WriteLine("Fruits that start with L");
        foreach (string f in Lwords) {
            Console.WriteLine($"{f}");
        }

    // Which of the following numbers are multiples of 4 or 6
        List<int> numbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 && number % 6 == 0);
        Console.WriteLine("fourSixMultiples");
        foreach (int n in fourSixMultiples) {
            Console.WriteLine($"{n}");
        }


// Ordering Operations
    // Order these student names alphabetically, in descending order (Z to A)
        List<string> names = new List<string>()
        {
            "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
            "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
            "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
            "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
            "Francisco", "Tre"
        };

        IEnumerable<string> descend = from n in names
            orderby n descending
            select n;
            Console.WriteLine("***** Ordering Operations *****");
        foreach (string n in descend) {
            Console.WriteLine($"{n}");
        }
       
        // Build a collection of these numbers sorted in ascending order
        List<int> anumbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };
        var sortedNumbers = from s in anumbers 
        orderby s ascending 
        select s; 
  
        Console.WriteLine("The numbers from lowest to highest"); 
        foreach (var s in sortedNumbers) 
        { 
            Console.WriteLine(s); 
        }

// Aggregate Operations
Console.WriteLine("***** Aggregate Operations *****");
    // Output how many numbers are in this list
        List<int> xnumbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };
        Console.WriteLine($"Numbers in this list {xnumbers.Count()}");
    // How much money have we made?
        List<double> purchases = new List<double>()
        {
            2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
        };
        Console.WriteLine($"Money made was {purchases.Sum()}");
    // What is our most expensive product?
        List<double> prices = new List<double>()
        {
            879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
        };


// Partitioning Operations
Console.WriteLine("***** Partitioning Operations *****");
    // Store each number in the following List until a perfect square is detected.

    // Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx=
        List<int> wheresSquaredo = new List<int>()
        {
            66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
        };
        // public static double Sqrt (double d);
        
        var squares = wheresSquaredo.TakeWhile(num => (num - Math.Round(Math.Sqrt(num), 2) * Math.Round(Math.Sqrt(num), 2) != 0));
          
        Console.WriteLine("The perfect square numbers"); 
        foreach (var num in squares)
            {
            Console.WriteLine(num); 
            }
        
        }
    }
}