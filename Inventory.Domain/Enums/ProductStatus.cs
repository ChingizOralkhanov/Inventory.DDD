using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Enums
{
    public enum ProductStatus
    {
        InStock = 0,
        Sold = 1,
        Damaged = 2,
        OutOfStock = 3,
    }
}
