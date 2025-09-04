using System;

/// <summary>
/// Inheritance in C#
/// Demonstrates inheritance, method overriding, base keyword, and inheritance hierarchies
/// </summary>
namespace CSharpOOPs
{
    public class Inheritance
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Inheritance in C# ===\n");
            
            DemonstrateBasicInheritance();
            DemonstrateMethodOverriding();
            DemonstrateBaseKeyword();
            DemonstrateMultilevelInheritance();
            DemonstratePolymorphismThroughInheritance();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Basic Inheritance
        private static void DemonstrateBasicInheritance()
        {
            Console.WriteLine("=== Basic Inheritance ===");
            
            // Creating base class object
            Animal animal = new Animal("Generic Animal", 5);
            animal.DisplayInfo();
            animal.MakeSound(); // Virtual method
            animal.Eat();
            
            Console.WriteLine();
            
            // Creating derived class objects
            Dog dog = new Dog("Buddy", 3, "Golden Retriever");
            dog.DisplayInfo(); // Inherited method
            dog.MakeSound();   // Overridden method
            dog.Eat();         // Inherited method
            dog.Bark();        // Dog-specific method
            
            Console.WriteLine();
            
            Cat cat = new Cat("Whiskers", 2, "Siamese");
            cat.DisplayInfo();
            cat.MakeSound();
            cat.Climb();       // Cat-specific method
            
            Console.WriteLine();
        }
        #endregion
        
        #region Method Overriding
        private static void DemonstrateMethodOverriding()
        {
            Console.WriteLine("=== Method Overriding ===");
            
            // Demonstrating virtual and override keywords
            Shape[] shapes = {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 4)
            };
            
