using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Repositories.Abstract;
using DataAccess.UnitOfWork.Abstract;
using Entities.Concrete;
using Entities.DTOs.Products;
using Microsoft.AspNetCore.Authorization;


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
        public async Task<IDataResult<List<GetAllProductDto>>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            if (products.Count==0)
            {
                return new ErrorDataResult<List<GetAllProductDto>>(_mapper.Map<List<GetAllProductDto>>(products),"Mehsul yoxdur");
            }
            return new SuccessDataResult<List<GetAllProductDto>>(_mapper.Map<List<GetAllProductDto>>(products), "Mehsullar siyahlandi");
        }
        public async Task<IDataResult<GetProductDto>> GetProductById(Guid id)
        {
            var result = await  _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);
            if (result is null)
            {
                return new ErrorDataResult<GetProductDto>(_mapper.Map<GetProductDto>(result),$"{id} li mehsul tapilmadi");
            }
            return new SuccessDataResult<GetProductDto>(_mapper.Map<GetProductDto>(result), $"{id} li mehsul tapildi");

        }
        public async Task<IResult> AddProductAsync(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);

            var getproductforName = await _unitOfWork.ProductRepository.GetAsync(p=>p.Name==createProductDto.Name);
            if (getproductforName is  not null)
            {
                return new ErrorResult("Mehsul elave edilmedi");
            }
            product.CreatedAt=DateTime.UtcNow;

            await _unitOfWork.ProductRepository.AddAsync(product);
            var result=  await _unitOfWork.SaveAsync();
            if (result==0)
            {
                return new ErrorResult("Mehsul elave edilmedi");
            }
            return new SuccessResult("Mehsul elave edildi");
        }

        public async Task<IResult> DeleteProductAsync(Guid id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);
            if (product is null)
            {
                throw new NotFoundException(ExceptionMessages.ProductNotFound);
            }
            _unitOfWork.ProductRepository.Delete(product);
            var result = await _unitOfWork.SaveAsync();
            if (result == 0)
            {
                return new ErrorResult("Mehsul siline bilmedi");
            }
            return new SuccessResult("Mehsul silindi");

        }
    }
}
