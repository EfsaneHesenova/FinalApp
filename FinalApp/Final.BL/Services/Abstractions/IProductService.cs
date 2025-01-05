using Final.BL.DTOs.Color;
using Final.BL.DTOs.ProductDto;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Abstractions
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllAsync();
        Task<Product> CreateAsync(ProductCreateDto entityDto);
        Task<Product> GetByIdAsync(int id);
        Task<bool> SoftDeleteAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(int id, ProductUpdateDto entityDto);
    }
}
