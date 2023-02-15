using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MediatR;
using Inventory.Domain.Interfaces.CQRS;
using ICommand = Inventory.Domain.Interfaces.CQRS.ICommand;

namespace Inventory.Web.Controllers.Common
{
    public class BaseController<T> : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IOptions<ApiBehaviorOptions> _apiBehaviorOptions;
        protected readonly ILogger _logger;
        protected readonly CancellationToken _cancellationToken;


        public BaseController(IMediator mediator, IOptions<ApiBehaviorOptions> apiBehaviorOptions, ILogger logger, CancellationToken cancellationToken)
        {
            _mediator = mediator;
            _apiBehaviorOptions = apiBehaviorOptions;
            _logger = logger;
            _cancellationToken = cancellationToken;
        }

        protected virtual async Task<IActionResult> CommandAction<TResult>(ICommand<TResult> command)
        {
            try
            {
                TResult result = await _mediator.Send(command, _cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        protected virtual async Task<IActionResult> CommandAction(ICommand command)
        {
            try
            {
                await this._mediator.Send(command, _cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        protected virtual async Task<IActionResult> QueryAction<TResult>(IQuery<TResult> query)
        {
            try
            {
                TResult result = await this._mediator.Send(query, _cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
