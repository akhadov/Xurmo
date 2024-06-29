using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Xurmo.Modules.Catalogs.Application.Products.CreateProduct;
internal sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(p  => p.Name).NotEmpty();
        RuleFor(p => p.Description).NotEmpty();
    }
}
