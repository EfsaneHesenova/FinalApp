using AutoMapper;
using Final.BL.DTOs.ProductDto;
using Final.BL.ExternalServices.Abstractions;
using Final.BL.Services.Abstractions;
using Final.Core.Entities;
using Final.DAL.Repositories.Abstractions;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductService(IProductRepository productRepo, IMapper mapper, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _fileService = fileService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<Product> CreateAsync(ProductCreateDto entityDto)
        {
            Product createdProduct = _mapper.Map<Product>(entityDto);
            createdProduct.ImageUrl = await _fileService.SaveFileAsync(entityDto.Image, _webHostEnvironment.WebRootPath, new[] { ".jpg", ".jpeg", ".png", ".webp" }); 
            createdProduct.CreatedAt = DateTime.Now;
            var entity = await _productRepo.CreateAsync(createdProduct);
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
              Product product = await  _productRepo.GetByIdAsync(id);
              _fileService.DeleteFile(product.ImageUrl, _webHostEnvironment.WebRootPath);
                _productRepo.Delete(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
          return await _productRepo.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            if(!await _productRepo.IsExistAsync(id))
            {
                throw new NotImplementedException();
            }
            return await _productRepo.GetByIdAsync(id);
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var productEntity = await GetByIdAsync(id);
            _productRepo.SoftDelete(productEntity);
            await _productRepo.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, ProductUpdateDto entityDto)
        {
            var ProductEntity = await GetByIdAsync(id);
            _productRepo.Update(ProductEntity);
            Color updatedProduct = _mapper.Map<Color>(ProductEntity);
            updatedProduct.Id = id;
            await _productRepo.SaveChangesAsync();
            return true;
        }
    }
}
