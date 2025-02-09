﻿using AutoMapper;
using Final.BL.DTOs.Color;
using Final.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Profiles.ColorProfiles;

public class ColorProfile: Profile
{
    public ColorProfile()
    {
        CreateMap<ColorCreateDto, Color>().ReverseMap();
        CreateMap<ColorUpdateDto, Color>().ReverseMap();
    }
}
