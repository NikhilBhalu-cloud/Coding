using System;

/// <summary>
/// Comments & Regions in C#
/// Demonstrates different types of comments and code organization with regions
/// </summary>
namespace CSharpBasics
{
    public class CommentsAndRegions
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("=== Comments & Regions in C# ===\n");
            
            DemonstrateCommentTypes();
            DemonstrateDocumentationComments();
            DemonstrateRegions();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        #region Comment Demonstrations
        
        /// <summary>
        /// Demonstrates different types of comments in C#
        /// </summary>
        private static void DemonstrateCommentTypes()
        {
            Console.WriteLine("=== Comment Types ===");
            
            // Single-line comment
            // This is a single-line comment
            Console.WriteLine("Single-line comments start with //");
            
            /* Multi-line comment
               This is a multi-line comment
               that spans multiple lines
               and is enclosed in /* and */
            Console.WriteLine("Multi-line comments are enclosed in /* */");
            
            /*
             * Formatted multi-line comment
             * Each line typically starts with *
             * for better readability
             */
            Console.WriteLine("Formatted multi-line comments use asterisks for alignment");
            
            /// XML documentation comment
            /// This is an XML documentation comment
            /// Used for generating documentation
            Console.WriteLine("XML documentation comments start with ///");
            
            // TODO: Demonstrate special comments
            // NOTE: This is an informational note
            // HACK: This is a temporary workaround
            // FIXME: This needs to be fixed
            // BUG: Known issue that needs resolution
            // UNDONE: Feature that was started but not completed
            
            Console.WriteLine("Special comment tags: TODO, NOTE, HACK, FIXME, BUG, UNDONE");
            
            Console.WriteLine();
        }
        
        #endregion
        
        #region Documentation Comments
        
        /// <summary>
        /// Demonstrates XML documentation comments and their tags
        /// </summary>
        /// <remarks>
        /// This method shows various XML documentation tags that can be used
        /// to generate comprehensive API documentation.
        /// </remarks>
        /// <example>
        /// Here's how to call this method:
        /// <code>
        /// DemonstrateDocumentationComments();
        /// </code>
        /// </example>
        /// <seealso cref="DemonstrateCommentTypes"/>
        private static void DemonstrateDocumentationComments()
        {
            Console.WriteLine("=== XML Documentation Comments ===");
            Console.WriteLine("Check the source code to see various XML documentation tags:");
            Console.WriteLine("- <summary>: Brief description");
            Console.WriteLine("- <param>: Parameter description");
            Console.WriteLine("- <returns>: Return value description");
            Console.WriteLine("- <remarks>: Additional information");
            Console.WriteLine("- <example>: Usage example");
            Console.WriteLine("- <exception>: Exception documentation");
            Console.WriteLine("- <seealso>: Cross-references");
            Console.WriteLine("- <code>: Code samples");
            Console.WriteLine("- <c>: Inline code");
            Console.WriteLine();
        }
        
        /// <summary>
        /// Calculates the area of a rectangle
        /// </summary>
        /// <param name="width">The width of the rectangle (must be positive)</param>
        /// <param name="height">The height of the rectangle (must be positive)</param>
        /// <returns>The area of the rectangle as a <see cref="double"/></returns>
        /// <exception cref="ArgumentException">
        /// Thrown when width or height is negative or zero
        /// </exception>
        /// <example>
        /// <code>
        /// double area = CalculateRectangleArea(5.0, 3.0);
        /// Console.WriteLine($"Area: {area}"); // Output: Area: 15
        /// </code>
        /// </example>
        public static double CalculateRectangleArea(double width, double height)
        {
            if (width <= 0)
                throw new ArgumentException("Width must be positive", nameof(width));
            if (height <= 0)
                throw new ArgumentException("Height must be positive", nameof(height));
            
            return width * height;
        }
        
        /// <summary>
        /// Gets or sets the person's name
        /// </summary>
        /// <value>The full name of the person</value>
        public string Name { get; set; }
        
        /// <summary>
        /// Represents a person with basic information
        /// </summary>
        /// <remarks>
        /// This class demonstrates XML documentation for classes
        /// </remarks>
        public class DocumentedPerson
        {
            /// <summary>
            /// The person's first name
            /// </summary>
            public string FirstName { get; set; }
            
