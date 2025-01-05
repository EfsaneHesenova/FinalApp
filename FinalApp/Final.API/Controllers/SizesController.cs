using Final.BL.DTOs.SizeDto;
using Final.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizesController : ControllerBase
    {
        private readonly ISizeService _sizeService;

        public SizesController(ISizeService sizeService)
        {
            _sizeService = sizeService;
        }

        [HttpGet("GetAllSizes")]
        [Authorize("Admin, Adminstrator,User")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, await _sizeService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpGet("SizeGetById/{id}")]
        [Authorize("Admin, Adminstrator,User")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _sizeService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost("CreateSize")]
        [Authorize("Admin, Adminstrator")]
        public async Task<IActionResult> CreateAsync(SizeCreateDto sizeCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(sizeCreateDto);
                }
                return StatusCode(StatusCodes.Status201Created, await _sizeService.CreateAsync(sizeCreateDto));
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
                return StatusCode(StatusCodes.Status200OK, await _sizeService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Admin, Adminstrator")]
        public async Task<IActionResult> UpdateAsync(int id, SizeUpdateDto sizeUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(sizeUpdateDto);
                }
                return StatusCode(StatusCodes.Status201Created, await _sizeService.UpdateAsync(id, sizeUpdateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
