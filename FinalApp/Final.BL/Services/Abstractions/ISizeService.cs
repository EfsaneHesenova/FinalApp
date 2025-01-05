using Final.BL.DTOs.ProductDto;
using Final.BL.DTOs.SizeDto;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions
{
    public interface ISizeService
    {
        Task<ICollection<Size>> GetAllAsync();
        Task<Size> CreateAsync(SizeCreateDto entityDto);
        Task<Size> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, SizeUpdateDto entityDto);
    }
}
