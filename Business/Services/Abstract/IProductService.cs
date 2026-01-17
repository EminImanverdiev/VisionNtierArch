using Core.Utilities.Results.Abstract;
using Entities.DTOs.Products;


namespace Business.Services.Abstract
{
    public interface IProductService
    {
        public Task<IDataResult<List<GetAllProductDto>>> GetAllProductsAsync();
        public Task<IDataResult<GetProductDto>> GetProductById(Guid id);
        public Task<IResult> AddProductAsync(CreateProductDto createProductDto);
        public Task<IResult> DeleteProductAsync(Guid id);
    }
}
