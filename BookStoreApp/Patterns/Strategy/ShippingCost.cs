using BookStoreApp.Patterns.Strategy;

public class ShippingCost : IBilling
{
    public decimal Checkout(decimal price)
    {
        return price * 2;
    }
}