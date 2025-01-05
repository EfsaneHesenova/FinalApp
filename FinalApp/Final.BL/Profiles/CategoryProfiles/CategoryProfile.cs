using AutoMapper;
using Final.BL.DTOs.CategoryDto;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles.CategoryProfiles;

public class CategoryProfile: Profile
{
    public CategoryProfile()
    {
        CreateMap<CategoryCreateDto, Category>().ReverseMap();
        CreateMap<CategoryUpdateDto, Category>().ReverseMap();
    }
}
