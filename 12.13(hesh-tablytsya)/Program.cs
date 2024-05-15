using System;
using System.Collections.Generic;

public class Price
{
    public string ProductName { get; set; }
    public string ShopName { get; set; }
    public double PriceValue { get; set; }

    public Price(string productName, string shopName, double price)
    {
        ProductName = productName;
        ShopName = shopName;
        PriceValue = price;
    }
}

public class ClosedHashTable
{
    private const int TableSize = 100; 
    private Price[] table; 

    public ClosedHashTable()
    {
        table = new Price[TableSize];
    }

    private int HashFunction(string key)
    {
        int hash = 0;
        foreach (char c in key)
        {
            hash += (int)c;
        }
        return hash % TableSize;
    }

    public void Insert(string productName, Price price)
    {
        int index = HashFunction(productName);
        while (table[index] != null)
        {
            index = (index + 1) % TableSize; 
        }
        table[index] = price;
    }

    public Price Search(string productName)
    {
        int index = HashFunction(productName);
        while (table[index] != null && table[index].ProductName != productName)
        {
            index = (index + 1) % TableSize; 
        }
        return table[index];
    }
}

class Program
{
    static void Main(string[] args)
    {
        ClosedHashTable hashTable = new ClosedHashTable();

        Console.Write("Enter the number of products: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.Write("Product name: ");
            string productName = Console.ReadLine();

            Console.Write("Shop name: ");
            string shopName = Console.ReadLine();

            Console.Write("Price in UAH: ");
            double price = double.Parse(Console.ReadLine());

            Price priceInfo = new Price(productName, shopName, price);
            hashTable.Insert(productName, priceInfo);
        }

        Console.Write("Enter the product name to search: ");
        string searchProduct = Console.ReadLine();

        Price result = hashTable.Search(searchProduct);
        if (result != null)
        {
            Console.WriteLine($"Product information: {result.ProductName}, Shop: {result.ShopName}, Price: {result.PriceValue} UAH");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

        Console.ReadLine(); 
    }
}
