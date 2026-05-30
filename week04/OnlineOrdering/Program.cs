
class Program
{
    static void Main(string[] args)
    {
        Address usAddress = new Address(
            "742 Evergreen Terrace",
            "Springfield",
            "IL",
            "USA"
        );

        Customer usCustomer = new Customer("Homer Simpson", usAddress);

        Order order1 = new Order(usCustomer);
        order1.AddProduct(new Product("Wireless Mouse",       "WM-1042", 29.99, 2));
        order1.AddProduct(new Product("USB-C Hub",            "UC-2210", 49.95, 1));
        order1.AddProduct(new Product("Laptop Stand",         "LS-0077", 24.50, 1));

        // Display Order 1
        Console.WriteLine("==========================================");
        Console.WriteLine("           ORDER 1 — DOMESTIC          ");
        Console.WriteLine("==========================================");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"  Order Total: ${order1.GetTotalCost():F2}");
        Console.WriteLine("  (includes $5.00 domestic shipping)");
        Console.WriteLine();
        Address intlAddress = new Address(
            "100 Wellington Street",
            "Ottawa",
            "Ontario",
            "Canada"
        );

        Customer intlCustomer = new Customer("Terrence Parker", intlAddress);

        Order order2 = new Order(intlCustomer);
        order2.AddProduct(new Product("Mechanical Keyboard", "KB-5531", 89.99, 1));
        order2.AddProduct(new Product("Monitor Riser",       "MR-3302", 34.95, 2));
        Console.WriteLine("==========================================");
        Console.WriteLine("        ORDER 2 — INTERNATIONAL        ");
        Console.WriteLine("==========================================");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine($"  Order Total: ${order2.GetTotalCost():F2}");
        Console.WriteLine("  (includes $35.00 international shipping)");
        Console.WriteLine();
    }
}