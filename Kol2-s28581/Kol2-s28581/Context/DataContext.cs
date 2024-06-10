using Microsoft.EntityFrameworkCore;

namespace Kol2_s28581.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

}