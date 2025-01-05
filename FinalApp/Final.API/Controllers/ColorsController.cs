using Final.BL.DTOs.Color;
using Final.BL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }

        [HttpGet("GetAllColors")]
        [Authorize("Admin, Adminstrator,User")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {

                return StatusCode(StatusCodes.Status200OK, await _colorService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
        [HttpGet("ColorGetById/{id}")]
        [Authorize("Admin, Adminstrator,User")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _colorService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPost("CreateColor")]
        [Authorize("Admin, Adminstrator")]
        public async Task<IActionResult> CreateAsync(ColorCreateDto colorCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(colorCreateDto);
                }
                return StatusCode(StatusCodes.Status201Created, await _colorService.CreateAsync(colorCreateDto));
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
                return StatusCode(StatusCodes.Status200OK, await _colorService.DeleteAsync(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }

        [HttpPut]
        [Authorize("Admin, Adminstrator")]
        public async Task<IActionResult> UpdateAsync(int id, ColorUpdateDto colorUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(colorUpdateDto);
                }
                return StatusCode(StatusCodes.Status201Created, await _colorService.UpdateAsync(id, colorUpdateDto));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
