using System;
using System.Collections.Generic;

namespace MyApp.CustomerAggregate;

/// <summary>
/// Покупатель с фабрикой
/// </summary>
public class Customer
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public bool Deleted { get; set; }
    public List<Payment> Payments { get; private set; }
    
    private Customer()
    {
        Id = Guid.NewGuid().ToString();
        Payments = new List<Payment>();
    }
    
    private Customer(string name, bool deleted=false): this()
    {
        Name = name;
    }

    public void AddPayment(Payment paymentMethod)
    {
        Payments.Add(paymentMethod);
    }
    
    public override string ToString()
    {
        return $"Customer ID: {Id}, Name: {Name}";
    }
    
    public class CustomerFactory
    {
        public Customer Create(string name, Payment payment)
        {
            var customer = new Customer(name);
            customer.AddPayment(payment);
            return customer;
        }
    }
}