using DataAccess.Repositories.Concrete.EFCore;
using DataAccess.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VisionDbContext _context;
        private readonly IProductRepository _productRepository;

        public UnitOfWork(VisionDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository =>_productRepository ?? new EfProductRepository(_context);  

        public async Task SaveAsync()
        {
          await  _context.SaveChangesAsync();
        }
    }
}
