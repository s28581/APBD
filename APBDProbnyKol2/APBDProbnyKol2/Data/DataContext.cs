using APBDProbnyKol2.Models;
using Microsoft.EntityFrameworkCore;

namespace APBDProbnyKol2.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<Album> Albumy { get; set; }
    public DbSet<Muzyk> Muzyka { get; set; }
    public DbSet<Utwor> Utwory { get; set; }
    public DbSet<Wytwornia> Wytwornie { get; set; }
    
}