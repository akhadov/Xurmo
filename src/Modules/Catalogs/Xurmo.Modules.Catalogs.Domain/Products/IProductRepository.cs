using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xurmo.Modules.Catalogs.Domain.Products;
public interface IProductRepository
{
    public Task<Product?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    void Insert(Product product);
}
