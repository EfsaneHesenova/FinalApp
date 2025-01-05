using Final.BL.DTOs.CategoryDto;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<ICollection<Category>> GetAllAsync();
        Task<Category> CreateAsync(CategoryCreateDto entityDto);
        Task<Category> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, CategoryUpdateDto entityDto);
    }
}
