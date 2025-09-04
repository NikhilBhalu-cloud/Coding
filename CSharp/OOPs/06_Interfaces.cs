using System;
using System.Collections.Generic;

/// <summary>
/// Interfaces in C#
/// Demonstrates interface declaration, implementation, multiple inheritance, and interface segregation
/// </summary>
namespace CSharpOOPs
{
    public class Interfaces
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Interfaces in C# ===\n");
            
            DemonstrateBasicInterfaces();
            DemonstrateMultipleInterfaceInheritance();
            DemonstrateInterfacePolymorphism();
            DemonstrateInterfaceSegregation();
            DemonstrateExplicitInterfaceImplementation();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Basic Interfaces
        private static void DemonstrateBasicInterfaces()
        {
            Console.WriteLine("=== Basic Interfaces ===");
            
            // Creating objects that implement interfaces
            Dog dog = new Dog("Buddy");
            Bird bird = new Bird("Tweety");
            Fish fish = new Fish("Nemo");
            
            // Using interface references
            IAnimal[] animals = { dog, bird, fish };
            
            foreach (IAnimal animal in animals)
            {
                animal.Eat();
                animal.Sleep();
                Console.WriteLine();
            }
            
            // Interface-specific behavior
            IMovable[] movableAnimals = { dog, bird, fish };
            
            Console.WriteLine("Movement behaviors:");
            foreach (IMovable movable in movableAnimals)
            {
                movable.Move();
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region Multiple Interface Inheritance
        private static void DemonstrateMultipleInterfaceInheritance()
        {
            Console.WriteLine("=== Multiple Interface Inheritance ===");
            
            SmartPhone phone = new SmartPhone("iPhone 14");
            
            // Can be treated as any of its interfaces
            IPhone asPhone = phone;
            ICamera asCamera = phone;
            IMediaPlayer asMediaPlayer = phone;
            
            asPhone.MakeCall("123-456-7890");
            asPhone.SendMessage("Hello World!");
            
            asCamera.TakePhoto();
            asCamera.RecordVideo();
            
            asMediaPlayer.PlayMusic("song.mp3");
            asMediaPlayer.PlayVideo("movie.mp4");
            
            // Multiple interface implementation in action
            MultimediaDevice device = new MultimediaDevice();
            device.TakePhoto();
            device.PlayMusic("background.mp3");
            
            Console.WriteLine();
        }
        #endregion
        
        #region Interface Polymorphism
        private static void DemonstrateInterfacePolymorphism()
        {
            Console.WriteLine("=== Interface Polymorphism ===");
            
            // Different shapes implementing the same interface
            IDrawable[] drawables = {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 4, 5),
                new Line(0, 0, 10, 10)
            };
            
            Console.WriteLine("Drawing all shapes:");
            foreach (IDrawable drawable in drawables)
            {
                drawable.Draw();
            }
            
            // Different payment methods
            IPayment[] paymentMethods = {
                new CreditCardPayment("1234-5678-9012-3456"),
                new PayPalPayment("user@example.com"),
                new BankTransferPayment("987654321")
            };
            
            Console.WriteLine("\nProcessing payments:");
            foreach (IPayment payment in paymentMethods)
            {
                payment.ProcessPayment(100.00m);
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region Interface Segregation
        private static void DemonstrateInterfaceSegregation()
        {
            Console.WriteLine("=== Interface Segregation Principle ===");
            
            // Good: Small, focused interfaces
            Printer printer = new Printer();
            Scanner scanner = new Scanner();
            AllInOneDevice allInOne = new AllInOneDevice();
            
            // Each class implements only what it needs
            IPrintable[] printableDevices = { printer, allInOne };
            IScannable[] scannableDevices = { scanner, allInOne };
            
            Console.WriteLine("Printing documents:");
            foreach (IPrintable device in printableDevices)
            {
                device.Print("document.pdf");
            }
            
            Console.WriteLine("\nScanning documents:");
            foreach (IScannable device in scannableDevices)
            {
                device.Scan();
            }
            
            Console.WriteLine();
        }
        #endregion
        
        #region Explicit Interface Implementation
        private static void DemonstrateExplicitInterfaceImplementation()
        {
            Console.WriteLine("=== Explicit Interface Implementation ===");
            
            MultiRoleEmployee employee = new MultiRoleEmployee("John Doe");
            
            // Explicit interface implementation requires casting
            IEmployee asEmployee = employee;
            IManager asManager = employee;
            IDeveloper asDeveloper = employee;
            
            asEmployee.Work();
            asManager.ManageTeam();
            asDeveloper.WriteCode();
            
            // Different behaviors for same method name
            IVehicle car = new Car();
            IAircraft plane = new AirVehicle();
            
            car.Start();  // Car's start implementation
            plane.Start(); // Aircraft's start implementation
            
            Console.WriteLine();
        }
        #endregion
    }
    
    #region Basic Interfaces
    // Basic interface definition
    public interface IAnimal
    {
        string Name { get; }
        void Eat();
        void Sleep();
    }
    
    public interface IMovable
    {
        void Move();
    }
    
    // Class implementing multiple interfaces
    public class Dog : IAnimal, IMovable
    {
        public string Name { get; private set; }
        
        public Dog(string name)
        {
            Name = name;
        }
        
        public void Eat()
        {
            Console.WriteLine($"{Name} the dog is eating dog food");
        }
        
        public void Sleep()
        {
            Console.WriteLine($"{Name} the dog is sleeping in its bed");
        }
        
        public void Move()
        {
            Console.WriteLine($"{Name} the dog is running");
        }
        
        // Dog-specific method
        public void Bark()
        {
            Console.WriteLine($"{Name} is barking: Woof!");
        }
    }
    
    public class Bird : IAnimal, IMovable
    {
        public string Name { get; private set; }
        
        public Bird(string name)
        {
            Name = name;
        }
        
        public void Eat()
        {
            Console.WriteLine($"{Name} the bird is eating seeds");
        }
        
        public void Sleep()
        {
            Console.WriteLine($"{Name} the bird is sleeping in its nest");
        }
        
        public void Move()
        {
            Console.WriteLine($"{Name} the bird is flying");
        }
    }
    
    public class Fish : IAnimal, IMovable
    {
        public string Name { get; private set; }
        
        public Fish(string name)
        {
            Name = name;
        }
        
        public void Eat()
        {
            Console.WriteLine($"{Name} the fish is eating plankton");
        }
        
        public void Sleep()
        {
            Console.WriteLine($"{Name} the fish is resting");
        }
        
        public void Move()
        {
            Console.WriteLine($"{Name} the fish is swimming");
        }
    }
    #endregion
    
    #region Multiple Interface Inheritance
    public interface IPhone
    {
        void MakeCall(string number);
        void SendMessage(string message);
    }
    
    public interface ICamera
    {
        void TakePhoto();
        void RecordVideo();
    }
    
    public interface IMediaPlayer
    {
        void PlayMusic(string fileName);
        void PlayVideo(string fileName);
    }
    
    // Class implementing multiple interfaces
    public class SmartPhone : IPhone, ICamera, IMediaPlayer
    {
        public string Model { get; private set; }
        
        public SmartPhone(string model)
        {
            Model = model;
        }
        
        // IPhone implementation
        public void MakeCall(string number)
        {
            Console.WriteLine($"{Model}: Calling {number}...");
        }
        
        public void SendMessage(string message)
        {
            Console.WriteLine($"{Model}: Sending message: {message}");
        }
        
        // ICamera implementation
        public void TakePhoto()
        {
            Console.WriteLine($"{Model}: Taking a high-quality photo");
        }
        
        public void RecordVideo()
        {
            Console.WriteLine($"{Model}: Recording 4K video");
        }
        
        // IMediaPlayer implementation
        public void PlayMusic(string fileName)
        {
            Console.WriteLine($"{Model}: Playing music: {fileName}");
        }
        
        public void PlayVideo(string fileName)
        {
            Console.WriteLine($"{Model}: Playing video: {fileName}");
        }
    }
    
    public class MultimediaDevice : ICamera, IMediaPlayer
    {
        public void TakePhoto()
        {
            Console.WriteLine("Multimedia device: Taking photo");
        }
        
        public void RecordVideo()
        {
            Console.WriteLine("Multimedia device: Recording video");
        }
        
        public void PlayMusic(string fileName)
        {
            Console.WriteLine($"Multimedia device: Playing music: {fileName}");
        }
        
        public void PlayVideo(string fileName)
        {
            Console.WriteLine($"Multimedia device: Playing video: {fileName}");
        }
    }
    #endregion
    
    #region Interface Polymorphism
    public interface IDrawable
    {
        void Draw();
    }
    
    public class Circle : IDrawable
    {
        public double Radius { get; private set; }
        
        public Circle(double radius)
        {
            Radius = radius;
        }
        
        public void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }
    
    public class Rectangle : IDrawable
    {
        public double Width { get; private set; }
        public double Height { get; private set; }
        
        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }
        
        public void Draw()
        {
            Console.WriteLine($"Drawing a rectangle {Width} x {Height}");
        }
    }
    
    public class Triangle : IDrawable
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }
        