            foreach (Shape shape in shapes)
            {
                shape.DisplayInfo();      // Virtual method
                Console.WriteLine($"Area: {shape.CalculateArea():F2}"); // Virtual method
                Console.WriteLine($"Perimeter: {shape.CalculatePerimeter():F2}"); // Abstract method
                Console.WriteLine();
            }
        }
        #endregion
        
        #region Base Keyword
        private static void DemonstrateBaseKeyword()
        {
            Console.WriteLine("=== Base Keyword ===");
            
            Employee employee = new Employee("John Doe", 101, "Software Engineer", 75000);
            employee.DisplayInfo();
            
            Manager manager = new Manager("Jane Smith", 102, "Engineering Manager", 95000, "Development");
            manager.DisplayInfo(); // Calls overridden method that uses base
            
            Console.WriteLine();
        }
        #endregion
        
        #region Multilevel Inheritance
        private static void DemonstrateMultilevelInheritance()
        {
            Console.WriteLine("=== Multilevel Inheritance ===");
            
            // Vehicle -> Car -> SportsCar inheritance chain
            SportsCar sportsCar = new SportsCar("Ferrari", "F8 Tributo", 2023, 4, 710);
            sportsCar.DisplayInfo();    // From Vehicle
            sportsCar.Start();          // From Vehicle (overridden in Car)
            sportsCar.Accelerate();     // From Car
            sportsCar.TurboBoost();     // From SportsCar
            
            Console.WriteLine();
        }
        #endregion
        
        #region Polymorphism Through Inheritance
        private static void DemonstratePolymorphismThroughInheritance()
        {
            Console.WriteLine("=== Polymorphism Through Inheritance ===");
            
            // Array of base class references pointing to derived class objects
            Animal[] animals = {
                new Dog("Rex", 4, "German Shepherd"),
                new Cat("Luna", 2, "Persian"),
                new Animal("Wild Animal", 6)
            };
            
            Console.WriteLine("Polymorphic method calls:");
            foreach (Animal animal in animals)
            {
                Console.Write($"{animal.Name}: ");
                animal.MakeSound(); // Calls appropriate overridden method
            }
            
            Console.WriteLine();
        }
        #endregion
    }
    
    #region Animal Inheritance Hierarchy
    
    // Base class
    public class Animal
    {
        public string Name { get; protected set; }
        public int Age { get; protected set; }
        
        public Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        // Virtual method - can be overridden
        public virtual void MakeSound()
        {
            Console.WriteLine("The animal makes a generic sound");
        }
        
        // Regular method - inherited as-is
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating");
        }
        
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Animal: {Name}, Age: {Age}");
        }
    }
    
    // Derived class
    public class Dog : Animal
    {
        public string Breed { get; private set; }
        
        public Dog(string name, int age, string breed) : base(name, age)
        {
            Breed = breed;
        }
        
        // Override the virtual method
        public override void MakeSound()
        {
            Console.WriteLine("Woof! Woof!");
        }
        
        // Override virtual method with additional functionality
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Call base class method
            Console.WriteLine($"Breed: {Breed}");
        }
        
        // Dog-specific method
        public void Bark()
        {
            Console.WriteLine($"{Name} is barking loudly!");
        }
    }
    
    public class Cat : Animal
    {
        public string Breed { get; private set; }
        
        public Cat(string name, int age, string breed) : base(name, age)
        {
            Breed = breed;
        }
        
        public override void MakeSound()
        {
            Console.WriteLine("Meow! Meow!");
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Breed: {Breed}");
        }
        
        // Cat-specific method
        public void Climb()
        {
            Console.WriteLine($"{Name} is climbing a tree");
        }
    }
    
    #endregion
    
    #region Shape Inheritance Hierarchy
    
    // Abstract base class
    public abstract class Shape
    {
        public string Name { get; protected set; }
        
        public Shape(string name)
        {
            Name = name;
        }
        
        // Virtual method - can be overridden
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Shape: {Name}");
        }
        
        // Abstract methods - must be implemented by derived classes
        public abstract double CalculateArea();
        public abstract double CalculatePerimeter();
    }
    
    public class Circle : Shape
    {
        public double Radius { get; private set; }
        
        public Circle(double radius) : base("Circle")
        {
            Radius = radius;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Radius: {Radius}");
        }
        
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
        
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
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
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Width: {Width}, Height: {Height}");
        }
        
        public override double CalculateArea()
        {
            return Width * Height;
        }
        
        public override double CalculatePerimeter()
        {
            return 2 * (Width + Height);
        }
    }
    
    public class Triangle : Shape
    {
        public double Base { get; private set; }
        public double Height { get; private set; }
        
        public Triangle(double baseLength, double height) : base("Triangle")
        {
            Base = baseLength;
            Height = height;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Base: {Base}, Height: {Height}");
        }
        
        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
        
        public override double CalculatePerimeter()
        {
            // Simplified calculation assuming equilateral triangle
            return 3 * Base;
        }
    }
    
    #endregion
    
    #region Employee Inheritance Hierarchy
    
    public class Employee
    {
        public string Name { get; protected set; }
        public int Id { get; protected set; }
        public string Position { get; protected set; }
        public decimal Salary { get; protected set; }
        
        public Employee(string name, int id, string position, decimal salary)
        {
            Name = name;
            Id = id;
            Position = position;
            Salary = salary;
        }
        
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Employee: {Name} (ID: {Id})");
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"Salary: ${Salary:N2}");
        }
        
        public virtual decimal CalculateBonus()
        {
            return Salary * 0.05m; // 5% of salary
        }
    }
    
    public class Manager : Employee
    {
        public string Department { get; private set; }
        
        public Manager(string name, int id, string position, decimal salary, string department)
            : base(name, id, position, salary)
        {
            Department = department;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo(); // Call base class method
            Console.WriteLine($"Department: {Department}");
            Console.WriteLine($"Bonus: ${CalculateBonus():N2}");
        }
        
        public override decimal CalculateBonus()
        {
            return Salary * 0.15m; // 15% of salary for managers
        }
    }
    
    #endregion
    
    #region Vehicle Inheritance Hierarchy (Multilevel)
    
    // Base class
    public class Vehicle
    {
        public string Make { get; protected set; }
        public string Model { get; protected set; }
        public int Year { get; protected set; }
        
        public Vehicle(string make, string model, int year)
        {
            Make = make;
            Model = model;
            Year = year;
        }
        
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: {Year} {Make} {Model}");
        }
        
        public virtual void Start()
        {
            Console.WriteLine("Vehicle is starting...");
        }
    }
    
    // First level inheritance
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; protected set; }
        
        public Car(string make, string model, int year, int doors)
            : base(make, model, year)
        {
            NumberOfDoors = doors;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Doors: {NumberOfDoors}");
        }
        
        public override void Start()
        {
            Console.WriteLine("Car engine is starting...");
        }
        
        public virtual void Accelerate()
        {
            Console.WriteLine("Car is accelerating...");
        }
    }
    
    // Second level inheritance
    public class SportsCar : Car
    {
        public int Horsepower { get; private set; }
        
        public SportsCar(string make, string model, int year, int doors, int horsepower)
            : base(make, model, year, doors)
        {
            Horsepower = horsepower;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Horsepower: {Horsepower}");
        }
        
        public override void Accelerate()
        {
            Console.WriteLine("Sports car is accelerating rapidly!");
        }
        
        public void TurboBoost()
        {
            Console.WriteLine("Turbo boost activated!");
        }
    }
    
    #endregion
}