// ✅ Topic: Static Abstract Members in Interfaces (C# 11)
// 🔍 Use Case: Enable generic math & factory patterns

using System;

// Define a generic interface with a static abstract method
public interface IParser<T>
{
    static abstract T Parse(string input);
}

// Concrete implementation for int parsing
public struct IntParser : IParser<int>
{
    public static int Parse(string input) => int.Parse(input);
}

// Concrete implementation for double parsing
public struct DoubleParser : IParser<double>
{
    public static double Parse(string input) => double.Parse(input);
}

// Generic utility method that uses static abstract method from interface
public static class ParserUtil
{
    public static T ParseValue<T, TParser>(string input)
        where TParser : IParser<T>
    {
        return TParser.Parse(input);
    }
}

// Example usage
public class Program
{
    public static void Main()
    {
        int intValue = ParserUtil.ParseValue<int, IntParser>("42");
        double doubleValue = ParserUtil.ParseValue<double, DoubleParser>("3.14");

        Console.WriteLine($"Parsed int: {intValue}");
        Console.WriteLine($"Parsed double: {doubleValue}");
    }
}
