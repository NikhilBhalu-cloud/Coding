using System;

/// <summary>
/// Polymorphism in C#
/// Demonstrates method overriding, method overloading, and runtime polymorphism
/// </summary>
namespace CSharpOOPs
{
    public class Polymorphism
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Polymorphism in C# ===\n");
            
            DemonstrateMethodOverloading();
            DemonstrateMethodOverriding();
            DemonstrateRuntimePolymorphism();
            DemonstratePolymorphicBehavior();
            DemonstrateVirtualMethods();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Method Overloading (Compile-time Polymorphism)
        private static void DemonstrateMethodOverloading()
        {
            Console.WriteLine("=== Method Overloading (Compile-time Polymorphism) ===");
            
            Calculator calc = new Calculator();
            
            // Same method name, different parameters
            Console.WriteLine($"Add(5, 3) = {calc.Add(5, 3)}");
            Console.WriteLine($"Add(5.5, 3.2) = {calc.Add(5.5, 3.2)}");
            Console.WriteLine($"Add(1, 2, 3) = {calc.Add(1, 2, 3)}");
            Console.WriteLine($"Add(\"Hello\", \"World\") = {calc.Add("Hello", "World")}");
            
            // Method overloading with different parameter types
            calc.Display(42);
            calc.Display(3.14);
            calc.Display("Polymorphism");
            calc.Display(true);
            
            Console.WriteLine();
        }
        #endregion
        
        #region Method Overriding (Runtime Polymorphism)
        private static void DemonstrateMethodOverriding()
        {
            Console.WriteLine("=== Method Overriding (Runtime Polymorphism) ===");
            
            // Base class reference, derived class object
            Animal animal1 = new Dog("Buddy");
            Animal animal2 = new Cat("Whiskers");
            Animal animal3 = new Bird("Tweety");
            
            // Polymorphic method calls - resolved at runtime
            animal1.MakeSound();  // Dog's version
            animal1.Move();       // Dog's version
            
            animal2.MakeSound();  // Cat's version
            animal2.Move();       // Cat's version
            
            animal3.MakeSound();  // Bird's version
            animal3.Move();       // Bird's version
            
            Console.WriteLine();
        }
        #endregion
        
        #region Runtime Polymorphism
        private static void DemonstrateRuntimePolymorphism()
        {
            Console.WriteLine("=== Runtime Polymorphism ===");
            
            // Array of base class references
            Shape[] shapes = {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 4, 5)
            };
            
