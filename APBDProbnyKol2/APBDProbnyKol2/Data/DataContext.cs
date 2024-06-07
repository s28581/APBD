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
    public DbSet<WykonawcaUtworu> WykonawcaUtworow { get; set; }
    public DbSet<Wytwornia> Wytwornie { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WykonawcaUtworu>()
            .HasKey(wu => new { wu.IdMuzyk, wu.IdUtwor });
        modelBuilder.Entity<WykonawcaUtworu>()
            .HasOne(w => w.Muzyk)
            .WithMany(wu => wu.WykonawcaUtworu)
            .HasForeignKey(w => w.IdMuzyk);
        modelBuilder.Entity<WykonawcaUtworu>()
            .HasOne(u => u.Utwor)
            .WithMany(wu => wu.WykonawcaUtworu)
            .HasForeignKey(u => u.IdUtwor);
    }
}