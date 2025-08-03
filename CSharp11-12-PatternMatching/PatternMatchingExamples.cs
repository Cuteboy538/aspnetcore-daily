
using System;

public class Program
{
    public static void Main(string[] args)
    {

        // C# 11 - Raw string + recursive pattern matching
        string input = "error: 404";
        if (input is ['e', .. var rest] && rest.Contains("404"))
            Console.WriteLine("It's a 404 error!");

        // C# 11 - List pattern matching
        int[] numbers = [1, 2, 3];
        if (numbers is [1, 2, 3])
            Console.WriteLine("Exact pattern match!");

        // C# 12 - Enhanced switch with spans + constants
        ReadOnlySpan<char> span = "Yes";
        const string YES = "Yes";
        var result = span switch
        {
        [.. var s] when s.SequenceEqual(YES) => "Confirmed",
            _ => "Unknown"
        };
        Console.WriteLine(result);

        // C# 12 - Primary constructors + pattern matching in records
        
        User user = new("Alice", 25);
        var message = user switch
        {
            { Age: >= 18 } => "Adult",
            _ => "Minor"
        };
        Console.WriteLine(message);

    }
}

public record User(string Name, int Age);
