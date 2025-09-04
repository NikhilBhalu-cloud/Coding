using System;

/// <summary>
/// Encapsulation in C#
/// Demonstrates data hiding, access modifiers, properties, and information hiding principles
/// </summary>
namespace CSharpOOPs
{
    public class Encapsulation
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Encapsulation in C# ===\n");
            
            DemonstrateBasicEncapsulation();
            DemonstratePropertiesAndValidation();
            DemonstrateAccessModifiers();
            DemonstrateDataHiding();
            DemonstratePropertyTypes();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Basic Encapsulation
        private static void DemonstrateBasicEncapsulation()
        {
            Console.WriteLine("=== Basic Encapsulation ===");
            
            // Creating a bank account - internal data is hidden
            BankAccount account = new BankAccount("12345", "John Doe", 1000);
            
            // Can access public properties
            Console.WriteLine($"Account Holder: {account.AccountHolder}");
            Console.WriteLine($"Current Balance: ${account.Balance:F2}");
            
            // Cannot directly access private fields
            // account._balance = 5000; // This would cause compilation error
            
            // Must use public methods to interact with the object
            account.Deposit(500);
            account.Withdraw(200);
            
            // Property with validation
            try
            {
                account.Balance = -100; // This will trigger validation
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validation Error: {ex.Message}");
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region Properties and Validation
        private static void DemonstratePropertiesAndValidation()
        {
            Console.WriteLine("=== Properties with Validation ===");
            
            Person person = new Person();
            
            // Setting valid values
            person.Name = "Alice Smith";
            person.Age = 25;
            person.Email = "alice@example.com";
            
            Console.WriteLine($"Person: {person.Name}, Age: {person.Age}, Email: {person.Email}");
            
            // Testing validation
            try
            {
                person.Age = -5; // Invalid age
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Age Validation Error: {ex.Message}");
            }
            
            try
            {
                person.Email = "invalid-email"; // Invalid email format
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Email Validation Error: {ex.Message}");
            }
            
            // Read-only property
            Console.WriteLine($"Person created at: {person.CreatedAt}");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Access Modifiers
        private static void DemonstrateAccessModifiers()
        {
            Console.WriteLine("=== Access Modifiers ===");
            
            EncapsulationDemo demo = new EncapsulationDemo();
            
            // Public members - accessible
            demo.PublicProperty = "Accessible from outside";
            demo.PublicMethod();
            
            // Private members - not accessible
            // demo.PrivateField = "Error"; // Compilation error
            // demo.PrivateMethod(); // Compilation error
            
            // Protected members - not accessible from outside
            // demo.ProtectedProperty = "Error"; // Compilation error
            
            // Internal members - accessible within same assembly
            demo.InternalProperty = "Accessible within assembly";
            demo.InternalMethod();
            
            Console.WriteLine();
        }
        #endregion
        
        #region Data Hiding
        private static void DemonstrateDataHiding()
        {
            Console.WriteLine("=== Data Hiding ===");
            
            // Temperature class hides the implementation details
            Temperature temp = new Temperature();
            
            // Set temperature using public interface
            temp.SetCelsius(25);
            Console.WriteLine($"Temperature: {temp.GetCelsius()}°C, {temp.GetFahrenheit()}°F, {temp.GetKelvin()}K");
            
            temp.SetFahrenheit(77);
            Console.WriteLine($"Temperature: {temp.GetCelsius():F1}°C, {temp.GetFahrenheit()}°F, {temp.GetKelvin():F1}K");
            
            // The internal storage and conversion logic is hidden
            
            Console.WriteLine();
        }
        #endregion
        
        #region Property Types
        private static void DemonstratePropertyTypes()
        {
            Console.WriteLine("=== Different Property Types ===");
            
            Product product = new Product("Laptop", 999.99m);
            
            // Auto-implemented property
            product.Category = "Electronics";
            Console.WriteLine($"Category: {product.Category}");
            
            // Read-only property
            Console.WriteLine($"Product ID: {product.Id}");
            
            // Calculated property
            Console.WriteLine($"Display Name: {product.DisplayName}");
            
            // Property with private setter
            Console.WriteLine($"Created Date: {product.CreatedDate}");
            
            // Property with validation in setter
            try
            {
                product.Price = -50; // Invalid price
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Price Validation: {ex.Message}");
            }
            
            Console.WriteLine();
        }
        #endregion
    }
    
    #region BankAccount Class - Basic Encapsulation
    public class BankAccount
    {
        // Private fields - encapsulated data
        private string _accountNumber;
        private string _accountHolder;
        private decimal _balance;
        private DateTime _lastTransactionDate;
        
        // Constructor
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance)
        {
            _accountNumber = accountNumber;
            _accountHolder = accountHolder;
            _balance = initialBalance >= 0 ? initialBalance : 0;
            _lastTransactionDate = DateTime.Now;
        }
        
        // Public properties with controlled access
        public string AccountNumber
        {
            get { return _accountNumber; }
            // No setter - account number cannot be changed after creation
        }
        
        public string AccountHolder
        {
            get { return _accountHolder; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Account holder name cannot be empty");
                _accountHolder = value;
            }
        }
        
        public decimal Balance
        {
            get { return _balance; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Balance cannot be negative");
                _balance = value;
                _lastTransactionDate = DateTime.Now;
            }
        }
        
        public DateTime LastTransactionDate
        {
            get { return _lastTransactionDate; }
            // Private setter - only this class can modify it
        }
        
        // Public methods to interact with private data
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive");
            
            _balance += amount;
            _lastTransactionDate = DateTime.Now;
            Console.WriteLine($"Deposited ${amount:F2}. New balance: ${_balance:F2}");
        }
        
        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive");
            
            if (amount > _balance)
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }
            
