using System;

/// <summary>
/// Classes and Objects in C#
/// Demonstrates the fundamental concepts of object-oriented programming
/// </summary>
namespace CSharpOOPs
{
    public class ClassesAndObjects
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Classes and Objects in C# ===\n");
            
            DemonstrateBasicClassUsage();
            DemonstrateConstructors();
            DemonstratePropertiesAndFields();
            DemonstrateStaticMembers();
            DemonstrateAccessModifiers();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Basic Class Usage
        private static void DemonstrateBasicClassUsage()
        {
            Console.WriteLine("=== Basic Class Usage ===");
            
            // Creating objects (instances) of a class
            Person person1 = new Person();
            Person person2 = new Person("Alice", 25);
            Person person3 = new Person("Bob", 30, "Engineer");
            
            // Using object methods
            person1.SetDetails("Charlie", 35);
            person1.DisplayInfo();
            person2.DisplayInfo();
            person3.DisplayInfo();
            
            // Object properties
            Console.WriteLine($"Person1 age: {person1.Age}");
            person1.Age = 36; // Using property setter
            Console.WriteLine($"Person1 updated age: {person1.Age}");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Constructors
        private static void DemonstrateConstructors()
        {
            Console.WriteLine("=== Constructors ===");
            
            // Default constructor
            Car car1 = new Car();
            car1.DisplayInfo();
            
            // Parameterized constructor
            Car car2 = new Car("Toyota", "Camry");
            car2.DisplayInfo();
            
            // Constructor with all parameters
            Car car3 = new Car("Honda", "Civic", 2023);
            car3.DisplayInfo();
            
            // Copy constructor
            Car car4 = new Car(car3);
            car4.DisplayInfo();
            
            Console.WriteLine();
        }
        #endregion
        
        #region Properties and Fields
        private static void DemonstratePropertiesAndFields()
        {
            Console.WriteLine("=== Properties and Fields ===");
            
            BankAccount account = new BankAccount("ACC123", 1000);
            
            // Public property access
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: ${account.Balance:F2}");
            
            // Property with validation
            try
            {
                account.Balance = -500; // This will throw an exception
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            // Method calls that use private fields
            account.Deposit(500);
            account.Withdraw(200);
            
            // Auto-implemented properties
            Student student = new Student
            {
                Id = 1,
                Name = "John Doe",
                Grade = "A"
            };
            
            Console.WriteLine($"Student: {student.Name}, Grade: {student.Grade}");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Static Members
        private static void DemonstrateStaticMembers()
        {
            Console.WriteLine("=== Static Members ===");
            
            // Static field access
            Console.WriteLine($"Math PI: {MathUtility.PI}");
            
            // Static method calls
            double area = MathUtility.CalculateCircleArea(5);
            Console.WriteLine($"Circle area (radius 5): {area:F2}");
            
            // Instance counter using static
            Console.WriteLine("Creating Counter instances:");
            Counter c1 = new Counter();
            Counter c2 = new Counter();
            Counter c3 = new Counter();
            
            Console.WriteLine($"Total counters created: {Counter.TotalInstances}");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Access Modifiers
        private static void DemonstrateAccessModifiers()
        {
            Console.WriteLine("=== Access Modifiers ===");
            
            AccessModifierDemo demo = new AccessModifierDemo();
            
            // Public members - accessible
            demo.PublicField = "Public access";
            demo.PublicMethod();
            
            // Private members - not accessible from outside
            // demo.privateField = "Error"; // Compilation error
            // demo.PrivateMethod(); // Compilation error
            
            // Protected members - not accessible from outside
            // demo.protectedField = "Error"; // Compilation error
            
            // Internal members - accessible within same assembly
            demo.InternalField = "Internal access";
            demo.InternalMethod();
            
            Console.WriteLine();
        }
        #endregion
    }
    
    #region Person Class
    /// <summary>
    /// Represents a person with basic information
    /// </summary>
    public class Person
    {
        // Private fields (encapsulation)
        private string _name;
        private int _age;
        private string _occupation;
        
        // Properties with validation
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                _name = value;
            }
        }
        
        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Age must be between 0 and 150");
                _age = value;
            }
        }
        
        public string Occupation
        {
            get { return _occupation; }
            set { _occupation = value ?? "Unemployed"; }
        }
        
