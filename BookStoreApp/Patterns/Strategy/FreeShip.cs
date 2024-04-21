using BookStoreApp.Patterns.Strategy;

public class FreeShip : IBilling
{
    public decimal Checkout(decimal price)
    {
        return price;
    }
}