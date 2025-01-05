using Final.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.Entities
{
    public class Product: AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock {  get; set; }
        public string ImageUrl { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Color>? Colors { get; set; } 
        public ICollection<Size>? Sizes { get; set; }
    }
}
