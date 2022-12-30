using System;

namespace MyApp.CustomerAggregate;

public enum PaymentType
{
    Paypal = 1,
    Stripe = 2,
    Card = 3
}
public abstract class Payment
{
    public string Id { get; private set; }
    public Customer Customer { get; private set; }
    public PaymentType Type { get; private set; }

    protected Payment(PaymentType type)
    {
        Type = type;
        Id = Guid.NewGuid().ToString();
    }
}