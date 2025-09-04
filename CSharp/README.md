# C# Programming Examples

This repository contains comprehensive C# programming examples covering fundamental concepts and Object-Oriented Programming (OOP) principles. Each file demonstrates specific concepts with working code examples and detailed explanations.

## 📁 Repository Structure

```
CSharp/
├── README.md
├── Basics/
│   ├── 01_Introduction.cs
│   ├── 02_DataTypesAndVariables.cs
│   ├── 03_ConstantsAndReadonly.cs
│   ├── 04_Operators.cs
│   ├── 05_ControlFlow.cs
│   ├── 06_Loops.cs
│   ├── 07_MethodsAndParameters.cs
│   ├── 08_MethodOverloading.cs
│   ├── 09_PassByValueReference.cs
│   ├── 10_ArraysAndStrings.cs
│   ├── 11_TypeCastingAndConversion.cs
│   ├── 12_Namespaces.cs
│   └── 13_CommentsAndRegions.cs
├── OOPs/
│   ├── 01_ClassesAndObjects.cs
│   ├── 02_Inheritance.cs
│   ├── 03_Encapsulation.cs
│   ├── 04_Polymorphism.cs
│   ├── 05_Abstraction.cs
│   └── 06_Interfaces.cs
└── Advanced/
    └── (Future advanced topics)
```

## 🚀 Getting Started

### Prerequisites
- .NET 6.0 or later
- C# compiler
- Any IDE that supports C# (Visual Studio, VS Code, JetBrains Rider)

### Running the Examples
Each `.cs` file contains a complete, runnable example with a `Main` method. You can:

1. **Using dotnet CLI:**
   ```bash
   dotnet run Program.cs
   ```

2. **Using Visual Studio:**
   - Open the file
   - Set it as startup project
   - Press F5 to run

3. **Compile and run manually:**
   ```bash
   csc Program.cs
   Program.exe
   ```

## 📚 Basics

### Core Programming Concepts

| File | Topic | Key Concepts |
|------|-------|--------------|
| `01_Introduction.cs` | **Introduction to C# & .NET** | Program structure, namespaces, Main method, basic syntax |
| `02_DataTypesAndVariables.cs` | **Data Types & Variables** | Value types, reference types, implicit typing, nullable types |
| `03_ConstantsAndReadonly.cs` | **Constants & Readonly** | const vs readonly, compile-time vs runtime constants |
| `04_Operators.cs` | **Operators** | Arithmetic, logical, bitwise, comparison, assignment operators |
| `05_ControlFlow.cs` | **Control Flow** | if-else, switch statements, pattern matching |
| `06_Loops.cs` | **Loops** | for, while, do-while, foreach, loop control (break/continue) |
| `07_MethodsAndParameters.cs` | **Methods & Parameters** | Method declaration, parameters, return types, local functions |
| `08_MethodOverloading.cs` | **Method Overloading** | Multiple methods with same name, different signatures |
| `09_PassByValueReference.cs` | **Pass by Value/Reference** | ref, out, in parameters, value vs reference types |
| `10_ArraysAndStrings.cs` | **Arrays & Strings** | Arrays, multidimensional arrays, string operations, StringBuilder |
| `11_TypeCastingAndConversion.cs` | **Type Casting & Conversion** | Implicit/explicit casting, Convert class, parsing, as/is operators |
| `12_Namespaces.cs` | **Namespaces** | Namespace declaration, using statements, aliases |
| `13_CommentsAndRegions.cs` | **Comments & Regions** | Single-line, multi-line, XML documentation, code organization |

## 🎯 Object-Oriented Programming (OOP)

### OOP Principles and Concepts

| File | Topic | Key Concepts |
|------|-------|--------------|
| `01_ClassesAndObjects.cs` | **Classes and Objects** | Class definition, object creation, constructors, properties, access modifiers |
| `02_Inheritance.cs` | **Inheritance** | Base and derived classes, method overriding, base keyword, polymorphism |
| `03_Encapsulation.cs` | **Encapsulation** | Data hiding, properties with validation, access control |
| `04_Polymorphism.cs` | **Polymorphism** | Method overloading, method overriding, runtime polymorphism, virtual methods |
| `05_Abstraction.cs` | **Abstraction** | Abstract classes, abstract methods, template method pattern |
| `06_Interfaces.cs` | **Interfaces** | Interface definition, multiple inheritance, interface segregation |

