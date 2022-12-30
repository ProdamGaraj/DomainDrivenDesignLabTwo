namespace MyApp.CustomerAggregate;

public enum CardType
{
    Mir = 1,
    Visa = 2,
    Mastercard = 3,
    AmericanExpress = 4
}

public class CardPayment : Payment
{
    public string CardNumber { get; private set; }
    public string CardHolderName { get; private set; }
    public string ExpiryDate { get; private set; }
    public CardType CardType { get; private set; }

    public CardPayment(string cardNumber, string cardHolderName, string expiryDate, CardType cardType) : base(PaymentType.Card)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        ExpiryDate = expiryDate;
        CardType = cardType;
    }
}