        // Constructors
        public Person() // Default constructor
        {
            _name = "Unknown";
            _age = 0;
            _occupation = "Unknown";
        }
        
        public Person(string name, int age) // Parameterized constructor
        {
            Name = name; // Using property for validation
            Age = age;   // Using property for validation
            _occupation = "Unknown";
        }
        
        public Person(string name, int age, string occupation) // Constructor with all parameters
        {
            Name = name;
            Age = age;
            Occupation = occupation;
        }
        
        // Methods
        public void SetDetails(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Occupation: {Occupation}");
        }
        
        public string GetFullInfo()
        {
            return $"Person [Name: {Name}, Age: {Age}, Occupation: {Occupation}]";
        }
    }
    #endregion
    
    #region Car Class
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        
        // Default constructor
        public Car()
        {
            Make = "Unknown";
            Model = "Unknown";
            Year = DateTime.Now.Year;
        }
        
        // Constructor with make and model
        public Car(string make, string model)
        {
            Make = make;
            Model = model;
            Year = DateTime.Now.Year;
        }
        
        // Constructor with all parameters
        public Car(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
        
        // Copy constructor
        public Car(Car other)
        {
            Make = other.Make;
            Model = other.Model;
            Year = other.Year;
        }
        
        public void DisplayInfo()
        {
            Console.WriteLine($"Car: {Year} {Make} {Model}");
        }
    }
    #endregion
    
    #region BankAccount Class
    public class BankAccount
    {
        // Private fields
        private string _accountNumber;
        private decimal _balance;
        
        // Public properties
        public string AccountNumber
        {
            get { return _accountNumber; }
            private set { _accountNumber = value; } // Private setter
        }
        
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                _balance = value;
            }
        }
        
        // Constructor
        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }
        
        // Methods
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");
            
            _balance += amount;
            Console.WriteLine($"Deposited ${amount:F2}. New balance: ${_balance:F2}");
        }
        
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");
            
            if (amount > _balance)
                throw new InvalidOperationException("Insufficient funds");
            
            _balance -= amount;
            Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${_balance:F2}");
        }
    }
    #endregion
    
    #region Student Class (Auto-implemented Properties)
    public class Student
    {
        // Auto-implemented properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Grade { get; set; }
        
        // Property with private setter
        public DateTime EnrollmentDate { get; private set; } = DateTime.Now;
        
        // Read-only property
        public string DisplayName => $"Student: {Name} (ID: {Id})";
    }
    #endregion
    
    #region Static Members Examples
    public static class MathUtility
    {
        // Static field
        public static readonly double PI = 3.14159265359;
        
        // Static method
        public static double CalculateCircleArea(double radius)
        {
            return PI * radius * radius;
        }
        
        public static double CalculateCircleCircumference(double radius)
        {
            return 2 * PI * radius;
        }
    }
    
    public class Counter
    {
        // Static field to track total instances
        public static int TotalInstances { get; private set; } = 0;
        
        // Instance field
        public int InstanceId { get; private set; }
        
        // Constructor
        public Counter()
        {
            TotalInstances++;
            InstanceId = TotalInstances;
            Console.WriteLine($"Counter #{InstanceId} created");
        }
        
        // Static method
        public static void ResetCounter()
        {
            TotalInstances = 0;
        }
    }
    #endregion
    
    #region Access Modifiers Demo
    public class AccessModifierDemo
    {
        // Public - accessible from anywhere
        public string PublicField = "Public field";
        
        // Private - accessible only within this class
        private string privateField = "Private field";
        
        // Protected - accessible within this class and derived classes
        protected string protectedField = "Protected field";
        
        // Internal - accessible within the same assembly
        internal string InternalField = "Internal field";
        
        // Protected internal - accessible within same assembly or derived classes
        protected internal string ProtectedInternalField = "Protected internal field";
        
        // Public method
        public void PublicMethod()
        {
            Console.WriteLine("Public method called");
            // Can access all fields from within the class
            Console.WriteLine($"Accessing private field: {privateField}");
        }
        
        // Private method
        private void PrivateMethod()
        {
            Console.WriteLine("Private method called");
        }
        
        // Internal method
        internal void InternalMethod()
        {
            Console.WriteLine("Internal method called");
        }
        
        // Protected method
        protected void ProtectedMethod()
        {
            Console.WriteLine("Protected method called");
        }
    }
    #endregion
}