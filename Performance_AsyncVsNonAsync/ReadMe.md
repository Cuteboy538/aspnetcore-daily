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

        Console.WriteLine("Testing Method without async/await:");
        var sw2 = Stopwatch.StartNew();
        var result2 = await service.GetProductWithoutAsync(1);
        sw2.Stop();
        Console.WriteLine($"Result: {result2.Name}, Time: {sw2.ElapsedTicks} ticks");

        Console.WriteLine();

        Console.WriteLine("Done. Press any key to exit...");
        Console.ReadKey();
    }
}

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ProductService
{
    // 🔴 BAD: Unnecessary async/await
    public async Task<ProductDto> GetProductWithAsyncAwait(int id)
    {
        var product = new ProductDto
        {
            Id = id,
            Name = "Product A"
        };

        // await here adds async state machine without real async work
        return await Task.FromResult(product);
    }

    // ✅ GOOD: No async/await when not needed
    public Task<ProductDto> GetProductWithoutAsync(int id)
    {
        var product = new ProductDto
        {
            Id = id,
            Name = "Product A"
        };

        return Task.FromResult(product);
    }
}
