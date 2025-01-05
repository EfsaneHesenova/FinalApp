using Final.BL.DTOs.CategoryDto;
using Final.BL.DTOs.Color;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions;

public interface IColorService
{
    Task<ICollection<Color>> GetAllAsync();
    Task<Color> CreateAsync(ColorCreateDto entityDto);
    Task<Color> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<bool> UpdateAsync(int id, ColorUpdateDto entityDto);
}
