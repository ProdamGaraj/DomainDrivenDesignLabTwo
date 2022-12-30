namespace MyApp.CustomerAggregate;

public class PaypalPayment : Payment
{
    public string Email { get; private set; }

    public PaypalPayment(string email) : base(PaymentType.Paypal)
    {
        Email = email;
    }
}