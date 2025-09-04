using System;

/// <summary>
/// Type Casting & Conversion in C#
/// Demonstrates implicit casting, explicit casting, and conversion methods
/// </summary>
namespace CSharpBasics
{
    public class TypeCastingAndConversion
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Type Casting & Conversion in C# ===\n");
            
            DemonstrateImplicitCasting();
            DemonstrateExplicitCasting();
            DemonstrateConversionMethods();
            DemonstrateParsingMethods();
            DemonstrateTryParseMethods();
            DemonstrateAsAndIsOperators();
            DemonstrateCustomConversions();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Implicit Casting (Widening)
        private static void DemonstrateImplicitCasting()
        {
            Console.WriteLine("=== Implicit Casting (Widening) ===");
            Console.WriteLine("Automatic conversion from smaller to larger types");
            
            // Numeric type hierarchy: byte -> short -> int -> long -> float -> double
            byte byteValue = 10;
            short shortValue = byteValue; // byte to short
            int intValue = shortValue;    // short to int
            long longValue = intValue;    // int to long
            float floatValue = longValue; // long to float
            double doubleValue = floatValue; // float to double
            
            Console.WriteLine($"byte: {byteValue}");
            Console.WriteLine($"short: {shortValue}");
            Console.WriteLine($"int: {intValue}");
            Console.WriteLine($"long: {longValue}");
            Console.WriteLine($"float: {floatValue}");
            Console.WriteLine($"double: {doubleValue}");
            
            // char to int
            char charValue = 'A';
            int asciiValue = charValue;
            Console.WriteLine($"char 'A' to int: {asciiValue}");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Explicit Casting (Narrowing)
        private static void DemonstrateExplicitCasting()
        {
            Console.WriteLine("=== Explicit Casting (Narrowing) ===");
            Console.WriteLine("Manual conversion from larger to smaller types (potential data loss)");
            
            double doubleValue = 123.456;
            float floatValue = (float)doubleValue;
            long longValue = (long)doubleValue;
            int intValue = (int)doubleValue;
            short shortValue = (short)intValue;
            byte byteValue = (byte)shortValue;
            
            Console.WriteLine($"double: {doubleValue}");
            Console.WriteLine($"float: {floatValue}");
            Console.WriteLine($"long: {longValue}");
            Console.WriteLine($"int: {intValue}");
            Console.WriteLine($"short: {shortValue}");
            Console.WriteLine($"byte: {byteValue}");
            
            // Demonstrating data loss
            Console.WriteLine("\nData loss examples:");
            double largeDouble = 300.75;
            byte smallByte = (byte)largeDouble; // 300 > 255, wraps around
            Console.WriteLine($"300.75 cast to byte: {smallByte} (data loss!)");
            
            int negativeInt = -50;
            uint unsignedInt = (uint)negativeInt; // Negative to unsigned
            Console.WriteLine($"-50 cast to uint: {unsignedInt} (unexpected result!)");
            
            // char casting
            int asciiCode = 65;
            char character = (char)asciiCode;
            Console.WriteLine($"ASCII 65 to char: '{character}'");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Conversion Methods
        private static void DemonstrateConversionMethods()
        {
            Console.WriteLine("=== System.Convert Methods ===");
            Console.WriteLine("Safe conversion methods with overflow checking");
            
            try
            {
                double doubleValue = 123.456;
                
                // Convert class methods
                int convertedInt = Convert.ToInt32(doubleValue);
                bool convertedBool = Convert.ToBoolean(1);
                string convertedString = Convert.ToString(doubleValue);
                DateTime convertedDate = Convert.ToDateTime("2023-12-25");
                
                Console.WriteLine($"Convert.ToInt32({doubleValue}): {convertedInt}");
                Console.WriteLine($"Convert.ToBoolean(1): {convertedBool}");
                Console.WriteLine($"Convert.ToString({doubleValue}): {convertedString}");
                Console.WriteLine($"Convert.ToDateTime(\"2023-12-25\"): {convertedDate:yyyy-MM-dd}");
                
                // Base conversions
                int number = 42;
                string binary = Convert.ToString(number, 2);
                string octal = Convert.ToString(number, 8);
                string hexadecimal = Convert.ToString(number, 16);
                
                Console.WriteLine($"\nBase conversions for {number}:");
                Console.WriteLine($"Binary: {binary}");
                Console.WriteLine($"Octal: {octal}");
                Console.WriteLine($"Hexadecimal: {hexadecimal}");
                
                // Converting back
                int fromBinary = Convert.ToInt32(binary, 2);
                int fromHex = Convert.ToInt32("2A", 16);
                Console.WriteLine($"From binary '{binary}': {fromBinary}");
                Console.WriteLine($"From hex '2A': {fromHex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Conversion error: {ex.Message}");
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region Parsing Methods
        private static void DemonstrateParsingMethods()
        {
            Console.WriteLine("=== Parsing Methods ===");
            Console.WriteLine("Converting strings to specific types");
            
            try
            {
                // Basic parsing
                string intString = "123";
                string doubleString = "123.456";
                string boolString = "true";
                string dateString = "2023-12-25";
                
                int parsedInt = int.Parse(intString);
                double parsedDouble = double.Parse(doubleString);
                bool parsedBool = bool.Parse(boolString);
                DateTime parsedDate = DateTime.Parse(dateString);
                
                Console.WriteLine($"int.Parse(\"{intString}\"): {parsedInt}");
                Console.WriteLine($"double.Parse(\"{doubleString}\"): {parsedDouble}");
                Console.WriteLine($"bool.Parse(\"{boolString}\"): {parsedBool}");
                Console.WriteLine($"DateTime.Parse(\"{dateString}\"): {parsedDate:yyyy-MM-dd}");
                
                // Parsing with culture info
                string numberWithComma = "1,234.56";
                double cultureParsed = double.Parse(numberWithComma, System.Globalization.NumberStyles.AllowThousands | System.Globalization.NumberStyles.AllowDecimalPoint);
                Console.WriteLine($"Culture-aware parse \"{numberWithComma}\": {cultureParsed}");
                
                // Enum parsing
                string dayString = "Monday";
                DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayString);
                Console.WriteLine($"Enum.Parse(\"{dayString}\"): {day}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Parsing error: {ex.Message}");
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region TryParse Methods
        private static void DemonstrateTryParseMethods()
        {
            Console.WriteLine("=== TryParse Methods ===");
            Console.WriteLine("Safe parsing without exceptions");
            
            // Successful parsing
            string validInt = "123";
            if (int.TryParse(validInt, out int result1))
            {
                Console.WriteLine($"TryParse(\"{validInt}\"): Success = {result1}");
            }
            
            // Failed parsing
            string invalidInt = "abc";
            if (int.TryParse(invalidInt, out int result2))
            {
                Console.WriteLine($"TryParse(\"{invalidInt}\"): Success = {result2}");
            }
            else
            {
                Console.WriteLine($"TryParse(\"{invalidInt}\"): Failed, result = {result2}");
            }
            
            // Various TryParse examples
            var testValues = new[]
            {
                ("123.456", "double"),
                ("true", "bool"),
                ("2023-12-25", "DateTime"),
                ("invalid", "int"),
                ("3.14159", "float")
            };
            
            Console.WriteLine("\nTryParse results:");
            foreach (var (value, type) in testValues)
            {
                switch (type)
                {
                    case "double":
                        bool doubleSuccess = double.TryParse(value, out double doubleResult);
                        Console.WriteLine($"double.TryParse(\"{value}\"): {doubleSuccess}, Result: {doubleResult}");
                        break;
                    case "bool":
                        bool boolSuccess = bool.TryParse(value, out bool boolResult);
                        Console.WriteLine($"bool.TryParse(\"{value}\"): {boolSuccess}, Result: {boolResult}");
                        break;
                    case "DateTime":
                        bool dateSuccess = DateTime.TryParse(value, out DateTime dateResult);
                        Console.WriteLine($"DateTime.TryParse(\"{value}\"): {dateSuccess}, Result: {dateResult:yyyy-MM-dd}");
                        break;
                    case "int":
                        bool intSuccess = int.TryParse(value, out int intResult);
                        Console.WriteLine($"int.TryParse(\"{value}\"): {intSuccess}, Result: {intResult}");
                        break;
                    case "float":
                        bool floatSuccess = float.TryParse(value, out float floatResult);
                        Console.WriteLine($"float.TryParse(\"{value}\"): {floatSuccess}, Result: {floatResult}");
                        break;
                }
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region As and Is Operators
        private static void DemonstrateAsAndIsOperators()
        {
            Console.WriteLine("=== 'as' and 'is' Operators ===");
            Console.WriteLine("Safe casting for reference types and pattern matching");
            
            object[] objects = { "Hello", 123, 45.67, true, new Person("Alice"), null };
            
            foreach (object obj in objects)
            {
                Console.WriteLine($"\nTesting object: {obj ?? "null"} (Type: {obj?.GetType().Name ?? "null"})");
                
                // 'is' operator for type checking
                if (obj is string)
                    Console.WriteLine("  - Is string: Yes");
                else if (obj is int)
                    Console.WriteLine("  - Is int: Yes");
                else if (obj is double)
                    Console.WriteLine("  - Is double: Yes");
                else if (obj is Person)
                    Console.WriteLine("  - Is Person: Yes");
                else
                    Console.WriteLine("  - Is recognized type: No");
                
                // 'as' operator for safe casting
                string asString = obj as string;
                if (asString != null)
                    Console.WriteLine($"  - As string: '{asString}'");
                
                Person asPerson = obj as Person;
                if (asPerson != null)
                    Console.WriteLine($"  - As Person: {asPerson.Name}");
                
                // Pattern matching with 'is' (C# 7.0+)
                if (obj is string str)
                    Console.WriteLine($"  - Pattern match string: '{str}'");
                else if (obj is int number)
                    Console.WriteLine($"  - Pattern match int: {number}");
                else if (obj is Person person)
                    Console.WriteLine($"  - Pattern match Person: {person.Name}");
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region Custom Conversions
        private static void DemonstrateCustomConversions()
        {
            Console.WriteLine("=== Custom Conversions ===");
            Console.WriteLine("User-defined implicit and explicit operators");
            
            // Implicit conversion
            Temperature temp1 = 25.5; // Implicit conversion from double
            Console.WriteLine($"Implicit conversion from double: {temp1}");
            
            // Explicit conversion
            Temperature temp2 = new Temperature(100);
            double celsius = (double)temp2; // Explicit conversion to double
            Console.WriteLine($"Explicit conversion to double: {celsius}°C");
            
            // Custom conversion methods
            string tempString = temp2.ToString();
            Console.WriteLine($"Custom ToString(): {tempString}");
            
            // Conversion between custom types
            Distance distance = new Distance(1000); // meters
            Weight weight = (Weight)distance; // Custom conversion
            Console.WriteLine($"Custom conversion Distance to Weight: {weight}");
            
            Console.WriteLine();
        }
        #endregion
    }
    
    // Supporting classes for demonstrations
    public class Person
    {
        public string Name { get; set; }
        
        public Person(string name)
        {
            Name = name;
        }
    }
    
    public class Temperature
    {
        public double Celsius { get; private set; }
        
        public Temperature(double celsius)
        {
            Celsius = celsius;
        }
        
        // Implicit conversion from double
        public static implicit operator Temperature(double celsius)
        {
            return new Temperature(celsius);
        }
        
        // Explicit conversion to double
        public static explicit operator double(Temperature temperature)
        {
            return temperature.Celsius;
        }
        
        public override string ToString()
        {
            return $"{Celsius}°C";
        }
    }
    
    public class Distance
    {
        public double Meters { get; private set; }
        
        public Distance(double meters)
        {
            Meters = meters;
        }
        
        public override string ToString()
        {
            return $"{Meters} meters";
        }
    }
    
    public class Weight
    {
        public double Kilograms { get; private set; }
        
        public Weight(double kilograms)
        {
            Kilograms = kilograms;
        }
        
        // Custom conversion from Distance (1 meter = 1 kg for demo)
        public static explicit operator Weight(Distance distance)
        {
            return new Weight(distance.Meters / 1000); // Simplified conversion
        }
        
        public override string ToString()
        {
            return $"{Kilograms} kg";
        }
    }
}