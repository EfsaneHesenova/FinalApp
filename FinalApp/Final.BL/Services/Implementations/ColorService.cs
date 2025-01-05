using AutoMapper;
using Final.BL.DTOs.Color;
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
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepo;
        private readonly IMapper _mapper;
        public ColorService(IColorRepository colorRepo, IMapper mapper)
        {
            _colorRepo = colorRepo;
            _mapper = mapper;
        }


        public async Task<Color> CreateAsync(ColorCreateDto entityDto)
        {
            Color createdColor = _mapper.Map<Color>(entityDto);
            createdColor.CreatedAt = DateTime.Now;
            var entity = await _colorRepo.CreateAsync(createdColor);
            return entity;

        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Color color = await _colorRepo.GetByIdAsync(id);
                _colorRepo.Delete(color);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Color>> GetAllAsync()
        {
            return await _colorRepo.GetAllAsync();
        }

        public async Task<Color> GetByIdAsync(int id)
        {
            if (!await _colorRepo.IsExistAsync(id))
            {
                throw new Exception();
            }
            return await _colorRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var colorEntity = await GetByIdAsync(id);
            _colorRepo.SoftDelete(colorEntity);
            await _colorRepo.SaveChangesAsync();
            return true;

        }

        public async Task<bool> UpdateAsync(int id, ColorUpdateDto entityDto)
        {
            var ColorEntity = await GetByIdAsync(id);
            _colorRepo.Update(ColorEntity);
            Color updatedColor = _mapper.Map<Color>(ColorEntity);
            updatedColor.Id = id;
            await _colorRepo.SaveChangesAsync();
            return true;
        }
    }
}
