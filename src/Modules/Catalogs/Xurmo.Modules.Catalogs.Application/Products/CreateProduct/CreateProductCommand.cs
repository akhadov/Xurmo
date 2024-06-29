using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xurmo.Common.Application.Messaging;

namespace Xurmo.Modules.Catalogs.Application.Products.CreateProduct;
public sealed record CreateProductCommand(
    string Name,
    string Description) : ICommand<Guid>;
