using AutoMapper;
using Final.BL.DTOs.SizeDto;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Implementations
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepo;
        private readonly IMapper _mapper;
        public SizeService(ISizeRepository sizeRepo, IMapper mapper)
        {
            _sizeRepo = sizeRepo;
            _mapper = mapper;
        }

        public async Task<Size> CreateAsync(SizeCreateDto entityDto)
        {
            Size createdSize = _mapper.Map<Size>(entityDto);
            createdSize.CreatedAt = DateTime.Now;
            var entity = await _sizeRepo.CreateAsync(createdSize);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Size size = await _sizeRepo.GetByIdAsync(id);
                _sizeRepo.Delete(size);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Size>> GetAllAsync()
        {
         return await _sizeRepo.GetAllAsync();
        }

        public async Task<Size> GetByIdAsync(int id)
        {
            if (!await _sizeRepo.IsExistAsync(id))
            {
                throw new NotImplementedException();
            }
            return await _sizeRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var sizeEntity = await GetByIdAsync(id);
            _sizeRepo.SoftDelete(sizeEntity);
            await _sizeRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, SizeUpdateDto entityDto)
        {
            var sizeEntity = await GetByIdAsync(id);
            _sizeRepo.Update(sizeEntity);
            Color updatedProduct = _mapper.Map<Color>(sizeEntity);
            updatedProduct.Id = id;
            await _sizeRepo.SaveChangesAsync();
            return true;
        }
    }
}
