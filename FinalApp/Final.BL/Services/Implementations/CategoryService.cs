using AutoMapper;
using Final.BL.DTOs.CategoryDto;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }

        public async Task<Category> CreateAsync(CategoryCreateDto entityDto)
        {
            Category createdCategory = _mapper.Map<Category>(entityDto);
            createdCategory.CreatedAt = DateTime.Now;
            var entity =  await _categoryRepo.CreateAsync(createdCategory);
            return entity;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Category  category = await _categoryRepo.GetByIdAsync(id);
                _categoryRepo.Delete(category);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Category>> GetAllAsync()
        {
           return await _categoryRepo.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            if(!await _categoryRepo.IsExistAsync(id))
            {
                throw new Exception();
            }
           return await _categoryRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var categoryEntity = await GetByIdAsync(id);
            _categoryRepo.SoftDelete(categoryEntity);
            await _categoryRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, CategoryUpdateDto entityDto)
        {
            var categoryEntity = await GetByIdAsync(id);
            _categoryRepo.Update(categoryEntity);
            var updatedCategory = _mapper.Map<Category>(categoryEntity);
            updatedCategory.Id = id;
            await _categoryRepo.SaveChangesAsync();
            return true;
        }
    }
}
