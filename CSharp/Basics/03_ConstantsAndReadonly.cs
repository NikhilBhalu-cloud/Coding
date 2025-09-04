using System;

/// <summary>
/// Constants & Readonly in C#
/// Demonstrates the difference between const and readonly keywords
/// </summary>
namespace CSharpBasics
{
    public class ConstantsAndReadonly
    {
        // Constants - compile-time constants
        public const double PI = 3.14159265359;
        public const string COMPANY_NAME = "Microsoft";
        public const int MAX_USERS = 1000;
        
        // Readonly fields - runtime constants
        public static readonly DateTime APPLICATION_START_TIME = DateTime.Now;
        public readonly string instanceId;
        
        // Static readonly
        public static readonly string ENVIRONMENT = GetEnvironment();
        
        public ConstantsAndReadonly()
        {
            // Readonly can be assigned in constructor
            instanceId = Guid.NewGuid().ToString();
        }
        
        private static string GetEnvironment()
        {
            return Environment.MachineName;
        }
        
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Constants & Readonly in C# ===\n");
            
            // Using constants
            Console.WriteLine("=== Constants (const) ===");
            Console.WriteLine($"PI: {PI}");
            Console.WriteLine($"Company Name: {COMPANY_NAME}");
            Console.WriteLine($"Max Users: {MAX_USERS}");
            
            Console.WriteLine("\nConstants are:");
            Console.WriteLine("- Compile-time constants");
            Console.WriteLine("- Must be initialized at declaration");
            Console.WriteLine("- Implicitly static");
            Console.WriteLine("- Value types and strings only");
            
            // Using readonly
            Console.WriteLine("\n=== Readonly Fields ===");
            Console.WriteLine($"Application Start Time: {APPLICATION_START_TIME}");
            Console.WriteLine($"Environment: {ENVIRONMENT}");
            
            var instance1 = new ConstantsAndReadonly();
            var instance2 = new ConstantsAndReadonly();
            
            Console.WriteLine($"Instance 1 ID: {instance1.instanceId}");
            Console.WriteLine($"Instance 2 ID: {instance2.instanceId}");
            
            Console.WriteLine("\nReadonly fields are:");
            Console.WriteLine("- Runtime constants");
            Console.WriteLine("- Can be initialized at declaration or in constructor");
            Console.WriteLine("- Can be static or instance members");
            Console.WriteLine("- Can be any type");
            
            // Demonstrating the difference
            Console.WriteLine("\n=== Key Differences ===");
            Console.WriteLine("const:");
            Console.WriteLine("- Faster access (inlined by compiler)");
            Console.WriteLine("- Cannot change after compilation");
            Console.WriteLine("- Limited to compile-time values");
            
            Console.WriteLine("\nreadonly:");
            Console.WriteLine("- Slight performance overhead");
            Console.WriteLine("- Can be different for each application run");
            Console.WriteLine("- Can use runtime values (like DateTime.Now)");
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}