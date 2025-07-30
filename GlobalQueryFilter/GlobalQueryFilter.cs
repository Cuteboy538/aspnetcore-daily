using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

#region ## Entity Class

/// <summary>
/// Represents a blog post entity with a soft-delete flag.
/// </summary>
public class Post
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public bool IsDeleted { get; set; } // Soft delete marker
}

#endregion

#region ## DbContext with Global Query Filter

/// <summary>
/// Application's database context with a global query filter on Posts.
/// </summary>
public class AppDbContext : DbContext
{
    public DbSet<Post> Posts => Set<Post>();

    /// <summary>
    /// Configure to use In-Memory database for this demo.
    /// </summary>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("EFCoreGlobalQueryFilterDemo");
    }

    /// <summary>
    /// Define model configurations including global query filters.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ## Global Query Filter ##
        // This will automatically filter out all posts where IsDeleted == true.
        modelBuilder.Entity<Post>().HasQueryFilter(p => !p.IsDeleted);
    }
}

#endregion

#region ## Program Execution

class Program
{
    static void Main()
    {
        using var context = new AppDbContext();

        // ## Seed Data ##
        context.Posts.AddRange(new List<Post>
        {
            new Post { Title = "Welcome to EF Core", IsDeleted = false },
            new Post { Title = "Deleted Post", IsDeleted = true },
            new Post { Title = "Global Query Filters", IsDeleted = false }
        });
        context.SaveChanges();

        // ## Query All Posts ##
        var activePosts = context.Posts.ToList();

        Console.WriteLine("## Active (Non-deleted) Posts:");
        foreach (var post in activePosts)
        {
            Console.WriteLine($"- {post.Title}");
        }

        // ## Expected Output ##
        // Only non-deleted posts will be shown because of the global query filter.
    }
}

#endregion
