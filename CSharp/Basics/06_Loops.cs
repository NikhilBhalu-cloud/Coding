using System;
using System.Collections.Generic;

/// <summary>
/// Loops in C#
/// Demonstrates for, while, do-while, and foreach loops
/// </summary>
namespace CSharpBasics
{
    public class Loops
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Loops in C# ===\n");
            
            DemonstrateForLoop();
            DemonstrateWhileLoop();
            DemonstrateDoWhileLoop();
            DemonstrateForeachLoop();
            DemonstrateNestedLoops();
            DemonstrateLoopControl();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        private static void DemonstrateForLoop()
        {
            Console.WriteLine("=== for Loop ===");
            
            // Basic for loop
            Console.WriteLine("Counting from 1 to 5:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Count: {i}");
            }
            
            // For loop with different increment
            Console.WriteLine("\nEven numbers from 0 to 10:");
            for (int i = 0; i <= 10; i += 2)
            {
                Console.WriteLine($"Even: {i}");
            }
            
            // Reverse for loop
            Console.WriteLine("\nCountdown from 5 to 1:");
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Countdown: {i}");
            }
            
            // Multiple variables in for loop
            Console.WriteLine("\nMultiple variables:");
            for (int i = 0, j = 10; i < 5; i++, j--)
            {
                Console.WriteLine($"i: {i}, j: {j}");
            }
        }
        
        private static void DemonstrateWhileLoop()
        {
            Console.WriteLine("\n=== while Loop ===");
            
            // Basic while loop
            int count = 1;
            Console.WriteLine("While loop counting to 5:");
            while (count <= 5)
            {
                Console.WriteLine($"Count: {count}");
                count++;
            }
            
            // While loop with user input simulation
            Console.WriteLine("\nGuessing game simulation:");
            int secretNumber = 7;
            int guess = 1;
            
            while (guess != secretNumber)
            {
                Console.WriteLine($"Guess: {guess} - Wrong!");
                guess++;
            }
            Console.WriteLine($"Guess: {guess} - Correct!");
        }
        
        private static void DemonstrateDoWhileLoop()
        {
            Console.WriteLine("\n=== do-while Loop ===");
            
            // Basic do-while loop
            int num = 1;
            Console.WriteLine("Do-while loop (executes at least once):");
            do
            {
                Console.WriteLine($"Number: {num}");
                num++;
            } while (num <= 3);
            
            // Do-while that executes only once (condition false from start)
            Console.WriteLine("\nDo-while with false condition:");
            int x = 10;
            do
            {
                Console.WriteLine($"This executes once even though x ({x}) > 5");
            } while (x < 5);
        }
        
        private static void DemonstrateForeachLoop()
        {
            Console.WriteLine("\n=== foreach Loop ===");
            
            // Array iteration
            int[] numbers = { 10, 20, 30, 40, 50 };
            Console.WriteLine("Iterating through an array:");
            foreach (int number in numbers)
            {
                Console.WriteLine($"Number: {number}");
            }
            
            // String iteration
            string message = "Hello";
            Console.WriteLine("\nIterating through string characters:");
            foreach (char c in message)
            {
                Console.WriteLine($"Character: {c}");
            }
            
            // List iteration
            List<string> fruits = new List<string> { "Apple", "Banana", "Orange", "Grape" };
            Console.WriteLine("\nIterating through a List:");
            foreach (string fruit in fruits)
            {
                Console.WriteLine($"Fruit: {fruit}");
            }
            
            // Dictionary iteration
            Dictionary<string, int> ages = new Dictionary<string, int>
            {
                { "Alice", 25 },
                { "Bob", 30 },
                { "Charlie", 35 }
            };
            
            Console.WriteLine("\nIterating through a Dictionary:");
            foreach (var kvp in ages)
            {
                Console.WriteLine($"Name: {kvp.Key}, Age: {kvp.Value}");
            }
        }
        
        private static void DemonstrateNestedLoops()
        {
            Console.WriteLine("\n=== Nested Loops ===");
            
            // Multiplication table
            Console.WriteLine("3x3 Multiplication Table:");
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.Write($"{i * j:D2} ");
                }
                Console.WriteLine(); // New line after each row
            }
            
            // Pattern printing
            Console.WriteLine("\nStar Pattern:");
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
        }
        
        private static void DemonstrateLoopControl()
        {
            Console.WriteLine("\n=== Loop Control (break & continue) ===");
            
            // Break statement
            Console.WriteLine("Using break - Stop at 7:");
            for (int i = 1; i <= 10; i++)
            {
                if (i == 7)
                {
                    Console.WriteLine("Breaking at 7");
                    break;
                }
                Console.WriteLine($"Number: {i}");
            }
            
            // Continue statement
            Console.WriteLine("\nUsing continue - Skip even numbers:");
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    continue; // Skip even numbers
                }
                Console.WriteLine($"Odd number: {i}");
            }
            
            // Break in nested loops
            Console.WriteLine("\nBreak in nested loops:");
            bool found = false;
            for (int i = 1; i <= 3 && !found; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.WriteLine($"i: {i}, j: {j}");
                    if (i == 2 && j == 2)
                    {
                        Console.WriteLine("Target found! Breaking out of nested loops.");
                        found = true;
                        break;
                    }
                }
            }
        }
    }
}