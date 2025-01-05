using Final.BL.DTOs.CategoryDto;
using Final.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("GetAllCategories")]
        [Authorize("Admin, Adminstrator,User")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, await _categoryService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpGet("CategoryGetById/{id}")]
        [Authorize("Admin, Adminstrator,User")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _categoryService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost("CreateCategory")]
        [Authorize("Admin, Adminstrator")]
        public async Task<IActionResult> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(categoryCreateDto);
                }
                return StatusCode(StatusCodes.Status201Created, await _categoryService.CreateAsync(categoryCreateDto));
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
                return StatusCode(StatusCodes.Status200OK, await _categoryService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Admin, Adminstrator")]
        public async Task<IActionResult> UpdateAsync(int id, CategoryUpdateDto categoryUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(categoryUpdateDto);
                }
                return StatusCode(StatusCodes.Status201Created, await _categoryService.UpdateAsync(id, categoryUpdateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
