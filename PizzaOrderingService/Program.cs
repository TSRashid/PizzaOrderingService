class Program
{
    static SalesStatistics salesStatistics = new SalesStatistics();
    static int currentOrderNumber = 1;

    // main method 
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to the Pizza Ordering Service!");
            Pizza pizza = null;
            bool isConfirmed = false;

            while (!isConfirmed)
            {
                pizza = CreatePizza();
                Console.WriteLine("Your current pizza order:");
                Console.WriteLine(pizza);
                Console.WriteLine("Do you want to confirm this order? (yes/no):");
                string confirm = Console.ReadLine();
                if (confirm.ToLower() == "yes")
                {
                    isConfirmed = true;
                }
                else
                {
                    Console.WriteLine("Let's modify your pizza order.");
                }
            }

            var order = new Order(currentOrderNumber++, pizza);
            salesStatistics.RecordSale(pizza);
            Console.WriteLine($"Order confirmed! Your order number is: {order.OrderNumber}");

            Console.WriteLine("Do you want to order another pizza? (yes/no):");
            if (Console.ReadLine().ToLower() != "yes")
            {
                break;
            }
        }

        DisplayStatistics();
    }

    static Pizza CreatePizza()
    {
        Console.WriteLine("Choose size (Small, Medium, Large):");
        string size = Console.ReadLine();

        Console.WriteLine("Choose base (Thick, Thin):");
        string pizzaBase = Console.ReadLine();

        Console.WriteLine("How many additional toppings would you like? (0-3):");
        int numberOfToppings = int.Parse(Console.ReadLine());

        var availableToppings = new List<string> { "Pepperoni", "Chicken", "Extra Cheese", "Mushrooms", "Spinach", "Olives" };
        var additionalToppings = new List<string>();

        for (int i = 0; i < numberOfToppings; i++)
        {
            Console.WriteLine("Choose a topping from the following list:");
            foreach (var topping in availableToppings)
            {
                Console.WriteLine($"- {topping}");
            }
            string toppingChoice = Console.ReadLine();
            if (availableToppings.Contains(toppingChoice))
            {
                additionalToppings.Add(toppingChoice);
            }
            else
            {
                Console.WriteLine("Invalid topping choice. Please choose again.");
                i--;
            }
        }

        return new Pizza(size, pizzaBase, additionalToppings);
    }

    static void DisplayStatistics()
    {
        Console.WriteLine($"Total Pizzas Ordered: {salesStatistics.TotalPizzasOrdered}");
        Console.WriteLine("Base Sales:");
        foreach (var baseSale in salesStatistics.BaseSales)
        {
            Console.WriteLine($"{baseSale.Key}: {baseSale.Value}");
        }
        Console.WriteLine("Size Sales:");
        foreach (var sizeSale in salesStatistics.SizeSales)
        {
            Console.WriteLine($"{sizeSale.Key}: {sizeSale.Value}");
        }
        Console.WriteLine("Topping Sales:");
        foreach (var toppingSale in salesStatistics.ToppingSales)
        {
            Console.WriteLine($"{toppingSale.Key}: {toppingSale.Value}");
        }
        var (mostPopular, leastPopular) = salesStatistics.GetToppingStatistics();
        Console.WriteLine($"Most Popular Topping: {mostPopular}");
        Console.WriteLine($"Least Popular Topping: {leastPopular}");
    }
}
