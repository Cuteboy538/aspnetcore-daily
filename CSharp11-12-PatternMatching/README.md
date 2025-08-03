# C# 11/12 Pattern Matching – Cleaner, Smarter Code 🧠⚡

This repo demonstrates new and improved pattern matching features introduced in **C# 11** and **C# 12**, designed to make your code **simpler**, **safer**, and **more readable**.

## 🚀 Features Covered

1. **List Patterns**
2. **Character Patterns with Slice**
3. **Switch Expressions on Span<char>**
4. **Record Matching with Property Patterns**

---

## 🔍 Examples

### 1. List Pattern
```csharp
var numbers = new[] { 1, 2, 3 };
if (numbers is [1, 2, 3])
    Console.WriteLine("Exact match!");

2. Character Pattern Matching
char c = 'a';
var result = c switch
{
    >= 'a' and <= 'z' => "Lowercase",
    >= 'A' and <= 'Z' => "Uppercase",
    _ => "Other"
};


3. Span Pattern with UTF-8 Parsing
ReadOnlySpan<char> span = "Hi!";
var message = span switch
{
    ['H', 'i', '!'] => "Greeting detected!",
    _ => "Unknown"
};


4. Property Pattern in Records
record User(string Role, int Age);

var user = new User("Admin", 30);
if (user is { Role: "Admin", Age: >= 18 })
    Console.WriteLine("Access granted");



