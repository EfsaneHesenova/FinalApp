using AutoMapper;
using Final.BL.DTOs.UserDto;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles.UserProfiles;

public class UserProfile: Profile
{
    public UserProfile()
    {
        CreateMap<LoginUserDto, AppUser>().ReverseMap();
        CreateMap<RegisterUserDto, AppUser>().ReverseMap();
    }
}
