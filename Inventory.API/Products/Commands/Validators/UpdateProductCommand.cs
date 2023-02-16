using FluentValidation;


namespace Inventory.API.Products.Commands.Validators
{
    public class UpdateProductCommandValidator :AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Product.Id).Null();
            RuleFor(x => x.Product.Name).NotEmpty();
            RuleFor(x => x.Product.ProductStatus).IsInEnum();
            RuleFor(x => x.Product.BarCode).NotEmpty();
        }
    }
}
