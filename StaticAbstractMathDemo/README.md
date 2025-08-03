# Static Abstract Members in Interfaces – C# 11 Generic Math Demo

🚀 This project showcases the use of `static abstract` members in interfaces, introduced in C# 11. It enables truly generic math operations and clean factory patterns with compile-time safety.

## 💡 Features

- Generic math with interfaces
- Type-safe factory logic
- Cleaner code via static polymorphism

## 📄 Example

```csharp
interface IAddable<TSelf>
    where TSelf : IAddable<TSelf>
{
    static abstract TSelf operator +(TSelf a, TSelf b);
}

public readonly struct Distance : IAddable<Distance>
{
    public double Value { get; }

    public Distance(double value)
    {
        Value = value;
    }

    public static Distance operator +(Distance a, Distance b)
        => new(a.Value + b.Value);
}


...

var d1 = new Distance(5);
var d2 = new Distance(3);
var sum = d1 + d2;
Console.WriteLine(sum); // Output: Distance { value = 8 }
