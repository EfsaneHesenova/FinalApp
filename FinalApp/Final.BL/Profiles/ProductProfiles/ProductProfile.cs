using AutoMapper;
using Final.BL.DTOs.ProductDto;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles.ProductProfiles;

public class ProductProfile: Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>().ReverseMap();
    }
}
