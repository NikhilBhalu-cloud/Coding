using System;

/// <summary>
/// Operators in C#
/// Demonstrates Arithmetic, Logical, Bitwise, and Comparison operators
/// </summary>
namespace CSharpBasics
{
    public class Operators
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== C# Operators ===\n");
            
            // Arithmetic Operators
            Console.WriteLine("=== Arithmetic Operators ===");
            int a = 15, b = 4;
            
            Console.WriteLine($"a = {a}, b = {b}");
            Console.WriteLine($"Addition (a + b): {a + b}");
            Console.WriteLine($"Subtraction (a - b): {a - b}");
            Console.WriteLine($"Multiplication (a * b): {a * b}");
            Console.WriteLine($"Division (a / b): {a / b}");
            Console.WriteLine($"Modulus (a % b): {a % b}");
            Console.WriteLine($"Increment (++a): {++a}");
            Console.WriteLine($"Decrement (--b): {--b}");
            
            // Comparison Operators
            Console.WriteLine("\n=== Comparison Operators ===");
            int x = 10, y = 20;
            
            Console.WriteLine($"x = {x}, y = {y}");
            Console.WriteLine($"Equal (x == y): {x == y}");
            Console.WriteLine($"Not Equal (x != y): {x != y}");
            Console.WriteLine($"Greater than (x > y): {x > y}");
            Console.WriteLine($"Less than (x < y): {x < y}");
            Console.WriteLine($"Greater than or equal (x >= y): {x >= y}");
            Console.WriteLine($"Less than or equal (x <= y): {x <= y}");
            
            // Logical Operators
            Console.WriteLine("\n=== Logical Operators ===");
            bool p = true, q = false;
            
            Console.WriteLine($"p = {p}, q = {q}");
            Console.WriteLine($"Logical AND (p && q): {p && q}");
            Console.WriteLine($"Logical OR (p || q): {p || q}");
            Console.WriteLine($"Logical NOT (!p): {!p}");
            Console.WriteLine($"Logical NOT (!q): {!q}");
            
            // Conditional (Ternary) Operator
            Console.WriteLine("\n=== Conditional (Ternary) Operator ===");
            int age = 18;
            string result = age >= 18 ? "Adult" : "Minor";
            Console.WriteLine($"Age: {age}, Status: {result}");
            
            // Bitwise Operators
            Console.WriteLine("\n=== Bitwise Operators ===");
            int m = 12; // Binary: 1100
            int n = 10; // Binary: 1010
            
            Console.WriteLine($"m = {m} (Binary: {Convert.ToString(m, 2).PadLeft(8, '0')})");
            Console.WriteLine($"n = {n} (Binary: {Convert.ToString(n, 2).PadLeft(8, '0')})");
            Console.WriteLine($"Bitwise AND (m & n): {m & n} (Binary: {Convert.ToString(m & n, 2).PadLeft(8, '0')})");
            Console.WriteLine($"Bitwise OR (m | n): {m | n} (Binary: {Convert.ToString(m | n, 2).PadLeft(8, '0')})");
            Console.WriteLine($"Bitwise XOR (m ^ n): {m ^ n} (Binary: {Convert.ToString(m ^ n, 2).PadLeft(8, '0')})");
            Console.WriteLine($"Bitwise NOT (~m): {~m}");
            Console.WriteLine($"Left Shift (m << 1): {m << 1} (Binary: {Convert.ToString(m << 1, 2).PadLeft(8, '0')})");
            Console.WriteLine($"Right Shift (m >> 1): {m >> 1} (Binary: {Convert.ToString(m >> 1, 2).PadLeft(8, '0')})");
            
            // Assignment Operators
            Console.WriteLine("\n=== Assignment Operators ===");
            int val = 10;
            Console.WriteLine($"Initial value: {val}");
            
            val += 5; // val = val + 5
            Console.WriteLine($"After += 5: {val}");
            
            val -= 3; // val = val - 3
            Console.WriteLine($"After -= 3: {val}");
            
            val *= 2; // val = val * 2
            Console.WriteLine($"After *= 2: {val}");
            
            val /= 4; // val = val / 4
            Console.WriteLine($"After /= 4: {val}");
            
            val %= 3; // val = val % 3
            Console.WriteLine($"After %= 3: {val}");
            
            // Null-coalescing Operators
            Console.WriteLine("\n=== Null-coalescing Operators ===");
            string nullString = null;
            string defaultString = "Default Value";
            
            string result1 = nullString ?? defaultString;
            Console.WriteLine($"nullString ?? defaultString: {result1}");
            
            string result2 = "Not Null" ?? defaultString;
            Console.WriteLine($"\"Not Null\" ?? defaultString: {result2}");
            
            // Null-coalescing assignment (C# 8.0+)
            string testString = null;
            testString ??= "Assigned Default";
            Console.WriteLine($"After ??= assignment: {testString}");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}