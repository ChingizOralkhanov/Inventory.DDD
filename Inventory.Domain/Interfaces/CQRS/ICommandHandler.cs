using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Domain.Interfaces.CQRS
{
    public interface ICommandHandler<TDefCommand> : IRequestHandler<TDefCommand, Unit>
        where TDefCommand : ICommand
    { }
    public interface ICommandHandler<TCommand, T> : IRequestHandler<TCommand, T>
        where TCommand : ICommand<T>
    { }
}
