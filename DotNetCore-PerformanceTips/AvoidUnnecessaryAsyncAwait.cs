// File: AvoidUnnecessaryAsyncAwait.cs
// Purpose: Demonstrates performance difference between unnecessary async/await usage
//          and optimized Task-returning method in .NET Core

using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var service = new ProductService();

        Console.WriteLine("Testing Async Method with unnecessary await:");
        var sw1 = Stopwatch.StartNew();
        var result1 = await service.GetProductWithAsyncAwait(1);
        sw1.Stop();
        Console.WriteLine($"Result: {result1.Name}, Time: {sw1.ElapsedTicks} ticks");

        Console.WriteLine();

        Console.WriteLine("Testing Optimized Method without async/await:");
        var sw2 = Stopwatch.StartNew();
        var result2 = await service.GetProductWithoutAsync(1);
        sw2.Stop();
        Console.WriteLine($"Result: {result2.Name}, Time: {sw2.ElapsedTicks} ticks");

        Console.WriteLine();
        Console.WriteLine("Done. Press any key to exit...");
        Console.ReadKey();
    }
}

// Simple DTO representing a product
public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ProductService
{
    // 🔴 BEFORE: Adds unnecessary async state machine
    public async Task<ProductDto> GetProductWithAsyncAwait(int id)
    {
        var product = new ProductDto
        {
            Id = id,
            Name = "Product A"
        };

        // This await is redundant and causes async overhead
        return await Task.FromResult(product);
    }

    // ✅ AFTER: Properly optimized method without async/await
    public Task<ProductDto> GetProductWithoutAsync(int id)
    {
        var product = new ProductDto
        {
            Id = id,
            Name = "Product A"
        };

        // No unnecessary overhead — simple and efficient
        return Task.FromResult(product);
    }
}
