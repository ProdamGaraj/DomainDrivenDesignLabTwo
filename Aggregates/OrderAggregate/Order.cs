using System;
using System.Collections.Generic;
using MyApp.CustomerAggregate;
namespace MyApp.OrderAggregate;

public enum OrderStatus
{
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled
}

/// <summary>
/// Заказ с фабрикой
/// </summary>
public class Order
{
    public string Id { get; private set; }
    public Customer Customer { get; private set; }
    public DateTime OrderDate { get; private set; }
    public OrderStatus Status { get; private set; }
    public List<Product> Products { get; private set; }
    public Address ShippingAddress { get; private set; }
    public bool Deleted { get; set; } = false;

    private Order()
    {
        Id = Guid.NewGuid().ToString();
        Status = OrderStatus.Processing;
        OrderDate = DateTime.Now;
        Products = new List<Product>();
        
    }
    
    private Order(Customer customer): this()
    {
        Customer = customer;
    }
    
    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public void SetShippingAddress(Address address)
    {
        ShippingAddress = address;
    }

    public void SetStatus(OrderStatus status)
    {
        Status = status;
    }
    
    public override string ToString()
    {
        return $"Order ID: {Id}, Customer: {Customer}, Order Date: {OrderDate}, Status: {Status}";
    }
    
    public class OrderFactory
    {
        public Order Create(Customer customer)
        {
            var order = new Order(customer);
            return order;
        }
    }
}