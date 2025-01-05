using Final.BL.DTOs.ProductDto;
using Final.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        [Authorize("Admin, Adminstrator,User")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, await _productService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpGet("ProductGetById/{id}")]
        [Authorize("Admin, Adminstrator,User")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost("CreateProduct")]
        [Authorize("Admin, Adminstrator")]
        public async Task<IActionResult> CreateAsync(ProductCreateDto productCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(productCreateDto);
                }
                return StatusCode(StatusCodes.Status201Created, await _productService.CreateAsync(productCreateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _productService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Admin, Adminstrator")]
        public async Task<IActionResult> UpdateAsync(int id, ProductUpdateDto productUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(productUpdateDto);
                }
                return StatusCode(StatusCodes.Status201Created, await _productService.UpdateAsync(id, productUpdateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
