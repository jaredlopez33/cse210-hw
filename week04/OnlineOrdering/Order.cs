using System.Collections.Generic;
using System.Text;

public class Order
{
    private List<Product> _products;
    private Customer _customer;
    private const double US_SHIPPING_COST = 53.00;
    private const double INTERNATIONAL_SHIPPING_COST = 354.00;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }
    public Customer Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    public List<Product> Products
    {
        get { return _products; }
    }
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }
    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost based on customer location
        if (_customer.LivesInUSA())
        {
            total += US_SHIPPING_COST;
        }
        else
        {
            total += INTERNATIONAL_SHIPPING_COST;
        }

        return total;
    }
    public string GetPackingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("==== Packing Label ====");

        foreach (Product product in _products)
        {
            sb.AppendLine($"  Product: {product.Name}  |  ID: {product.ProductId}");
        }

        return sb.ToString().TrimEnd();
    }
    public string GetShippingLabel()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("==== Shipping Label ====");
        sb.AppendLine(_customer.Name);
        sb.Append(_customer.Address.GetFullAddress());
        return sb.ToString();
    }
}