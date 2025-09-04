using System;

/// <summary>
/// Data Types & Variables in C#
/// Demonstrates various data types and variable declarations
/// </summary>
namespace CSharpBasics
{
    public class DataTypesAndVariables
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== C# Data Types & Variables ===\n");
            
            // Value Types
            Console.WriteLine("=== Value Types ===");
            
            // Integer types
            byte byteVar = 255;
            short shortVar = -32768;
            int intVar = 2147483647;
            long longVar = 9223372036854775807L;
            
            Console.WriteLine($"byte: {byteVar} (Range: 0 to 255)");
            Console.WriteLine($"short: {shortVar} (Range: -32,768 to 32,767)");
            Console.WriteLine($"int: {intVar} (Range: -2,147,483,648 to 2,147,483,647)");
            Console.WriteLine($"long: {longVar} (Range: very large)");
            
            // Floating-point types
            float floatVar = 3.14159f;
            double doubleVar = 3.141592653589793;
            decimal decimalVar = 123.456789m;
            
            Console.WriteLine($"\nfloat: {floatVar} (7 digits precision)");
            Console.WriteLine($"double: {doubleVar} (15-17 digits precision)");
            Console.WriteLine($"decimal: {decimalVar} (28-29 digits precision)");
            
            // Other value types
            bool boolVar = true;
            char charVar = 'A';
            
            Console.WriteLine($"\nbool: {boolVar}");
            Console.WriteLine($"char: {charVar}");
            
            // Reference Types
            Console.WriteLine("\n=== Reference Types ===");
            
            string stringVar = "Hello, C#!";
            object objectVar = "This is an object";
            
            Console.WriteLine($"string: {stringVar}");
            Console.WriteLine($"object: {objectVar}");
            
            // var keyword (implicitly typed)
            Console.WriteLine("\n=== Implicitly Typed Variables (var) ===");
            var implicitInt = 42;
            var implicitString = "Inferred as string";
            var implicitDouble = 3.14;
            
            Console.WriteLine($"var implicitInt = {implicitInt} (Type: {implicitInt.GetType().Name})");
            Console.WriteLine($"var implicitString = \"{implicitString}\" (Type: {implicitString.GetType().Name})");
            Console.WriteLine($"var implicitDouble = {implicitDouble} (Type: {implicitDouble.GetType().Name})");
            
            // Nullable types
            Console.WriteLine("\n=== Nullable Types ===");
            int? nullableInt = null;
            bool? nullableBool = true;
            
            Console.WriteLine($"int? nullableInt = {nullableInt?.ToString() ?? "null"}");
            Console.WriteLine($"bool? nullableBool = {nullableBool}");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}