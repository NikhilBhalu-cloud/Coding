using System;

/// <summary>
/// Pass by Value vs Reference in C#
/// Demonstrates ref, out, and in parameters
/// </summary>
namespace CSharpBasics
{
    public class PassByValueAndReference
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Pass by Value vs Reference in C# ===\n");
            
            DemonstratePassByValue();
            DemonstratePassByReference();
            DemonstrateOutParameters();
            DemonstrateInParameters();
            DemonstrateReferenceTypes();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Pass by Value (Default)
        private static void DemonstratePassByValue()
        {
            Console.WriteLine("=== Pass by Value (Default) ===");
            
            int originalValue = 10;
            Console.WriteLine($"Before method call: originalValue = {originalValue}");
            
            ModifyByValue(originalValue);
            Console.WriteLine($"After method call: originalValue = {originalValue}");
            Console.WriteLine("Value unchanged - passed by value\n");
        }
        
        private static void ModifyByValue(int value)
        {
            Console.WriteLine($"Inside method before modification: value = {value}");
            value = 100;
            Console.WriteLine($"Inside method after modification: value = {value}");
        }
        #endregion
        
        #region Pass by Reference (ref)
        private static void DemonstratePassByReference()
        {
            Console.WriteLine("=== Pass by Reference (ref) ===");
            
            int originalValue = 10;
            Console.WriteLine($"Before method call: originalValue = {originalValue}");
            
            ModifyByReference(ref originalValue);
            Console.WriteLine($"After method call: originalValue = {originalValue}");
            Console.WriteLine("Value changed - passed by reference\n");
            
            // ref with multiple values
            int a = 5, b = 15;
            Console.WriteLine($"Before swap: a = {a}, b = {b}");
            SwapValues(ref a, ref b);
            Console.WriteLine($"After swap: a = {a}, b = {b}\n");
        }
        
        private static void ModifyByReference(ref int value)
        {
            Console.WriteLine($"Inside method before modification: value = {value}");
            value = 200;
            Console.WriteLine($"Inside method after modification: value = {value}");
        }
        
        private static void SwapValues(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }
        #endregion
        
        #region Out Parameters
        private static void DemonstrateOutParameters()
        {
            Console.WriteLine("=== Out Parameters ===");
            
            // out parameter doesn't need to be initialized
            int result;
            bool success = TryParse("123", out result);
            Console.WriteLine($"TryParse(\"123\"): Success = {success}, Result = {result}");
            
            bool success2 = TryParse("abc", out int result2); // inline declaration
            Console.WriteLine($"TryParse(\"abc\"): Success = {success2}, Result = {result2}");
            
            // Multiple out parameters
            int quotient, remainder;
            Divide(17, 5, out quotient, out remainder);
            Console.WriteLine($"17 ÷ 5 = {quotient} remainder {remainder}");
            
            // out with different types
            string name;
            int age;
            bool isValid = GetPersonInfo("Alice:25", out name, out age);
            Console.WriteLine($"GetPersonInfo: Valid = {isValid}, Name = {name}, Age = {age}\n");
        }
        
        private static bool TryParse(string input, out int result)
        {
            // out parameter must be assigned before method returns
            if (int.TryParse(input, out result))
            {
                return true;
            }
            result = 0; // Must assign even on failure
            return false;
        }
        
        private static void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }
        
        private static bool GetPersonInfo(string data, out string name, out int age)
        {
            name = "";
            age = 0;
            
            string[] parts = data.Split(':');
            if (parts.Length == 2)
            {
                name = parts[0];
                return int.TryParse(parts[1], out age);
            }
            return false;
        }
        #endregion
        
        #region In Parameters (C# 7.2+)
        private static void DemonstrateInParameters()
        {
            Console.WriteLine("=== In Parameters (C# 7.2+) ===");
            
            var largeStruct = new LargeStruct
            {
                Value1 = 100,
                Value2 = 200,
                Value3 = 300,
                Description = "Large struct for performance demo"
            };
            
            Console.WriteLine("Using 'in' parameter for large struct (readonly reference):");
            ProcessLargeStruct(in largeStruct);
            
            // in parameter prevents modification
            // This would cause compilation error:
            // ProcessAndModify(in largeStruct);
            
            Console.WriteLine();
        }
        
        private static void ProcessLargeStruct(in LargeStruct data)
        {
            // 'in' parameter is passed by readonly reference
            // Cannot modify the parameter inside the method
            Console.WriteLine($"Processing: {data.Description}");
            Console.WriteLine($"Values: {data.Value1}, {data.Value2}, {data.Value3}");
            
            // This would cause compilation error:
            // data.Value1 = 999;
        }
        
        // This method would cause compilation error with 'in' parameter
        /*
        private static void ProcessAndModify(in LargeStruct data)
        {
            data.Value1 = 999; // Error: Cannot modify readonly reference
        }
        */
        #endregion
        
        #region Reference Types
        private static void DemonstrateReferenceTypes()
        {
            Console.WriteLine("=== Reference Types Behavior ===");
            
            // Reference types are always passed by reference (to the reference)
            var person = new Person { Name = "John", Age = 25 };
            Console.WriteLine($"Before method: Name = {person.Name}, Age = {person.Age}");
            
            ModifyPerson(person);
            Console.WriteLine($"After ModifyPerson: Name = {person.Name}, Age = {person.Age}");
            
            ReassignPerson(person);
            Console.WriteLine($"After ReassignPerson: Name = {person.Name}, Age = {person.Age}");
            
            // Using ref with reference types
            ReassignPersonWithRef(ref person);
            Console.WriteLine($"After ReassignPersonWithRef: Name = {person?.Name ?? "null"}, Age = {person?.Age ?? 0}");
            
            // Arrays (reference types)
            int[] numbers = { 1, 2, 3, 4, 5 };
            Console.WriteLine($"\nBefore ModifyArray: [{string.Join(", ", numbers)}]");
            ModifyArray(numbers);
            Console.WriteLine($"After ModifyArray: [{string.Join(", ", numbers)}]");
        }
        
        private static void ModifyPerson(Person p)
        {
            // Modifying the object that p refers to
            p.Name = "Modified John";
            p.Age = 30;
        }
        
        private static void ReassignPerson(Person p)
        {
            // This only changes the local reference, not the original
            p = new Person { Name = "New Person", Age = 99 };
        }
        
        private static void ReassignPersonWithRef(ref Person p)
        {
            // This changes the original reference
            p = null; // or new Person { Name = "Ref Person", Age = 50 };
        }
        
        private static void ModifyArray(int[] arr)
        {
            // Modifying the array elements
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] *= 2;
            }
        }
        #endregion
    }
    
    // Supporting classes and structs
    public struct LargeStruct
    {
        public int Value1;
        public int Value2;
        public int Value3;
        public string Description;
    }
    
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}