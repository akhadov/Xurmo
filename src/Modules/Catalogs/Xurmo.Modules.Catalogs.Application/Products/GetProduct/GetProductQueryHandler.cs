using System.Data.Common;
using Dapper;
using Xurmo.Common.Application.Data;
using Xurmo.Common.Application.Messaging;
using Xurmo.Common.Domain;
using Xurmo.Modules.Catalogs.Domain.Products;

namespace Xurmo.Modules.Catalogs.Application.Products.GetProduct;
internal sealed class GetProductQueryHandler(IDbConnectionFactory dbConnectionFactory)
    : IQueryHandler<GetProductQuery, ProductResponse>
{
    public async Task<Result<ProductResponse>> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        await using DbConnection connection = await dbConnectionFactory.OpenConnectionAsync();

        const string sql =
            $"""
            SELECT
                id AS {nameof(ProductResponse.Id)},
                name AS {nameof(ProductResponse.Name)},
                description AS {nameof(ProductResponse.Description)},
                image_path AS {nameof(ProductResponse.ImagePath)}
            FROM catalogs.products
            WHERE id = @ProductId
            """;

        ProductResponse? product = await connection.QuerySingleOrDefaultAsync<ProductResponse?>(sql, request);

        if (product is null)
        {
            return Result.Failure<ProductResponse>(ProductErrors.NotFound(request.ProductId));
        }

        return product;
    }
}
