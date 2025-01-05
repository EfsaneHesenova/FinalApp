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
    public class SizeRepository: GenericRepository<Size>, ISizeRepository
    {
        public SizeRepository(AppDbContext context): base(context) { }
        
    }
}
