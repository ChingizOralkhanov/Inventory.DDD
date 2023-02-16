using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.API.Products.Queries.Validators
{
    public class GetProdyctsByStatusQueryValidator : AbstractValidator<GetProductsByStatusQuery>
    {
        public GetProdyctsByStatusQueryValidator()
        {
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