            _balance -= amount;
            _lastTransactionDate = DateTime.Now;
            Console.WriteLine($"Withdrew ${amount:F2}. New balance: ${_balance:F2}");
            return true;
        }
        
        // Private method - internal implementation detail
        private void LogTransaction(string transactionType, decimal amount)
        {
            Console.WriteLine($"[LOG] {DateTime.Now}: {transactionType} of ${amount:F2}");
        }
    }
    #endregion
    
    #region Person Class - Property Validation
    public class Person
    {
        private string _name;
        private int _age;
        private string _email;
        
        // Property with validation
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                if (value.Length < 2)
                    throw new ArgumentException("Name must be at least 2 characters long");
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
        
        public string Email
        {
            get { return _email; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Email cannot be empty");
                if (!value.Contains("@") || !value.Contains("."))
                    throw new ArgumentException("Invalid email format");
                _email = value;
            }
        }
        
        // Read-only property
        public DateTime CreatedAt { get; } = DateTime.Now;
        
        // Calculated property
        public string DisplayInfo => $"{Name} ({Age} years old) - {Email}";
    }
    #endregion
    
    #region Access Modifiers Demo
    public class EncapsulationDemo
    {
        // Public - accessible from anywhere
        public string PublicProperty { get; set; } = "Public";
        
        // Private - accessible only within this class
        private string PrivateField = "Private";
        
        // Protected - accessible within this class and derived classes
        protected string ProtectedProperty { get; set; } = "Protected";
        
        // Internal - accessible within the same assembly
        internal string InternalProperty { get; set; } = "Internal";
        
        // Protected Internal - accessible within same assembly or derived classes
        protected internal string ProtectedInternalProperty { get; set; } = "Protected Internal";
        
        // Public method
        public void PublicMethod()
        {
            Console.WriteLine("Public method called");
            // Can access all members from within the class
            Console.WriteLine($"Accessing private field: {PrivateField}");
        }
        
        // Private method
        private void PrivateMethod()
        {
            Console.WriteLine("Private method called");
        }
        
        // Protected method
        protected void ProtectedMethod()
        {
            Console.WriteLine("Protected method called");
        }
        
        // Internal method
        internal void InternalMethod()
        {
            Console.WriteLine("Internal method called");
        }
    }
    #endregion
    
    #region Temperature Class - Data Hiding
    public class Temperature
    {
        // Private field - implementation detail is hidden
        private double _celsius;
        
        // Public interface methods
        public void SetCelsius(double celsius)
        {
            _celsius = celsius;
        }
        
        public void SetFahrenheit(double fahrenheit)
        {
            // Internal conversion logic is hidden
            _celsius = (fahrenheit - 32) * 5 / 9;
        }
        
        public void SetKelvin(double kelvin)
        {
            _celsius = kelvin - 273.15;
        }
        
        public double GetCelsius()
        {
            return _celsius;
        }
        
        public double GetFahrenheit()
        {
            return (_celsius * 9 / 5) + 32;
        }
        
        public double GetKelvin()
        {
            return _celsius + 273.15;
        }
    }
    #endregion
    
    #region Product Class - Different Property Types
    public class Product
    {
        private static int _nextId = 1;
        private decimal _price;
        
        public Product(string name, decimal price)
        {
            Id = _nextId++;
            Name = name;
            Price = price;
            CreatedDate = DateTime.Now;
        }
        
        // Read-only property
        public int Id { get; }
        
        // Auto-implemented property
        public string Name { get; set; }
        public string Category { get; set; }
        
        // Property with validation
        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative");
                _price = value;
            }
        }
        
        // Property with private setter
        public DateTime CreatedDate { get; private set; }
        
        // Calculated property (expression-bodied)
        public string DisplayName => $"{Name} - ${Price:F2}";
        
        // Property with both getter and setter logic
        public string Description
        {
            get { return $"{Name} in {Category ?? "General"} category"; }
            set
            {
                // Could perform validation or transformation here
                // For this example, we'll just ignore the setter
            }
        }
    }
    #endregion
}