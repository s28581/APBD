using Kol2_s28581.Models;
using Microsoft.EntityFrameworkCore;

namespace Kol2_s28581.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }


    public DbSet<Event> Events { get; set; }
    public DbSet<EventOrganiser> EventOrganisers { get; set; }
    public DbSet<Organiser> Organisers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EventOrganiser>()
            .HasKey(eo => new { eo.IdEvent, eo.IdOrganiser });

        modelBuilder.Entity<EventOrganiser>()
            .HasOne(eo => eo.Event)
            .WithMany(e => e.EventOrganisers)
            .HasForeignKey(eo => eo.IdEvent);
        
        
        modelBuilder.Entity<EventOrganiser>()
            .HasOne(eo => eo.Organiser)
            .WithMany(e => e.EventOrganisers)
            .HasForeignKey(eo => eo.IdOrganiser);
    }

}