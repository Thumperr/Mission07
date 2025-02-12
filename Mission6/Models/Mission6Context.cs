using Microsoft.EntityFrameworkCore;

namespace Mission6.Models;

public class Mission6Context : DbContext
{
    public Mission6Context(DbContextOptions<Mission6Context> options) : base(options) // Constructor to set up options
    {
        
    }
    
    public DbSet<Application> Applications { get; set; }
}