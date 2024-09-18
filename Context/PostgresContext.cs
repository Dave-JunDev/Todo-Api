using DTO;
using Microsoft.EntityFrameworkCore;

namespace Context;
public class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options)
    {
    }
    
    public DbSet<TodoDTO> Todos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoDTO>().ToTable("todo");
    }
}