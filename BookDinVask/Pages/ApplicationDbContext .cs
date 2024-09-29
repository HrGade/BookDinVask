using BookDinVask;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // DbSet for beboere, som vil blive mappet til en tabel i databasen
    public DbSet<Beboer> Beboere { get; set; }

    // Angiv den database vi vil bruge, dvs. "BookDinVask"
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Brug SQL Server og forbind til "BookDinVask"-databasen
            optionsBuilder.UseSqlServer("Server=localhost;Database=BookDinVask;Trusted_Connection=True;");
        }
    }
}
