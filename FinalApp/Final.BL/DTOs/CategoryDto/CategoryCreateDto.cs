using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.DTOs.CategoryDto;
public class CategoryCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
}


