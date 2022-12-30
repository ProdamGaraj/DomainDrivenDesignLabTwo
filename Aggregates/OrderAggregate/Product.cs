using System;

namespace MyApp.OrderAggregate;

public class Product
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public bool Deleted { get; set; } = false;

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
        Id = Guid.NewGuid().ToString();
    }
}