using AutoMapper;
using Final.BL.DTOs.SizeDto;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles.SizeProfiles;

public class SizeProfile: Profile
{
    public SizeProfile()
    {
        CreateMap<SizeCreateDto, Size>().ReverseMap();
        CreateMap<SizeUpdateDto, Size>().ReverseMap();
    }
}
