using System;

/// <summary>
/// Method Overloading in C#
/// Demonstrates how to create multiple methods with the same name but different signatures
/// </summary>
namespace CSharpBasics
{
    public class MethodOverloading
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Method Overloading in C# ===\n");
            
            var calculator = new Calculator();
            
            // Method overloading with different number of parameters
            Console.WriteLine("=== Different Number of Parameters ===");
            Console.WriteLine($"Add(5, 3) = {calculator.Add(5, 3)}");
            Console.WriteLine($"Add(5, 3, 2) = {calculator.Add(5, 3, 2)}");
            Console.WriteLine($"Add(5, 3, 2, 1) = {calculator.Add(5, 3, 2, 1)}");
            
            // Method overloading with different parameter types
            Console.WriteLine("\n=== Different Parameter Types ===");
            Console.WriteLine($"Add(5, 3) = {calculator.Add(5, 3)}"); // int version
            Console.WriteLine($"Add(5.5, 3.3) = {calculator.Add(5.5, 3.3)}"); // double version
            Console.WriteLine($"Add(2.5f, 1.5f) = {calculator.Add(2.5f, 1.5f)}"); // float version
            
            // Method overloading with different parameter order
            Console.WriteLine("\n=== Different Parameter Order ===");
            calculator.DisplayInfo("Alice", 25);
            calculator.DisplayInfo(30, "Bob");
            
            // Method overloading with array and params
            Console.WriteLine("\n=== Array vs Params ===");
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Sum(array) = {calculator.Sum(numbers)}");
            Console.WriteLine($"Sum(params) = {calculator.Sum(1, 2, 3, 4, 5)}");
            
            // Static method overloading
            Console.WriteLine("\n=== Static Method Overloading ===");
            Console.WriteLine($"Static Add(10, 20) = {Calculator.Add(10, 20)}");
            Console.WriteLine($"Static Add(\"Hello\", \"World\") = {Calculator.Add("Hello", "World")}");
            
            // Overloading with ref and out parameters
            Console.WriteLine("\n=== Ref and Out Parameter Overloading ===");
            
            int value1 = 10;
            calculator.ModifyValue(value1); // by value
            Console.WriteLine($"After ModifyValue(by value): {value1}");
            
            calculator.ModifyValue(ref value1); // by reference
            Console.WriteLine($"After ModifyValue(ref): {value1}");
            
            int value2;
            calculator.ModifyValue(out value2); // out parameter
            Console.WriteLine($"After ModifyValue(out): {value2}");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
    
    public class Calculator
    {
        // Method overloading with different number of parameters
        public int Add(int a, int b)
        {
            Console.WriteLine($"Calling Add(int, int)");
            return a + b;
        }
        
        public int Add(int a, int b, int c)
        {
            Console.WriteLine($"Calling Add(int, int, int)");
            return a + b + c;
        }
        
        public int Add(int a, int b, int c, int d)
        {
            Console.WriteLine($"Calling Add(int, int, int, int)");
            return a + b + c + d;
        }
        
        // Method overloading with different parameter types
        public double Add(double a, double b)
        {
            Console.WriteLine($"Calling Add(double, double)");
            return a + b;
        }
        
        public float Add(float a, float b)
        {
            Console.WriteLine($"Calling Add(float, float)");
            return a + b;
        }
        
        // Method overloading with different parameter order
        public void DisplayInfo(string name, int age)
        {
            Console.WriteLine($"DisplayInfo(string, int): Name: {name}, Age: {age}");
        }
        
        public void DisplayInfo(int age, string name)
        {
            Console.WriteLine($"DisplayInfo(int, string): Age: {age}, Name: {name}");
        }
        
        // Method overloading with array vs params
        public int Sum(int[] numbers)
        {
            Console.WriteLine("Calling Sum(int[] array)");
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }
        
        public int Sum(params int[] numbers)
        {
            Console.WriteLine("Calling Sum(params int[])");
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            return sum;
        }
        
        // Static method overloading
        public static int Add(int a, int b)
        {
            Console.WriteLine("Calling static Add(int, int)");
            return a + b;
        }
        
        public static string Add(string a, string b)
        {
            Console.WriteLine("Calling static Add(string, string)");
            return a + " " + b;
        }
        
        // Method overloading with ref and out parameters
        public void ModifyValue(int value)
        {
            Console.WriteLine("Calling ModifyValue(int value) - by value");
            value = value * 2;
            Console.WriteLine($"Inside method, value = {value}");
        }
        
        public void ModifyValue(ref int value)
        {
            Console.WriteLine("Calling ModifyValue(ref int value) - by reference");
            value = value * 2;
            Console.WriteLine($"Inside method, value = {value}");
        }
        
        public void ModifyValue(out int value)
        {
            Console.WriteLine("Calling ModifyValue(out int value) - out parameter");
            value = 100;
            Console.WriteLine($"Inside method, value = {value}");
        }
        
        // Method overloading with optional parameters
        public void PrintMessage(string message)
        {
            Console.WriteLine($"PrintMessage(string): {message}");
        }
        
        public void PrintMessage(string message, int repeatCount = 1)
        {
            Console.WriteLine($"PrintMessage(string, int): Repeating {repeatCount} times");
            for (int i = 0; i < repeatCount; i++)
            {
                Console.WriteLine($"{i + 1}: {message}");
            }
        }
        
        // Method overloading considerations:
        // 1. Return type alone cannot distinguish overloaded methods
        // 2. Parameter names don't matter, only types and order
        // 3. ref, out, and in parameters are considered different from value parameters
        
        // This would cause a compilation error (return type only difference):
        // public string Add(int a, int b) { return (a + b).ToString(); }
        
        // This would also cause ambiguity:
        // public void DisplayInfo(string firstName, string lastName) { }
        // Would be ambiguous with DisplayInfo(string name, int age) in some contexts
    }
}