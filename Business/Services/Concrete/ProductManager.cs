using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.Products;


namespace Business.Services.Concrete
{
    public class ProductManager: IProductService    
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ProductManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<GetAllProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<List<GetAllProductDto>>(products);
        }

        public async Task<GetProductDto> GetProductById(Guid id)
        {
            var result = await  _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);
            if (result is null)
            {
                throw new NotFoundException(ExceptionMessages.ProductNotFound);
            }

            return _mapper.Map<GetProductDto>(result);
        }
        public async Task AddProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            product.CreatedAt=DateTime.UtcNow;
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var result = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);
            if (result is null)
            {
                throw new NotFoundException(ExceptionMessages.ProductNotFound);
            }
            _unitOfWork.ProductRepository.Delete(result);
            await _unitOfWork.SaveAsync();

        }
    }
}
