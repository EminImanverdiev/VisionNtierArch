using Entities.DTOs.Products;


namespace Business.Services.Abstract
{
    public interface IProductService
    {
        public Task<List<GetProductDto>> GetAllProductsAsync();

    }
}
