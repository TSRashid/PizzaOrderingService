public class Pizza
{
    public string Size { get; set; }
    public string Base { get; set; }
    public List<string> Toppings { get; set; } = new List<string>();

    public Pizza(string size, string pizzaBase, List<string> toppings)
    {
        Size = size;
        Base = pizzaBase;
        Toppings = toppings;
    }

    public override string ToString()
    {
        string toppings = Toppings.Count > 0 ? string.Join(", ", Toppings) : "No additional toppings";
        return $"Size: {Size}, Base: {Base}, Toppings: {toppings}";
    }
}
