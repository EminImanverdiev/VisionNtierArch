using Business.Services.Abstract;
using Core.Utilities.Results.Concrete;
using Entities.DTOs.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VisionAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _service.GetAllProductsAsync();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> GetProductById(Guid id)
        {
            var result = await _service.GetProductById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto)
        {
           var result= await _service.AddProductAsync(createProductDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(new ErrorResult("TTest"));
        }
        [HttpDelete]
        public async Task<IActionResult> Remove(Guid id)
        {
            var result = await _service.DeleteProductAsync(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