            Console.WriteLine("Processing shapes polymorphically:");
            foreach (Shape shape in shapes)
            {
                // Virtual method calls - resolved at runtime based on actual object type
                Console.WriteLine($"Shape: {shape.GetType().Name}");
                Console.WriteLine($"Area: {shape.CalculateArea():F2}");
                Console.WriteLine($"Perimeter: {shape.CalculatePerimeter():F2}");
                shape.Draw(); // Virtual method
                Console.WriteLine();
            }
        }
        #endregion
        
        #region Polymorphic Behavior
        private static void DemonstratePolymorphicBehavior()
        {
            Console.WriteLine("=== Polymorphic Behavior ===");
            
            // Different payment methods using polymorphism
            PaymentProcessor processor = new PaymentProcessor();
            
            IPaymentMethod[] paymentMethods = {
                new CreditCard("1234-5678-9012-3456"),
                new PayPal("user@example.com"),
                new BankTransfer("123456789")
            };
            
            foreach (var paymentMethod in paymentMethods)
            {
                processor.ProcessPayment(paymentMethod, 100.00m);
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region Virtual Methods
        private static void DemonstrateVirtualMethods()
        {
            Console.WriteLine("=== Virtual Methods ===");
            
            Employee[] employees = {
                new FullTimeEmployee("John Doe", 50000),
                new PartTimeEmployee("Jane Smith", 25, 40),
                new ContractEmployee("Bob Johnson", 5000, 6)
            };
            
            foreach (Employee emp in employees)
            {
                emp.DisplayInfo();
                Console.WriteLine($"Monthly Salary: ${emp.CalculateSalary():F2}");
                Console.WriteLine();
            }
        }
        #endregion
    }
    
    #region Calculator Class - Method Overloading
    public class Calculator
    {
        // Method overloading - same name, different parameters
        public int Add(int a, int b)
        {
            Console.WriteLine("Adding two integers");
            return a + b;
        }
        
        public double Add(double a, double b)
        {
            Console.WriteLine("Adding two doubles");
            return a + b;
        }
        
        public int Add(int a, int b, int c)
        {
            Console.WriteLine("Adding three integers");
            return a + b + c;
        }
        
        public string Add(string a, string b)
        {
            Console.WriteLine("Concatenating two strings");
            return a + " " + b;
        }
        
        // Overloaded Display methods
        public void Display(int value)
        {
            Console.WriteLine($"Integer value: {value}");
        }
        
        public void Display(double value)
        {
            Console.WriteLine($"Double value: {value:F2}");
        }
        
        public void Display(string value)
        {
            Console.WriteLine($"String value: {value}");
        }
        
        public void Display(bool value)
        {
            Console.WriteLine($"Boolean value: {value}");
        }
    }
    #endregion
    
    #region Animal Hierarchy - Method Overriding
    public class Animal
    {
        public string Name { get; protected set; }
        
        public Animal(string name)
        {
            Name = name;
        }
        
        // Virtual methods can be overridden
        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} makes a generic animal sound");
        }
        
        public virtual void Move()
        {
            Console.WriteLine($"{Name} moves in a generic way");
        }
        
        // Non-virtual method - cannot be overridden
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping");
        }
    }
    
    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        
        // Override virtual methods
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} barks: Woof! Woof!");
        }
        
        public override void Move()
        {
            Console.WriteLine($"{Name} runs on four legs");
        }
        
        // Dog-specific method
        public void Fetch()
        {
            Console.WriteLine($"{Name} fetches the ball");
        }
    }
    
    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} meows: Meow! Meow!");
        }
        
        public override void Move()
        {
            Console.WriteLine($"{Name} walks gracefully");
        }
        
        public void Climb()
        {
            Console.WriteLine($"{Name} climbs a tree");
        }
    }
    
    public class Bird : Animal
    {
        public Bird(string name) : base(name) { }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{Name} chirps: Tweet! Tweet!");
        }
        
        public override void Move()
        {
            Console.WriteLine($"{Name} flies through the sky");
        }
        
        public void Fly()
        {
            Console.WriteLine($"{Name} soars high");
        }
    }
    #endregion
    
    #region Shape Hierarchy - Runtime Polymorphism
    public abstract class Shape
    {
        public string Name { get; protected set; }
        
        public Shape(string name)
        {
            Name = name;
        }
        
        // Abstract methods - must be implemented
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
        
        // Virtual method - can be overridden
        public virtual void Draw()
        {
            Console.WriteLine($"Drawing a {Name}");
        }
    }
    
    public class Circle : Shape
    {
        public double Radius { get; private set; }
        
        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
        }
        
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }
    
    public class Rectangle : Shape
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        
        public Rectangle(double width, double height) : base("Rectangle")
        {
            Width = width;
            Height = height;
        }
        
        public override double CalculateArea()
        {
            return Width * Height;
        }
        
        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Drawing a rectangle {Width} x {Height}");
        }
    }
    
    public class Triangle : Shape
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }
        
        public Triangle(double a, double b, double c) : base("Triangle")
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }
        
        public override double CalculateArea()
        {
            // Using Heron's formula
            double s = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
        }
        
        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }
        
        public override void Draw()
        {
            Console.WriteLine($"Drawing a triangle with sides {SideA}, {SideB}, {SideC}");
        }
    }
    #endregion
    
    #region Payment System - Interface Polymorphism
    public interface IPaymentMethod
    {
        void ProcessPayment(decimal amount);
        bool ValidatePaymentDetails();
    }
    
    public class CreditCard : IPaymentMethod
    {
        public string CardNumber { get; private set; }
        
        public CreditCard(string cardNumber)
        {
            CardNumber = cardNumber;
        }
        
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount:F2}");
            Console.WriteLine($"Card: ****-****-****-{CardNumber.Substring(CardNumber.Length - 4)}");
        }
        
        public bool ValidatePaymentDetails()
        {
            // Simplified validation
            return CardNumber.Length == 19;
        }
    }
    
    public class PayPal : IPaymentMethod
    {
        public string Email { get; private set; }
        
        public PayPal(string email)
        {
            Email = email;
        }
        
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount:F2}");
            Console.WriteLine($"PayPal account: {Email}");
        }
        
        public bool ValidatePaymentDetails()
        {
            return Email.Contains("@");
        }
    }
    
    public class BankTransfer : IPaymentMethod
    {
        public string AccountNumber { get; private set; }
        
        public BankTransfer(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
        
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing bank transfer of ${amount:F2}");
            Console.WriteLine($"Account: ****{AccountNumber.Substring(AccountNumber.Length - 4)}");
        }
        
        public bool ValidatePaymentDetails()
        {
            return AccountNumber.Length >= 8;
        }
    }
    
    public class PaymentProcessor
    {
        public void ProcessPayment(IPaymentMethod paymentMethod, decimal amount)
        {
            if (paymentMethod.ValidatePaymentDetails())
            {
                paymentMethod.ProcessPayment(amount);
                Console.WriteLine("Payment processed successfully\n");
            }
            else
            {
                Console.WriteLine("Invalid payment details\n");
            }
        }
    }
    #endregion
    
    #region Employee System - Virtual Methods
    public abstract class Employee
    {
        public string Name { get; protected set; }
        
        public Employee(string name)
        {
            Name = name;
        }
        
        // Virtual method - can be overridden
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Employee: {Name}");
        }
        
        // Abstract method - must be implemented
        public abstract decimal CalculateSalary();
    }
    
    public class FullTimeEmployee : Employee
    {
        public decimal AnnualSalary { get; private set; }
        
        public FullTimeEmployee(string name, decimal annualSalary) : base(name)
        {
            AnnualSalary = annualSalary;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Type: Full-time");
            Console.WriteLine($"Annual Salary: ${AnnualSalary:N2}");
        }
        
        public override decimal CalculateSalary()
        {
            return AnnualSalary / 12; // Monthly salary
        }
    }
    
    public class PartTimeEmployee : Employee
    {
        public decimal HourlyRate { get; private set; }
        public int HoursPerWeek { get; private set; }
        
        public PartTimeEmployee(string name, decimal hourlyRate, int hoursPerWeek) : base(name)
        {
            HourlyRate = hourlyRate;
            HoursPerWeek = hoursPerWeek;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Type: Part-time");
            Console.WriteLine($"Hourly Rate: ${HourlyRate:F2}");
            Console.WriteLine($"Hours per Week: {HoursPerWeek}");
        }
        
        public override decimal CalculateSalary()
        {
            return HourlyRate * HoursPerWeek * 4; // Monthly salary (4 weeks)
        }
    }
    
    public class ContractEmployee : Employee
    {
        public decimal MonthlyContract { get; private set; }
        public int ContractMonths { get; private set; }
        
        public ContractEmployee(string name, decimal monthlyContract, int contractMonths) : base(name)
        {
            MonthlyContract = monthlyContract;
            ContractMonths = contractMonths;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Type: Contract");
            Console.WriteLine($"Monthly Contract: ${MonthlyContract:N2}");
            Console.WriteLine($"Contract Duration: {ContractMonths} months");
        }
        
        public override decimal CalculateSalary()
        {
            return MonthlyContract;
        }
    }
    #endregion
}