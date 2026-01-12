
namespace DataAccess.EFCore
{
    public class VisionDbContext : IdentityDbContext<AppUser>
    {
        public VisionDbContext(DbContextOptions<VisionDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

    }
}
