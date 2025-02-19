namespace BusinessLogicLayer.DTO;

public record ProductRequest(
    Guid ProductId,
    string? ProductName,
    string? Category,
    double? UnitPrice,
    int? QuantityInStock
    )
{
    public ProductRequest() : this(default, default, default, default, default)
    {

    }
}