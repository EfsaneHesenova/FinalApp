using Final.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.Entities
{
    public class Category: AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
