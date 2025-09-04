using System;

/// <summary>
/// Abstraction in C#
/// Demonstrates abstract classes, abstract methods, and abstraction principles
/// </summary>
namespace CSharpOOPs
{
    public class Abstraction
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Abstraction in C# ===\n");
            
            DemonstrateAbstractClasses();
            DemonstrateAbstractMethods();
            DemonstrateTemplateMethodPattern();
            DemonstrateAbstractionLevels();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Abstract Classes
        private static void DemonstrateAbstractClasses()
        {
            Console.WriteLine("=== Abstract Classes ===");
            
            // Cannot instantiate abstract class
            // Vehicle vehicle = new Vehicle(); // Compilation error
            
            // Create instances of concrete derived classes
            Car car = new Car("Toyota", "Camry", 4);
            Motorcycle motorcycle = new Motorcycle("Honda", "CBR", 600);
            Truck truck = new Truck("Ford", "F-150", 1000);
            
            Vehicle[] vehicles = { car, motorcycle, truck };
            
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.DisplayInfo();      // Concrete method
                vehicle.StartEngine();      // Abstract method implementation
                vehicle.StopEngine();       // Abstract method implementation
                Console.WriteLine($"Max Speed: {vehicle.GetMaxSpeed()} mph");
                Console.WriteLine();
            }
        }
        #endregion
        
        #region Abstract Methods
        private static void DemonstrateAbstractMethods()
        {
            Console.WriteLine("=== Abstract Methods ===");
            
            DatabaseConnection[] connections = {
                new SqlServerConnection("Server=localhost;Database=Test"),
                new MySqlConnection("Server=localhost;Database=Test;Uid=root"),
                new OracleConnection("Data Source=localhost:1521/XE")
            };
            
            foreach (DatabaseConnection connection in connections)
            {
                connection.Connect();
                connection.ExecuteQuery("SELECT * FROM Users");
                connection.Disconnect();
                Console.WriteLine();
            }
        }
        #endregion
        
        #region Template Method Pattern
        private static void DemonstrateTemplateMethodPattern()
        {
            Console.WriteLine("=== Template Method Pattern ===");
            
            DataProcessor[] processors = {
                new CsvDataProcessor(),
                new JsonDataProcessor(),
                new XmlDataProcessor()
            };
            
            foreach (DataProcessor processor in processors)
            {
                processor.ProcessData(); // Template method
                Console.WriteLine();
            }
        }
        #endregion
        
        #region Abstraction Levels
        private static void DemonstrateAbstractionLevels()
        {
            Console.WriteLine("=== Abstraction Levels ===");
            
            // High-level abstraction
            PaymentGateway[] gateways = {
                new StripePaymentGateway(),
                new PayPalPaymentGateway(),
                new SquarePaymentGateway()
            };
            
            foreach (PaymentGateway gateway in gateways)
            {
                Console.WriteLine($"Processing payment through {gateway.GetType().Name}:");
                bool success = gateway.ProcessPayment(100.00m, "4111111111111111");
                Console.WriteLine($"Payment result: {(success ? "Success" : "Failed")}");
                Console.WriteLine();
            }
        }
        #endregion
    }
    
    #region Vehicle Abstract Class
    /// <summary>
    /// Abstract base class representing a vehicle
    /// </summary>
    public abstract class Vehicle
    {
        // Properties (can be concrete in abstract class)
        public string Make { get; protected set; }
        public string Model { get; protected set; }
        protected bool isEngineRunning;
        
        // Constructor
        public Vehicle(string make, string model)
        {
            Make = make;
            Model = model;
            isEngineRunning = false;
        }
        
        // Concrete method (implemented in abstract class)
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Vehicle: {Make} {Model}");
            Console.WriteLine($"Engine Status: {(isEngineRunning ? "Running" : "Stopped")}");
        }
        
        // Abstract methods (must be implemented by derived classes)
        public abstract void StartEngine();
        public abstract void StopEngine();
        public abstract int GetMaxSpeed();
        
        // Virtual method (can be overridden)
        public virtual void Honk()
        {
            Console.WriteLine("Beep beep!");
        }
    }
    
    public class Car : Vehicle
    {
        public int NumberOfDoors { get; private set; }
        
        public Car(string make, string model, int doors) : base(make, model)
        {
            NumberOfDoors = doors;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Type: Car, Doors: {NumberOfDoors}");
        }
        
        public override void StartEngine()
        {
            isEngineRunning = true;
            Console.WriteLine("Car engine started with a quiet hum");
        }
        
        public override void StopEngine()
        {
            isEngineRunning = false;
            Console.WriteLine("Car engine stopped");
        }
        
        public override int GetMaxSpeed()
        {
            return 120; // mph
        }
    }
    
    public class Motorcycle : Vehicle
    {
        public int EngineSize { get; private set; }
        
        public Motorcycle(string make, string model, int engineSize) : base(make, model)
        {
            EngineSize = engineSize;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Type: Motorcycle, Engine: {EngineSize}cc");
        }
        
        public override void StartEngine()
        {
            isEngineRunning = true;
            Console.WriteLine("Motorcycle engine started with a loud roar");
        }
        
        public override void StopEngine()
        {
            isEngineRunning = false;
            Console.WriteLine("Motorcycle engine stopped");
        }
        
        public override int GetMaxSpeed()
        {
            return 180; // mph
        }
        
        public override void Honk()
        {
            Console.WriteLine("Beep!");
        }
    }
    
    public class Truck : Vehicle
    {
        public int CargoCapacity { get; private set; }
        
        public Truck(string make, string model, int capacity) : base(make, model)
        {
            CargoCapacity = capacity;
        }
        
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Type: Truck, Cargo Capacity: {CargoCapacity} lbs");
        }
        
        public override void StartEngine()
        {
            isEngineRunning = true;
            Console.WriteLine("Truck engine started with a deep rumble");
        }
        
        public override void StopEngine()
        {
            isEngineRunning = false;
            Console.WriteLine("Truck engine stopped");
        }
        
        public override int GetMaxSpeed()
        {
            return 80; // mph
        }
        
        public override void Honk()
        {
            Console.WriteLine("HOOOONK!");
        }
    }
    #endregion
    
    #region Database Connection Abstract Class
    public abstract class DatabaseConnection
    {
        protected string connectionString;
        protected bool isConnected;
        
        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
            this.isConnected = false;
        }
        
        // Abstract methods - must be implemented
        public abstract void Connect();
        public abstract void Disconnect();
        public abstract void ExecuteQuery(string query);
        
        // Concrete method
        public bool IsConnected()
        {
            return isConnected;
        }
        
        // Virtual method
        public virtual void LogActivity(string activity)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {activity}");
        }
    }
    
    public class SqlServerConnection : DatabaseConnection
    {
        public SqlServerConnection(string connectionString) : base(connectionString)
        {
        }
        
        public override void Connect()
        {
            isConnected = true;
            LogActivity("Connected to SQL Server database");
        }
        
        public override void Disconnect()
        {
            isConnected = false;
            LogActivity("Disconnected from SQL Server database");
        }
        
        public override void ExecuteQuery(string query)
        {
            if (isConnected)
            {
                LogActivity($"Executing SQL Server query: {query}");
                Console.WriteLine("Query executed on SQL Server");
            }
            else
            {
                Console.WriteLine("Cannot execute query - not connected");
            }
        }
    }
    
    public class MySqlConnection : DatabaseConnection
    {
        public MySqlConnection(string connectionString) : base(connectionString)
        {
        }
        
        public override void Connect()
        {
            isConnected = true;
            LogActivity("Connected to MySQL database");
        }
        
        public override void Disconnect()
        {
            isConnected = false;
            LogActivity("Disconnected from MySQL database");
        }
        
        public override void ExecuteQuery(string query)
        {
            if (isConnected)
            {
                LogActivity($"Executing MySQL query: {query}");
                Console.WriteLine("Query executed on MySQL");
            }
            else
            {
                Console.WriteLine("Cannot execute query - not connected");
            }
        }
    }
    
    public class OracleConnection : DatabaseConnection
    {
        public OracleConnection(string connectionString) : base(connectionString)
        {
        }
        
        public override void Connect()
        {
            isConnected = true;
            LogActivity("Connected to Oracle database");
        }
        
        public override void Disconnect()
        {
            isConnected = false;
            LogActivity("Disconnected from Oracle database");
        }
        
        public override void ExecuteQuery(string query)
        {
            if (isConnected)
            {
                LogActivity($"Executing Oracle query: {query}");
                Console.WriteLine("Query executed on Oracle");
            }
            else
            {
                Console.WriteLine("Cannot execute query - not connected");
            }
        }
    }
    #endregion
    
    #region Template Method Pattern
    /// <summary>
    /// Template Method Pattern using abstract class
    /// </summary>
    public abstract class DataProcessor
    {
        // Template method - defines the algorithm structure
        public void ProcessData()
        {
            LoadData();
            ValidateData();
            TransformData();
            SaveData();
            CleanUp();
        }
        
        // Abstract methods - steps that vary
        protected abstract void LoadData();
        protected abstract void TransformData();
        protected abstract void SaveData();
        
        // Concrete methods - common implementation
        protected virtual void ValidateData()
        {
            Console.WriteLine("Validating data...");
        }
        
        protected virtual void CleanUp()
        {
            Console.WriteLine("Cleaning up resources...");
        }
    }
    
    public class CsvDataProcessor : DataProcessor
    {
        protected override void LoadData()
        {
            Console.WriteLine("Loading data from CSV file...");
        }
        
        protected override void TransformData()
        {
            Console.WriteLine("Transforming CSV data to objects...");
        }
        
        protected override void SaveData()
        {
            Console.WriteLine("Saving processed CSV data to database...");
        }
    }
    
    public class JsonDataProcessor : DataProcessor
    {
        protected override void LoadData()
        {
            Console.WriteLine("Loading data from JSON file...");
        }
        
        protected override void TransformData()
        {
            Console.WriteLine("Parsing JSON and transforming to objects...");
        }
        
        protected override void SaveData()
        {
            Console.WriteLine("Saving processed JSON data to database...");
        }
        
        protected override void ValidateData()
        {
            Console.WriteLine("Validating JSON schema...");
            base.ValidateData();
        }
    }
    
    public class XmlDataProcessor : DataProcessor
    {
        protected override void LoadData()
        {
            Console.WriteLine("Loading data from XML file...");
        }
        
        protected override void TransformData()
        {
            Console.WriteLine("Parsing XML and transforming to objects...");
        }
        
        protected override void SaveData()
        {
            Console.WriteLine("Saving processed XML data to database...");
        }
        
        protected override void ValidateData()
        {
            Console.WriteLine("Validating XML against XSD...");
            base.ValidateData();
        }
    }
    #endregion
    
    #region Payment Gateway Abstraction
    /// <summary>
    /// High-level abstraction for payment processing
    /// </summary>
    public abstract class PaymentGateway
    {
        // Template method
        public bool ProcessPayment(decimal amount, string cardNumber)
        {
            if (ValidateInput(amount, cardNumber))
            {
                string token = GenerateSecurityToken();
                bool result = ExecutePayment(amount, token);
                LogTransaction(amount, result);
                return result;
            }
            return false;
        }
        
        // Concrete methods (common implementation)
        protected virtual bool ValidateInput(decimal amount, string cardNumber)
        {
            return amount > 0 && !string.IsNullOrEmpty(cardNumber);
        }
        
        protected virtual string GenerateSecurityToken()
        {
            return Guid.NewGuid().ToString("N")[..8];
        }
        
        protected virtual void LogTransaction(decimal amount, bool success)
        {
            Console.WriteLine($"Transaction logged: ${amount:F2} - {(success ? "Success" : "Failed")}");
        }
        
        // Abstract method - specific implementation required
        protected abstract bool ExecutePayment(decimal amount, string securityToken);
    }
    
    public class StripePaymentGateway : PaymentGateway
    {
        protected override bool ExecutePayment(decimal amount, string securityToken)
        {
            Console.WriteLine($"Processing payment through Stripe API...");
            Console.WriteLine($"Amount: ${amount:F2}, Token: {securityToken}");
            // Simulate payment processing
            return amount <= 1000; // Simulate success for amounts <= $1000
        }
    }
    
    public class PayPalPaymentGateway : PaymentGateway
    {
        protected override bool ExecutePayment(decimal amount, string securityToken)
        {
            Console.WriteLine($"Processing payment through PayPal API...");
            Console.WriteLine($"Amount: ${amount:F2}, Token: {securityToken}");
            // Simulate payment processing
            return amount <= 500; // Simulate success for amounts <= $500
        }
        
        protected override void LogTransaction(decimal amount, bool success)
        {
            Console.WriteLine($"PayPal transaction logged to PayPal dashboard");
            base.LogTransaction(amount, success);
        }
    }
    
    public class SquarePaymentGateway : PaymentGateway
    {
        protected override bool ExecutePayment(decimal amount, string securityToken)
        {
            Console.WriteLine($"Processing payment through Square API...");
            Console.WriteLine($"Amount: ${amount:F2}, Token: {securityToken}");
            // Simulate payment processing
            return true; // Simulate always successful
        }
    }
    #endregion
}