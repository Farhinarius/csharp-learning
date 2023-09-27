﻿namespace Learning.Linq.Resources;

public class ProductInfoSmall
{

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public override string ToString() => $"Name: {Name}, Description: {Description}";
}
