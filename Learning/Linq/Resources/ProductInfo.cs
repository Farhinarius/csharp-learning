namespace Learning.Linq.Resources;

public class ProductInfo
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public int NumberInStock { get; set; } = 0;

    public override string ToString() =>
        $"Name: {Name}, Descrption: {Description}, NumberInStock: {NumberInStock}";
}
