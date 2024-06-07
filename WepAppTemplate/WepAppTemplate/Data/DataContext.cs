using Microsoft.EntityFrameworkCore;

namespace APBDProbnyKol2.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Model> Models { get; set; }
    
}