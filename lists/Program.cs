using System;
using System.Collections.Generic;

namespace lists
{
    class Program
    {
        //planetPrinter is a method just like Main
        static void planetPrinter(List<string> stringList){
            foreach(string item in stringList) {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            List<string> planets = new List<string>(){"Mercury", "Mars"};
            
            // Add() Jupiter and Saturn at the end of the list.
            planets.Add("Jupiter");
            planets.Add("Saturn");

            Console.WriteLine("Testing planetPrinter");
            planetPrinter(planets);
            Console.WriteLine(" ");

            foreach (string i in planets) {
                Console.WriteLine($"Adding Jupiter & Saturn: {i}");
            }
                Console.WriteLine(" ");           

            // Create another List that contains that last two planet of our solar system.
            List<string> lastPlanets = new List<string>();
            lastPlanets.Add("Uranus");
            lastPlanets.Add("Neptune");

            // OR
            // string[] lastPlanets = new string[2];
            // lastPlanets[0] = "Uranus";
            // lastPlanets[1] = "Neptune";
            // foreach (string planet in planets) {
            //     Console.WriteLine(planet);
            // }
                // Can use i or planet
                            
            // Combine the two lists by using AddRange()
            planets.AddRange(lastPlanets);
            foreach (string i in planets) {
                Console.WriteLine($"Added Uranus & Neptune: {i}");
            }
                Console.WriteLine(" ");
            
            // Use Insert() to add Earth, and Venus in the correct order.
            Console.WriteLine("\nInsert(1, \"earth\")");
            planets.Insert(1, "Earth");
            Console.WriteLine("\nInsert(1, \"venus\")");
            planets.Insert(1, "Venus");
            foreach (string i in planets) {
                Console.WriteLine($"Added Earth and Venus in order: {i}");
            }
                Console.WriteLine(" ");
            // OR
            // planets.Insert(1, "Venus");
            // planets.Insert(2, "Earth");
                        
            // Use Add() again to add Pluto to the end of the list.
            string[] pluto = new string[1];
            planets.Add("Pluto");
            foreach (string i in planets) {
                Console.WriteLine($"Added Pluto: {i}");
            }
                Console.WriteLine(" ");
            
            // Now that all the planets are in the list, slice the list using GetRange() in order to extract the rocky planets into a new list called rockyPlanets. The rocky planets will remain in the original planets list.

            Console.WriteLine("\noutput = planets.GetRange(0, 4).ToArray()");
            string[] output = planets.GetRange(0, 4).ToArray();
            Console.WriteLine();
                foreach( string planet in output )
                {
                    Console.WriteLine($"Rocky planets: {planet}");
                }
                Console.WriteLine(" ");

            // Being good amateur astronomers, we know that Pluto is now a dwarf planet, so use the Remove() method to eliminate it from the end of planetList.
                Console.WriteLine("\nRemoveAt(8)");
                // This will remove the planet at index 8
                // planets.Remove("Pluto")
                // OR
                planets.RemoveAt(8);

                Console.WriteLine();
                foreach (string i in planets) {
                Console.WriteLine($"Removed Pluto: {i}");
            }
                Console.WriteLine(" ");

        }
    }
}
