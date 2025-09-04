using System;

/// <summary>
/// Methods & Parameters in C#
/// Demonstrates method declaration, parameters, return types, and calling conventions
/// </summary>
namespace CSharpBasics
{
    public class MethodsAndParameters
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Methods & Parameters in C# ===\n");
            
            // Calling methods without parameters
            PrintWelcomeMessage();
            
            // Calling methods with parameters
            GreetUser("Alice");
            GreetUserWithAge("Bob", 25);
            
            // Methods with return values
            int sum = AddNumbers(10, 20);
            Console.WriteLine($"Sum of 10 and 20: {sum}");
            
            double area = CalculateCircleArea(5.0);
            Console.WriteLine($"Area of circle with radius 5: {area:F2}");
            
            // Method with multiple return values (using tuple)
            var (min, max) = FindMinMax(15, 8, 23, 4, 19);
            Console.WriteLine($"Min: {min}, Max: {max}");
            
            // Optional parameters
            Console.WriteLine("\n=== Optional Parameters ===");
            DisplayInfo("Charlie"); // Using default age
            DisplayInfo("Diana", 30); // Providing age
            
            // Named parameters
            Console.WriteLine("\n=== Named Parameters ===");
            CreateUser(name: "Eve", age: 28, email: "eve@example.com");
            CreateUser(email: "frank@example.com", name: "Frank", age: 35); // Different order
            
            // Variable number of parameters (params)
            Console.WriteLine("\n=== Variable Parameters (params) ===");
            int total1 = SumNumbers(1, 2, 3);
            int total2 = SumNumbers(5, 10, 15, 20, 25);
            Console.WriteLine($"Sum of (1,2,3): {total1}");
            Console.WriteLine($"Sum of (5,10,15,20,25): {total2}");
            
            // Local functions (C# 7.0+)
            Console.WriteLine("\n=== Local Functions ===");
            DemonstrateLocalFunctions();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // Method without parameters and return value
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to C# Methods demonstration!");
        }
        
        // Method with one parameter
        public static void GreetUser(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        
        // Method with multiple parameters
        public static void GreetUserWithAge(string name, int age)
        {
            Console.WriteLine($"Hello, {name}! You are {age} years old.");
        }
        
        // Method with return value
        public static int AddNumbers(int a, int b)
        {
            return a + b;
        }
        
        // Method with return value (different type)
        public static double CalculateCircleArea(double radius)
        {
            const double PI = 3.14159;
            return PI * radius * radius;
        }
        
        // Method returning multiple values using tuple
        public static (int min, int max) FindMinMax(params int[] numbers)
        {
            if (numbers.Length == 0)
                return (0, 0);
            
            int min = numbers[0];
            int max = numbers[0];
            
            foreach (int num in numbers)
            {
                if (num < min) min = num;
                if (num > max) max = num;
            }
            
            return (min, max);
        }
        
        // Method with optional parameters
        public static void DisplayInfo(string name, int age = 18, string city = "Unknown")
        {
            Console.WriteLine($"Name: {name}, Age: {age}, City: {city}");
        }
        
        // Method demonstrating named parameters
        public static void CreateUser(string name, int age, string email)
        {
            Console.WriteLine($"Creating user - Name: {name}, Age: {age}, Email: {email}");
        }
        
        // Method with variable number of parameters
        public static int SumNumbers(params int[] numbers)
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }
        
        // Expression-bodied methods (C# 6.0+)
        public static int Multiply(int a, int b) => a * b;
        
        public static bool IsEven(int number) => number % 2 == 0;
        
        public static string GetGreeting(string name) => $"Hello, {name}!";
        
        // Demonstrating local functions
        public static void DemonstrateLocalFunctions()
        {
            Console.WriteLine("Calculating factorial using local function:");
            
            // Local function - only accessible within this method
            long CalculateFactorial(int n)
            {
                if (n <= 1) return 1;
                return n * CalculateFactorial(n - 1);
            }
            
            // Using the local function
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Factorial of {i}: {CalculateFactorial(i)}");
            }
            
            // Another local function example
            bool IsPrime(int number)
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;
                
                for (int i = 3; i * i <= number; i += 2)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }
            
            Console.WriteLine("\nPrime numbers from 1 to 20:");
            for (int i = 1; i <= 20; i++)
            {
                if (IsPrime(i))
                {
                    Console.Write($"{i} ");
                }
            }
            Console.WriteLine();
        }
    }
}