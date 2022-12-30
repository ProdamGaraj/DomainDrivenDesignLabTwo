using System;

namespace MyApp.OrderAggregate;

public class Address
{
    public string Id { get; private set; }
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string ZipCode { get; private set; }
    public bool Deleted { get; set; } = false;

    public Address(string street, string city, string state, string country, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        Id = Guid.NewGuid().ToString();
    }
}