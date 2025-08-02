
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

class Program
{
    static async Task Main()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        using var context = new AppDbContext(options);
        await SeedDataAsync(context);

        var service = new ProductService(context);

        Console.WriteLine("🔁 Running both queries 10,000 times...");

        var sw1 = Stopwatch.StartNew();
        for (int i = 0; i < 10_000; i++)
            await service.GetProductById_StandardAsync(1);
        sw1.Stop();
        Console.WriteLine($"❌ Standard LINQ: {sw1.ElapsedMilliseconds} ms");

        var sw2 = Stopwatch.StartNew();
        for (int i = 0; i < 10_000; i++)
            await service.GetProductById_CompiledAsync(1);
        sw2.Stop();
        Console.WriteLine($"✅ Compiled LINQ: {sw2.ElapsedMilliseconds} ms");

        Console.ReadKey();
    }

    static async Task SeedDataAsync(AppDbContext context)
    {
        if (!await context.Products.AnyAsync())
        {
            for (int i = 1; i <= 1000; i++)
            {
                context.Products.Add(new Product { Name = $"Product {i}" });
            }

            await context.SaveChangesAsync();
        }
    }
}

public class ProductService
{
    private readonly AppDbContext _dbContext;
    public ProductService(AppDbContext dbContext) => _dbContext = dbContext;

    // ❌ Regular LINQ query (parsed every time)
    public async Task<Product?> GetProductById_StandardAsync(int id)
    {
        return await _dbContext.Products
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    // ✅ Compiled LINQ query (parsed once, reused)
    private static readonly Func<AppDbContext, int, Task<Product?>> _compiledQuery =
        EF.CompileAsyncQuery((AppDbContext context, int id) =>
            context.Products.FirstOrDefault(p => p.Id == id));

    public Task<Product?> GetProductById_CompiledAsync(int id)
    {
        return _compiledQuery(_dbContext, id);
    }
}

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Product> Products => Set<Product>();
}

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

