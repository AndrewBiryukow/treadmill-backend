using Microsoft.EntityFrameworkCore;
using treadmill_server.Entities;

namespace treadmill_server.Contexts;

public class TreadmillEfCoreContext : DbContext, ITreadmillEfCoreContext
{
    public TreadmillEfCoreContext(DbContextOptions<TreadmillEfCoreContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    
    
}