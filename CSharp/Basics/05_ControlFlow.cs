using System;

/// <summary>
/// Control Flow in C#
/// Demonstrates if, else, else if, and switch statements
/// </summary>
namespace CSharpBasics
{
    public class ControlFlow
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Control Flow in C# ===\n");
            
            // if-else statements
            Console.WriteLine("=== if-else Statements ===");
            DemonstrateIfElse();
            
            Console.WriteLine("\n=== switch Statements ===");
            DemonstrateSwitchStatement();
            
            Console.WriteLine("\n=== switch Expression (C# 8.0+) ===");
            DemonstrateSwitchExpression();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        private static void DemonstrateIfElse()
        {
            int score = 85;
            
            Console.WriteLine($"Student Score: {score}");
            
            // Simple if-else
            if (score >= 90)
            {
                Console.WriteLine("Grade: A (Excellent!)");
            }
            else if (score >= 80)
            {
                Console.WriteLine("Grade: B (Good!)");
            }
            else if (score >= 70)
            {
                Console.WriteLine("Grade: C (Average)");
            }
            else if (score >= 60)
            {
                Console.WriteLine("Grade: D (Below Average)");
            }
            else
            {
                Console.WriteLine("Grade: F (Fail)");
            }
            
            // Nested if statements
            Console.WriteLine("\n--- Nested if Example ---");
            int age = 25;
            bool hasLicense = true;
            
            Console.WriteLine($"Age: {age}, Has License: {hasLicense}");
            
            if (age >= 18)
            {
                if (hasLicense)
                {
                    Console.WriteLine("Can drive legally!");
                }
                else
                {
                    Console.WriteLine("Old enough but needs a license.");
                }
            }
            else
            {
                Console.WriteLine("Too young to drive.");
            }
            
            // Logical operators in conditions
            Console.WriteLine("\n--- Logical Operators in Conditions ---");
            bool isWeekend = true;
            bool isHoliday = false;
            
            if (isWeekend || isHoliday)
            {
                Console.WriteLine("No work today!");
            }
            
            if (age >= 18 && hasLicense)
            {
                Console.WriteLine("Eligible to rent a car.");
            }
        }
        
        private static void DemonstrateSwitchStatement()
        {
            // Traditional switch statement
            int dayOfWeek = 3;
            
            Console.WriteLine($"Day number: {dayOfWeek}");
            
            switch (dayOfWeek)
            {
                case 1:
                    Console.WriteLine("Monday - Start of work week");
                    break;
                case 2:
                    Console.WriteLine("Tuesday - Getting into the groove");
                    break;
                case 3:
                    Console.WriteLine("Wednesday - Hump day!");
                    break;
                case 4:
                    Console.WriteLine("Thursday - Almost there");
                    break;
                case 5:
                    Console.WriteLine("Friday - TGIF!");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Weekend - Time to relax!");
                    break;
                default:
                    Console.WriteLine("Invalid day number");
                    break;
            }
            
            // Switch with string
            Console.WriteLine("\n--- String Switch Example ---");
            string operation = "ADD";
            int a = 10, b = 5;
            
            Console.WriteLine($"Operation: {operation}, a = {a}, b = {b}");
            
            switch (operation.ToUpper())
            {
                case "ADD":
                    Console.WriteLine($"Result: {a + b}");
                    break;
                case "SUBTRACT":
                    Console.WriteLine($"Result: {a - b}");
                    break;
                case "MULTIPLY":
                    Console.WriteLine($"Result: {a * b}");
                    break;
                case "DIVIDE":
                    if (b != 0)
                        Console.WriteLine($"Result: {a / b}");
                    else
                        Console.WriteLine("Error: Division by zero");
                    break;
                default:
                    Console.WriteLine("Unknown operation");
                    break;
            }
        }
        
        private static void DemonstrateSwitchExpression()
        {
            // Switch expression (C# 8.0+)
            int month = 6;
            
            string season = month switch
            {
                12 or 1 or 2 => "Winter",
                3 or 4 or 5 => "Spring",
                6 or 7 or 8 => "Summer",
                9 or 10 or 11 => "Fall",
                _ => "Invalid month"
            };
            
            Console.WriteLine($"Month {month} is in {season}");
            
            // Switch expression with complex conditions
            var weather = (Temperature: 25, IsRaining: false, IsWindy: true);
            
            string activity = weather switch
            {
                { Temperature: > 30, IsRaining: false } => "Beach day!",
                { Temperature: > 20, IsRaining: false, IsWindy: false } => "Perfect for outdoor activities",
                { Temperature: > 15, IsRaining: false } => "Good for a walk",
                { IsRaining: true } => "Stay indoors or bring an umbrella",
                { Temperature: < 10 } => "Too cold, stay warm inside",
                _ => "Check the weather again"
            };
            
            Console.WriteLine($"Weather: {weather.Temperature}°C, Raining: {weather.IsRaining}, Windy: {weather.IsWindy}");
            Console.WriteLine($"Recommendation: {activity}");
        }
    }
}