using Microsoft.EntityFrameworkCore;
using ASP.NET_DB.Models;

namespace ASP.NET_DB.Data;

public class PersonenDbContext : DbContext
{
    public PersonenDbContext(DbContextOptions<PersonenDbContext> options)
        : base(options)
    {
    }
    public DbSet<Personen> Personen { get; set; }
    
}