            /// <summary>
            /// The person's last name
            /// </summary>
            public string LastName { get; set; }
            
            /// <summary>
            /// Initializes a new instance of the <see cref="DocumentedPerson"/> class
            /// </summary>
            /// <param name="firstName">The first name</param>
            /// <param name="lastName">The last name</param>
            public DocumentedPerson(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }
            
            /// <summary>
            /// Gets the full name of the person
            /// </summary>
            /// <returns>A string containing the first and last name</returns>
            public string GetFullName()
            {
                return $"{FirstName} {LastName}";
            }
        }
        
        #endregion
        
        #region Regions Demonstration
        
        /// <summary>
        /// Demonstrates the use of regions for code organization
        /// </summary>
        private static void DemonstrateRegions()
        {
            Console.WriteLine("=== Regions ===");
            Console.WriteLine("Regions help organize code into collapsible sections:");
            Console.WriteLine("- Use #region [name] to start a region");
            Console.WriteLine("- Use #endregion to end a region");
            Console.WriteLine("- Regions can be nested");
            Console.WriteLine("- They don't affect compilation");
            Console.WriteLine("- Great for organizing large classes");
            
            #region Mathematical Operations
            
            int a = 10, b = 5;
            
            #region Basic Operations
            int sum = a + b;
            int difference = a - b;
            Console.WriteLine($"\nBasic Operations: {a} + {b} = {sum}, {a} - {b} = {difference}");
            #endregion
            
            #region Advanced Operations
            double power = Math.Pow(a, 2);
            double sqrt = Math.Sqrt(a);
            Console.WriteLine($"Advanced Operations: {a}² = {power}, √{a} = {sqrt:F2}");
            #endregion
            
            #endregion
            
            #region String Operations
            string text = "Hello, World!";
            string upper = text.ToUpper();
            string lower = text.ToLower();
            Console.WriteLine($"String Operations: '{text}' -> '{upper}' -> '{lower}'");
            #endregion
            
            Console.WriteLine();
        }
        
        #endregion
        
        #region Best Practices and Guidelines
        
        /*
         * COMMENT BEST PRACTICES:
         * 
         * 1. Write comments that explain WHY, not WHAT
         * 2. Keep comments up-to-date with code changes
         * 3. Use clear, concise language
         * 4. Avoid obvious comments (e.g., // increment i)
         * 5. Use TODO, FIXME, HACK for special situations
         * 6. Document complex algorithms and business rules
         * 7. Use XML documentation for public APIs
         * 
         * REGION BEST PRACTICES:
         * 
         * 1. Use regions sparingly - prefer smaller classes
         * 2. Group related members together
         * 3. Use descriptive region names
         * 4. Common region categories:
         *    - Fields and Properties
         *    - Constructors
         *    - Public Methods
         *    - Private Methods
         *    - Event Handlers
         *    - Interface Implementations
         * 5. Don't nest regions too deeply
         * 6. Consider if class is too large if many regions needed
         */
        
        #region Common Region Examples
        
        // #region Fields and Properties
        private string _privateField;
        public string PublicProperty { get; set; }
        // #endregion
        
        // #region Constructors
        public CommentsAndRegions()
        {
            // Default constructor
        }
        
        public CommentsAndRegions(string value)
        {
            _privateField = value;
        }
        // #endregion
        
        // #region Public Methods
        public void PublicMethod()
        {
            // Public method implementation
        }
        // #endregion
        
        // #region Private Methods
        private void PrivateMethod()
        {
            // Private method implementation
        }
        // #endregion
        
        #endregion
        
        #endregion
    }
    
    #region Supporting Classes
    
    /// <summary>
    /// Example class to demonstrate documentation
    /// </summary>
    public class ExampleClass
    {
        #region Fields
        private int _value;
        #endregion
        
        #region Properties
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public int Value
        {
            get => _value;
            set => _value = value;
        }
        #endregion
        
        #region Methods
        /// <summary>
        /// Demonstrates a documented method
        /// </summary>
        /// <param name="input">The input value</param>
        /// <returns>The processed result</returns>
        public int ProcessValue(int input)
        {
            // Implementation details...
            return input * 2;
        }
        #endregion
    }
    
    #endregion
}