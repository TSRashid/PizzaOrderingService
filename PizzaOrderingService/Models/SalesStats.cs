public class SalesStatistics
{
    public int TotalPizzasOrdered { get; set; } = 0;
    public Dictionary<string, int> BaseSales { get; set; } = new Dictionary<string, int>
    {
        { "Thick", 0 },
        { "Thin", 0 }
    };
    public Dictionary<string, int> SizeSales { get; set; } = new Dictionary<string, int>
    {
        { "Small", 0 },
        { "Medium", 0 },
        { "Large", 0 }
    };
    public Dictionary<string, int> ToppingSales { get; set; } = new Dictionary<string, int>
    {
        { "Pepperoni", 0 },
        { "Chicken", 0 },
        { "Extra Cheese", 0 },
        { "Mushrooms", 0 },
        { "Spinach", 0 },
        { "Olives", 0 }
    };

    public void RecordSale(Pizza pizza)
    {
        TotalPizzasOrdered++;
        BaseSales[pizza.Base]++;
        SizeSales[pizza.Size]++;
        foreach (var topping in pizza.Toppings)
        {
            ToppingSales[topping]++;
        }
    }

    public (string mostPopular, string leastPopular) GetToppingStatistics()
    {
        var mostPopular = ToppingSales.OrderByDescending(x => x.Value).First().Key;
        var leastPopular = ToppingSales.OrderBy(x => x.Value).First().Key;
        return (mostPopular, leastPopular);
    }
}
