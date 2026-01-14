using Entities.DTOs.Products;


namespace Business.Services.Abstract
{
    public interface IProductService
    {
        public Task<List<GetAllProductDto>> GetAllProductsAsync();
        public Task<GetProductDto> GetProductById(Guid id);
        public Task AddProductAsync(CreateProductDto createProductDto);
        public Task DeleteProductAsync(Guid id);
    }
}
