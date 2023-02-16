using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Primitives
{
    public abstract class Entity
    {
        protected Entity(Guid id, bool isDeleted)
        {
            Id = id;
            IsDeleted = isDeleted;
        }
        protected Entity()
        {

        }
        public Guid Id { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public virtual void DeleteRecord()
        {
            IsDeleted = true;
        }
    }
}
