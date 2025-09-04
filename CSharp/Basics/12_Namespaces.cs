using System;
// The following using directive is commented out to demonstrate namespace qualification
// using MyCompany.Utilities;

/// <summary>
/// Namespaces in C#
/// Demonstrates namespace declaration, usage, and organization
/// </summary>
namespace CSharpBasics
{
    public class Namespaces
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Namespaces in C# ===\n");
            
            DemonstrateBasicNamespaces();
            DemonstrateNestedNamespaces();
            DemonstrateNamespaceAliases();
            DemonstrateGlobalNamespace();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        private static void DemonstrateBasicNamespaces()
        {
            Console.WriteLine("=== Basic Namespaces ===");
            
            // Using classes from different namespaces
            Console.WriteLine("Using System namespace classes:");
            Console.WriteLine($"DateTime: {DateTime.Now}");
            Console.WriteLine($"Environment: {Environment.MachineName}");
            Console.WriteLine($"Math.PI: {Math.PI}");
            
            // Using fully qualified names (without using statements)
            Console.WriteLine("\nUsing fully qualified names:");
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("Built with fully qualified name");
            Console.WriteLine(sb.ToString());
            
            // Collections namespace
            Console.WriteLine("\nUsing System.Collections.Generic:");
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            list.Add("Item 1");
            list.Add("Item 2");
            Console.WriteLine($"List count: {list.Count}");
            
            Console.WriteLine();
        }
        
        private static void DemonstrateNestedNamespaces()
        {
            Console.WriteLine("=== Nested Namespaces ===");
            
            // Using classes from nested namespaces
            var mathUtil = new MyCompany.Utilities.MathUtility();
            Console.WriteLine($"Add(5, 3) = {mathUtil.Add(5, 3)}");
            
            var stringUtil = new MyCompany.Utilities.StringUtility();
            Console.WriteLine($"Reverse('Hello') = {stringUtil.Reverse("Hello")}");
            
            var logger = new MyCompany.Logging.FileLogger();
            logger.Log("This is a test message");
            
            var dbLogger = new MyCompany.Logging.Database.DatabaseLogger();
            dbLogger.Log("Database log message");
            
            Console.WriteLine();
        }
        
        private static void DemonstrateNamespaceAliases()
        {
            Console.WriteLine("=== Namespace Aliases ===");
            
            // Creating aliases for long namespace names
            var util = new MathUtil(); // Using alias defined at top of file
            Console.WriteLine($"Using alias - Multiply(4, 5) = {util.Multiply(4, 5)}");
            
            // Global alias
            var globalUtil = new global::MyCompany.Utilities.MathUtility();
            Console.WriteLine($"Using global alias - Divide(20, 4) = {globalUtil.Divide(20, 4)}");
            
            Console.WriteLine();
        }
        
        private static void DemonstrateGlobalNamespace()
        {
            Console.WriteLine("=== Global Namespace ===");
            
            // Accessing global namespace
            var globalClass = new GlobalClass();
            globalClass.DisplayMessage();
            
            // Avoiding namespace conflicts
            var myConsole = new MyCompany.Console();
            myConsole.WriteLine("Custom console implementation");
            
            // Using global qualifier to access System.Console
            global::System.Console.WriteLine("Using global System.Console");
            
            Console.WriteLine();
        }
    }
}

// Namespace alias (must be at file level)
using MathUtil = MyCompany.Utilities.MathUtility;

// Multiple namespace declarations in same file
namespace MyCompany.Utilities
{
    public class MathUtility
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public double Divide(double a, double b) => b != 0 ? a / b : 0;
    }
    
    public class StringUtility
    {
        public string Reverse(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            
            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
        
        public string Capitalize(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;
            
            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }
    }
}

namespace MyCompany.Logging
{
    public class FileLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"[FILE LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
        }
    }
    
    // Nested namespace within namespace
    namespace Database
    {
        public class DatabaseLogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"[DB LOG] {DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
            }
        }
    }
}

namespace MyCompany
{
    // Custom Console class to demonstrate namespace conflicts
    public class Console
    {
        public void WriteLine(string message)
        {
            System.Console.WriteLine($"[MyCompany.Console] {message}");
        }
    }
}

// Global namespace (no namespace declaration)
public class GlobalClass
{
    public void DisplayMessage()
    {
        Console.WriteLine("This class is in the global namespace");
    }
}

/* 
 * Namespace Best Practices:
 * 
 * 1. Use PascalCase for namespace names
 * 2. Use company/organization name as root namespace
 * 3. Organize by functionality, not by type
 * 4. Keep namespace hierarchy shallow (2-4 levels max)
 * 5. Match namespace to folder structure
 * 6. Avoid using reserved keywords
 * 7. Use meaningful, descriptive names
 * 
 * Example good namespace hierarchy:
 * - CompanyName.ProductName.Feature
 * - Microsoft.EntityFramework.Core
 * - System.Collections.Generic
 * 
 * File organization example:
 * - MyCompany.ProjectName.Data
 * - MyCompany.ProjectName.Business
 * - MyCompany.ProjectName.Web
 * - MyCompany.ProjectName.Common
 */