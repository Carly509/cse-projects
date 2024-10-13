using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        Product product1 = new Product("Laptop", "P001", 999.99m, 2);
        Product product2 = new Product("Mouse", "P002", 25.50m, 1);
        Product product3 = new Product("Keyboard", "P003", 45.00m, 1);


        Address address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("John Doe", address1);


        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);


        Address address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);


        DisplayOrderDetails(order1);
        DisplayOrderDetails(order2);
    }

    static void DisplayOrderDetails(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Price: ${order.CalculateTotalPrice():0.00}");
        Console.WriteLine("-----------------------------");
    }
}

public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public decimal TotalCost => price * quantity;

    public string Name => name;
    public string ProductId => productId;
}

public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool LivesInUSA() => address.IsInUSA();

    public string Name => name;
    public Address Address => address;
}

public class Address
{
    private string street;
    private string city;
    private string state;
    private string country;

    public Address(string street, string city, string state, string country)
    {
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
    }

    public bool IsInUSA() => country.Equals("USA", StringComparison.OrdinalIgnoreCase);

    public string FullAddress => $"{street}\n{city}, {state}\n{country}";
}

public class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalPrice()
    {
        decimal totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.TotalCost;
        }
        totalCost += customer.LivesInUSA() ? 5 : 35; // Shipping cost
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"{product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.Name}\n{customer.Address.FullAddress}";
    }
}
