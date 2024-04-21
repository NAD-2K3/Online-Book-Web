using BookStoreApp.Patterns.Strategy;

internal class CustomerOrder
{
    public IBilling Strategy { get; set; }

    private decimal lastPrice;
    public CustomerOrder() { }
    public CustomerOrder(IBilling strategy)
    {
        this.Strategy = strategy;
    }

    public decimal SetMethod(decimal price)
    {
        lastPrice = this.Strategy.Checkout(price);
        return lastPrice;
    }

}