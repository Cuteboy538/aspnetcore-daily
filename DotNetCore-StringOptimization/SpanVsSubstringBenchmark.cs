

public class Program
{
    public static void Main(string[] args)
    {

// BEFORE – using Substring (creates allocations)
string input = "Order:12345,Date:2024-08-30";
string orderPart = input.Substring(6, 5); // allocates new string
string datePart = input.Substring(17);   // allocates new string
Console.WriteLine($"Order = {orderPart}, Date = {datePart}");


// AFTER – using Span<T> (no allocations)
ReadOnlySpan<char> inputSpan = "Order:12345,Date:2024-08-30";
ReadOnlySpan<char> order = inputSpan.Slice(6, 5);
ReadOnlySpan<char> date = inputSpan.Slice(17);
Console.WriteLine($"Order = {order.ToString()}, Date = {date.ToString()}");

    }
}
