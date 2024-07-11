public class Order
{
    public int OrderNumber { get; set; }
    public Pizza Pizza { get; set; }

    public Order(int orderNumber, Pizza pizza)
    {
        OrderNumber = orderNumber;
        Pizza = pizza;
    }
}
