namespace MyApp.CustomerAggregate;

public class StripePayment : Payment
{
    public string Token { get; private set; }

    public StripePayment(string token) : base(PaymentType.Stripe)
    {
        Token = token;
    }
}