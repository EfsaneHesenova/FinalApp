using Final.Core.Entities;
using Final.DAL.DAL;
using Final.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Repositories.Implementations
{
    public class ColorRepository: GenericRepository<Color>, IColorRepository
    {
        public ColorRepository(AppDbContext context): base(context) { }
        
    }
}
