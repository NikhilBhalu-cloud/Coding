using System;

/// <summary>
/// Introduction to C# & .NET
/// This file demonstrates basic C# program structure and .NET concepts
/// </summary>
namespace CSharpBasics
{
    public class Introduction
    {
        /// <summary>
        /// Entry point of the application
        /// </summary>
        /// <param name="args">Command line arguments</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to C# Programming!");
            Console.WriteLine("C# is a modern, object-oriented programming language");
            Console.WriteLine("developed by Microsoft as part of the .NET framework.");
            
            // Display .NET version information
            Console.WriteLine($"Runtime Version: {Environment.Version}");
            Console.WriteLine($"Operating System: {Environment.OSVersion}");
            
            // Basic program structure demonstration
            Console.WriteLine("\nBasic C# Program Structure:");
            Console.WriteLine("1. using statements (imports)");
            Console.WriteLine("2. namespace declaration");
            Console.WriteLine("3. class declaration");
            Console.WriteLine("4. Main method (entry point)");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}