        public Triangle(double a, double b, double c)
        {
            SideA = a;
            SideB = b;
            SideC = c;
        }
        
        public void Draw()
        {
            Console.WriteLine($"Drawing a triangle with sides {SideA}, {SideB}, {SideC}");
        }
    }
    
    public class Line : IDrawable
    {
        public double X1 { get; private set; }
        public double Y1 { get; private set; }
        public double X2 { get; private set; }
        public double Y2 { get; private set; }
        
        public Line(double x1, double y1, double x2, double y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
        
        public void Draw()
        {
            Console.WriteLine($"Drawing a line from ({X1}, {Y1}) to ({X2}, {Y2})");
        }
    }
    
    // Payment interfaces
    public interface IPayment
    {
        void ProcessPayment(decimal amount);
    }
    
    public class CreditCardPayment : IPayment
    {
        public string CardNumber { get; private set; }
        
        public CreditCardPayment(string cardNumber)
        {
            CardNumber = cardNumber;
        }
        
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment: ${amount:F2}");
            Console.WriteLine($"Card: ****-****-****-{CardNumber.Substring(CardNumber.Length - 4)}");
        }
    }
    
    public class PayPalPayment : IPayment
    {
        public string Email { get; private set; }
        
        public PayPalPayment(string email)
        {
            Email = email;
        }
        
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment: ${amount:F2}");
            Console.WriteLine($"PayPal account: {Email}");
        }
    }
    
    public class BankTransferPayment : IPayment
    {
        public string AccountNumber { get; private set; }
        
        public BankTransferPayment(string accountNumber)
        {
            AccountNumber = accountNumber;
        }
        
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing bank transfer: ${amount:F2}");
            Console.WriteLine($"Account: ****{AccountNumber.Substring(AccountNumber.Length - 4)}");
        }
    }
    #endregion
    
    #region Interface Segregation
    // Good: Small, focused interfaces
    public interface IPrintable
    {
        void Print(string document);
    }
    
    public interface IScannable
    {
        void Scan();
    }
    
    public interface IFaxable
    {
        void SendFax(string document, string number);
    }
    
    // Classes implement only what they need
    public class Printer : IPrintable
    {
        public void Print(string document)
        {
            Console.WriteLine($"Printing document: {document}");
        }
    }
    
    public class Scanner : IScannable
    {
        public void Scan()
        {
            Console.WriteLine("Scanning document...");
        }
    }
    
    // All-in-one device implements multiple interfaces
    public class AllInOneDevice : IPrintable, IScannable, IFaxable
    {
        public void Print(string document)
        {
            Console.WriteLine($"All-in-one device printing: {document}");
        }
        
        public void Scan()
        {
            Console.WriteLine("All-in-one device scanning...");
        }
        
        public void SendFax(string document, string number)
        {
            Console.WriteLine($"All-in-one device faxing {document} to {number}");
        }
    }
    #endregion
    
    #region Explicit Interface Implementation
    public interface IEmployee
    {
        void Work();
    }
    
    public interface IManager
    {
        void ManageTeam();
    }
    
    public interface IDeveloper
    {
        void WriteCode();
    }
    
    public class MultiRoleEmployee : IEmployee, IManager, IDeveloper
    {
        public string Name { get; private set; }
        
        public MultiRoleEmployee(string name)
        {
            Name = name;
        }
        
        // Explicit interface implementations
        void IEmployee.Work()
        {
            Console.WriteLine($"{Name} is working as an employee");
        }
        
        void IManager.ManageTeam()
        {
            Console.WriteLine($"{Name} is managing the team");
        }
        
        void IDeveloper.WriteCode()
        {
            Console.WriteLine($"{Name} is writing code");
        }
    }
    
    // Interfaces with conflicting method names
    public interface IVehicle
    {
        void Start();
    }
    
    public interface IAircraft
    {
        void Start();
    }
    
    public class Car : IVehicle
    {
        public void Start()
        {
            Console.WriteLine("Car engine started");
        }
    }
    
    public class AirVehicle : IVehicle, IAircraft
    {
        // Explicit implementation to resolve conflict
        void IVehicle.Start()
        {
            Console.WriteLine("Vehicle engine started");
        }
        
        void IAircraft.Start()
        {
            Console.WriteLine("Aircraft engines started for takeoff");
        }
    }
    #endregion
}