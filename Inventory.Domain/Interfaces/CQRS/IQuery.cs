using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Interfaces.CQRS
{
    public interface IQuery<T> : IRequest<T>
    {
    }
}
