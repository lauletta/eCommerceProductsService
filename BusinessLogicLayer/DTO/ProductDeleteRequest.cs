namespace BusinessLogicLayer.DTO;

public record ProductDeleteRequest(
    Guid ProductId,
    string? ProductName
    )
{
    public ProductDeleteRequest() : this(default, default)
    {

    }
}