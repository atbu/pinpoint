using Microsoft.EntityFrameworkCore;
using Pinpoint.Data.Models;

namespace Pinpoint.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WorkItem>()
            .Property(workItem => workItem.Id)
            .HasDefaultValueSql("gen_random_uuid()");
        
        modelBuilder.Entity<WorkItem>()
            .Property(workItem => workItem.CreatedAt)
            .HasDefaultValueSql("now()");
    }

    public DbSet<WorkItem> WorkItems { get; set; }
}