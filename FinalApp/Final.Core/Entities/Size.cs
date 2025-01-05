using Final.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Core.Entities
{
    public class Size: AuditableEntity
    {
        public string Title { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }

    }
}