## 🔥 Features Demonstrated

### Language Features
- ✅ **Modern C# Syntax** (C# 6.0 - 10.0 features)
- ✅ **Pattern Matching** (switch expressions, is patterns)
- ✅ **String Interpolation** ($"Hello {name}")
- ✅ **Expression-bodied Members** (=> syntax)
- ✅ **Auto-implemented Properties**
- ✅ **Nullable Reference Types**
- ✅ **Local Functions**
- ✅ **Tuple Syntax**

### Programming Concepts
- ✅ **SOLID Principles** (demonstrated in OOP examples)
- ✅ **Design Patterns** (Template Method, Strategy)
- ✅ **Error Handling** (exceptions, validation)
- ✅ **Memory Management** (value vs reference types)
- ✅ **Type Safety** (strong typing, generics basics)

## 📖 Learning Path

### Recommended Study Order:

#### **Phase 1: Fundamentals (Basics)**
1. Introduction to C# & .NET
2. Data Types & Variables
3. Operators
4. Control Flow
5. Loops
6. Methods & Parameters
7. Arrays & Strings

#### **Phase 2: Advanced Basics**
8. Method Overloading
9. Pass by Value/Reference
10. Type Casting & Conversion
11. Constants & Readonly
12. Namespaces
13. Comments & Regions

#### **Phase 3: Object-Oriented Programming**
1. Classes and Objects
2. Encapsulation
3. Inheritance
4. Polymorphism
5. Abstraction
6. Interfaces

## 💡 Code Examples Highlights

### Interactive Examples
Each file includes:
- **Working code examples** that you can run immediately
- **Console output** showing results
- **Multiple scenarios** demonstrating different use cases
- **Best practices** and common pitfalls
- **Comprehensive comments** explaining concepts

### Real-world Applications
Examples include practical scenarios like:
- 🏦 **Banking System** (accounts, transactions)
- 🎮 **Game Development** (players, characters)
- 💳 **Payment Processing** (multiple payment methods)
- 🚗 **Vehicle Management** (cars, inheritance hierarchies)
- 📊 **Data Processing** (different file formats)
- 🏢 **Employee Management** (different employee types)

## 🛠️ Advanced Topics (Coming Soon)

The `Advanced/` folder will include:
- Generics and Collections
- LINQ (Language Integrated Query)
- Async/Await Programming
- Exception Handling
- File I/O Operations
- Delegates and Events
- Reflection and Attributes
- Design Patterns

## 📝 Notes

### Code Style
- Follows C# naming conventions (PascalCase for public members, camelCase for private)
- Comprehensive XML documentation comments
- Clear and descriptive variable names
- Proper use of access modifiers

### Compatibility
- Compatible with .NET Framework 4.7.2+
- Compatible with .NET Core 3.1+
- Compatible with .NET 6.0+
- Uses features available in C# 8.0+ where noted

## 🤝 Contributing

Feel free to:
- Add more examples
- Improve existing code
- Fix bugs or typos
- Suggest new topics
- Share feedback

## 📚 Additional Resources

### Official Documentation
- [C# Programming Guide](https://docs.microsoft.com/en-us/dotnet/csharp/)
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [C# Language Reference](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/)

### Learning Resources
- [Microsoft Learn - C#](https://docs.microsoft.com/en-us/learn/paths/csharp-first-steps/)
- [C# Yellow Book](https://www.robmiles.com/c-yellow-book/)
- [Pluralsight C# Path](https://www.pluralsight.com/paths/csharp)

---

## 🎯 Quick Start

1. **Clone or download** this repository
2. **Navigate** to any `.cs` file
3. **Read the comments** to understand the concept
4. **Run the code** to see it in action
5. **Experiment** by modifying the examples
6. **Move to the next topic** when ready

Happy coding! 🚀

---

*Last updated: December 2024*
*Total examples: 19 files covering 25+ programming concepts*