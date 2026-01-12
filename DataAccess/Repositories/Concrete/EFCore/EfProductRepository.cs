namespace DataAccess.Repositories.Concrete.EFCore
{
    public class EfProductRepository : EfBaseRepository<Product, VisionDbContext>, IProductRepository
    {
        public EfProductRepository(VisionDbContext context) : base(context)
        {
        }
    }
}
