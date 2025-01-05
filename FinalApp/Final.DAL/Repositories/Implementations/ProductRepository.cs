using Final.Core.Entities;
using Final.DAL.DAL;
using Final.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.DAL.Repositories.Implementations;

public class ProductRepository: GenericRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context): base(context)
    {
        
    }
}
