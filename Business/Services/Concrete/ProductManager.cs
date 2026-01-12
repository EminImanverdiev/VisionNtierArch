using AutoMapper;
using Business.Services.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Concrete
{
    public class ProductManager: IProductService    
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;
        public ProductManager(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetProductDto>> GetAllProductsAsync()
        {
            var products = await _repository.GetAllAsync();
            return _mapper.Map<List<GetProductDto>>(products);
        }

    }
}
