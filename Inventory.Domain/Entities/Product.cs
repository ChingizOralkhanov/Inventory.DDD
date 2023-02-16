using Inventory.Domain.Enums;
using Inventory.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Entities
{
    public class Product : Entity
    {
        public string  Name { get; set; }
        public string  BarCode { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsWeighted { get; set; }
        public ProductStatus ProductStatus { get; set; }
    }
}
