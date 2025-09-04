using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Arrays & Strings in C#
/// Demonstrates array operations and string manipulation
/// </summary>
namespace CSharpBasics
{
    public class ArraysAndStrings
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Arrays & Strings in C# ===\n");
            
            DemonstrateArrays();
            DemonstrateMultidimensionalArrays();
            DemonstrateJaggedArrays();
            DemonstrateStrings();
            DemonstrateStringMethods();
            DemonstrateStringBuilder();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Arrays
        private static void DemonstrateArrays()
        {
            Console.WriteLine("=== Arrays ===");
            
            // Array declaration and initialization
            int[] numbers1 = new int[5]; // Default values (0)
            int[] numbers2 = { 1, 2, 3, 4, 5 }; // Array literal
            int[] numbers3 = new int[] { 10, 20, 30 }; // Explicit array creation
            
            Console.WriteLine("Array initialization:");
            Console.WriteLine($"numbers1 (default): [{string.Join(", ", numbers1)}]");
            Console.WriteLine($"numbers2 (literal): [{string.Join(", ", numbers2)}]");
            Console.WriteLine($"numbers3 (explicit): [{string.Join(", ", numbers3)}]");
            
            // Accessing array elements
            Console.WriteLine("\nArray access:");
            Console.WriteLine($"numbers2[0] = {numbers2[0]}");
            Console.WriteLine($"numbers2[2] = {numbers2[2]}");
            Console.WriteLine($"Array length: {numbers2.Length}");
            
            // Modifying array elements
            numbers1[0] = 100;
            numbers1[1] = 200;
            Console.WriteLine($"After modification: [{string.Join(", ", numbers1)}]");
            
            // Iterating through arrays
            Console.WriteLine("\nIterating through array:");
            Console.Write("For loop: ");
            for (int i = 0; i < numbers2.Length; i++)
            {
                Console.Write($"{numbers2[i]} ");
            }
            Console.WriteLine();
            
            Console.Write("Foreach loop: ");
            foreach (int num in numbers2)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine();
            
            // Array methods
            Console.WriteLine("\nArray methods:");
            int[] unsorted = { 5, 2, 8, 1, 9, 3 };
            Console.WriteLine($"Original: [{string.Join(", ", unsorted)}]");
            
            Array.Sort(unsorted);
            Console.WriteLine($"Sorted: [{string.Join(", ", unsorted)}]");
            
            Array.Reverse(unsorted);
            Console.WriteLine($"Reversed: [{string.Join(", ", unsorted)}]");
            
            int index = Array.IndexOf(unsorted, 5);
            Console.WriteLine($"Index of 5: {index}");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Multidimensional Arrays
        private static void DemonstrateMultidimensionalArrays()
        {
            Console.WriteLine("=== Multidimensional Arrays ===");
            
            // 2D array (rectangular)
            int[,] matrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            
            Console.WriteLine("2D Array (3x3 matrix):");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]:D2} ");
                }
                Console.WriteLine();
            }
            
            // 3D array
            int[,,] cube = new int[2, 2, 2];
            int counter = 1;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        cube[i, j, k] = counter++;
                    }
                }
            }
            
            Console.WriteLine("\n3D Array (2x2x2 cube):");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Layer {i}:");
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 2; k++)
                    {
                        Console.Write($"{cube[i, j, k]} ");
                    }
                    Console.WriteLine();
                }
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region Jagged Arrays
        private static void DemonstrateJaggedArrays()
        {
            Console.WriteLine("=== Jagged Arrays ===");
            
            // Jagged array (array of arrays)
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2 };
            jaggedArray[1] = new int[] { 3, 4, 5, 6 };
            jaggedArray[2] = new int[] { 7, 8, 9 };
            
            Console.WriteLine("Jagged Array:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.Write($"Row {i}: ");
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
            
            // Using LINQ with jagged arrays
            Console.WriteLine($"Total elements: {jaggedArray.SelectMany(x => x).Count()}");
            Console.WriteLine($"Sum of all elements: {jaggedArray.SelectMany(x => x).Sum()}");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Strings
        private static void DemonstrateStrings()
        {
            Console.WriteLine("=== Strings ===");
            
            // String creation
            string str1 = "Hello";
            string str2 = "World";
            string str3 = str1 + " " + str2; // Concatenation
            string str4 = $"{str1} {str2}!"; // String interpolation
            
            Console.WriteLine($"str1: {str1}");
            Console.WriteLine($"str2: {str2}");
            Console.WriteLine($"str3 (concatenation): {str3}");
            Console.WriteLine($"str4 (interpolation): {str4}");
            
            // String properties
            Console.WriteLine($"\nString properties:");
            Console.WriteLine($"Length of '{str1}': {str1.Length}");
            Console.WriteLine($"Is '{str1}' empty? {string.IsNullOrEmpty(str1)}");
            Console.WriteLine($"Is '' empty? {string.IsNullOrEmpty("")}");
            
            // String immutability
            Console.WriteLine("\nString immutability:");
            string original = "Original";
            string modified = original.ToUpper();
            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Modified: {modified}");
            Console.WriteLine("Strings are immutable - original unchanged");
            
            // Character access
            Console.WriteLine($"\nCharacter access:");
            string word = "Programming";
            Console.WriteLine($"Word: {word}");
            Console.WriteLine($"First character: {word[0]}");
            Console.WriteLine($"Last character: {word[word.Length - 1]}");
            
            // String as character array
            char[] chars = word.ToCharArray();
            Console.WriteLine($"As char array: [{string.Join(", ", chars)}]");
            
            Console.WriteLine();
        }
        #endregion
        
        #region String Methods
        private static void DemonstrateStringMethods()
        {
            Console.WriteLine("=== String Methods ===");
            
            string text = "  Hello, C# Programming!  ";
            Console.WriteLine($"Original: '{text}'");
            
            // Case conversion
            Console.WriteLine($"ToUpper(): '{text.ToUpper()}'");
            Console.WriteLine($"ToLower(): '{text.ToLower()}'");
            
            // Trimming
            Console.WriteLine($"Trim(): '{text.Trim()}'");
            Console.WriteLine($"TrimStart(): '{text.TrimStart()}'");
            Console.WriteLine($"TrimEnd(): '{text.TrimEnd()}'");
            
            // Substring
            string trimmed = text.Trim();
            Console.WriteLine($"Substring(0, 5): '{trimmed.Substring(0, 5)}'");
            Console.WriteLine($"Substring(7): '{trimmed.Substring(7)}'");
            
            // Contains, StartsWith, EndsWith
            Console.WriteLine($"Contains 'C#': {trimmed.Contains("C#")}");
            Console.WriteLine($"StartsWith 'Hello': {trimmed.StartsWith("Hello")}");
            Console.WriteLine($"EndsWith '!': {trimmed.EndsWith("!")}");
            
            // Replace
            string replaced = trimmed.Replace("C#", "CSharp");
            Console.WriteLine($"Replace 'C#' with 'CSharp': '{replaced}'");
            
            // Split
            string csv = "apple,banana,orange,grape";
            string[] fruits = csv.Split(',');
            Console.WriteLine($"Split '{csv}': [{string.Join(" | ", fruits)}]");
            
            // Join
            string joined = string.Join(" - ", fruits);
            Console.WriteLine($"Join with ' - ': '{joined}'");
            
            // IndexOf, LastIndexOf
            string sentence = "The quick brown fox jumps over the lazy dog";
            Console.WriteLine($"IndexOf 'the': {sentence.IndexOf("the")}");
            Console.WriteLine($"LastIndexOf 'the': {sentence.LastIndexOf("the")}");
            Console.WriteLine($"IndexOf 'the' (ignore case): {sentence.IndexOf("the", StringComparison.OrdinalIgnoreCase)}");
            
            // Padding
            string name = "John";
            Console.WriteLine($"PadLeft(10): '{name.PadLeft(10)}'");
            Console.WriteLine($"PadRight(10): '{name.PadRight(10)}'");
            Console.WriteLine($"PadLeft(10, '*'): '{name.PadLeft(10, '*')}'");
            
            Console.WriteLine();
        }
        #endregion
        
        #region StringBuilder
        private static void DemonstrateStringBuilder()
        {
            Console.WriteLine("=== StringBuilder ===");
            
            // Performance comparison: String vs StringBuilder
            Console.WriteLine("String concatenation performance demo:");
            
            // Using StringBuilder for multiple concatenations
            var sb = new System.Text.StringBuilder();
            sb.Append("Building a string with StringBuilder");
            sb.AppendLine(); // Adds Environment.NewLine
            sb.Append("Line 2");
            sb.AppendLine();
            sb.AppendFormat("Formatted line: {0} + {1} = {2}", 5, 3, 5 + 3);
            sb.AppendLine();
            
            // Insert and replace
            sb.Insert(0, "*** ");
            sb.Replace("StringBuilder", "StringBuilder (efficient)");
            
            Console.WriteLine("StringBuilder result:");
            Console.WriteLine(sb.ToString());
            
            // StringBuilder methods
            Console.WriteLine("StringBuilder info:");
            Console.WriteLine($"Length: {sb.Length}");
            Console.WriteLine($"Capacity: {sb.Capacity}");
            
            // Clear and reuse
            sb.Clear();
            sb.Append("New content after clear");
            Console.WriteLine($"After clear: {sb}");
            
            Console.WriteLine();
        }
        #endregion
    }
}