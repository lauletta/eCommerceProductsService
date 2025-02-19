namespace BusinessLogicLayer.DTO;

public record AddProductRequest(
    Guid ProductId,
    string? ProductName,
    string? Category,
    double UnitPrice,
    int QuantityInStock
    )
{
    public AddProductRequest() : this(default, default, default, default, default)
    {

    }
}