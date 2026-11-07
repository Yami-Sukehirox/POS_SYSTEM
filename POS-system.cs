using System;
using System.Collections.Generic;

class POSSystem
{
    class Product
    {
        public int productId;
        public string productName;
        public decimal price;
        public int stock;
    }

    class CartItem
    {
        public Product product;
        public int quantity;
    }

    static List<Product> products = new List<Product>();
    static List<CartItem> cart = new List<CartItem>();

    static void Main(string[] args)
    {
        LoadProducts();

        int choice = 0;

        while (choice != 5)
        {
            DisplayMenu();

            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    ViewProducts();
                    break;

                case 2:
                    AddToCart();
                    break;

                case 3:
                    ViewCart();
                    break;

                case 4:
                    CheckOut();
                    break;

                case 5:
                    Console.WriteLine("Thank you for shopping!");
                    break;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }

  
    static void LoadProducts()
    {
        Product hamburger = new Product()
        {
            productId = 1,
            productName = "Hamburger",
            price = 45,
            stock = 100
        };

        products.Add(hamburger);

        Product cokeFloat = new Product()
        {
            productId = 2,
            productName = "Coke Float",
            price = 75,
            stock = 50
        };

        products.Add(cokeFloat);

        Product chicken = new Product()
        {
            productId = 3,
            productName = "Chicken",
            price = 100,
            stock = 30
        };

        products.Add(chicken);
    }

  
    static void DisplayMenu()
    {
        Console.WriteLine("\n===== MENU =====");
        Console.WriteLine("1. View Products");
        Console.WriteLine("2. Add to Cart");
        Console.WriteLine("3. View Cart");
        Console.WriteLine("4. Checkout");
        Console.WriteLine("5. Exit");
    }


    static void ViewProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No products available!");
            return;
        }

        Console.WriteLine("\n========= PRODUCT LIST ==========");

        foreach (Product product in products)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"Product ID: {product.productId}");
            Console.WriteLine($"Product Name: {product.productName}");
            Console.WriteLine($"Price: ${product.price}");
            Console.WriteLine($"Stock: {product.stock}");
        }
    }

    
    static Product GetProduct(int productId)
    {
        foreach (Product item in products)
        {
            if (item.productId == productId)
            {
                return item;
            }
        }

        return null;
    }

    
    static void AddToCart()
    {
        Console.Write("Enter Product ID: ");

        if (!int.TryParse(Console.ReadLine(), out int productId))
        {
            Console.WriteLine("Invalid Product ID!");
            return;
        }

        Product product = GetProduct(productId);

        if (product == null)
        {
            Console.WriteLine("Product not found!");
            return;
        }

        Console.Write("Enter Quantity: ");

        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid quantity!");
            return;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("Invalid quantity!");
            return;
        }

        CartItem existingItem = null;

        foreach (CartItem item in cart)
        {
            if (item.product.productId == productId)
            {
                existingItem = item;
                break;
            }
        }

        int currentQuantity = 0;

        if (existingItem != null)
        {
            currentQuantity = existingItem.quantity;
        }

        if (currentQuantity + quantity > product.stock)
        {
            Console.WriteLine("Not enough stock!");
            return;
        }

        if (existingItem != null)
        {
            existingItem.quantity += quantity;
        }
        else
        {
            CartItem newItem = new CartItem()
            {
                product = product,
                quantity = quantity
            };

            cart.Add(newItem);
        }

        Console.WriteLine("Product added to cart successfully!");
    }

   
    static void ViewCart()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty!");
            return;
        }

        Console.WriteLine("\n========= SHOPPING CART ==========");

        foreach (CartItem item in cart)
        {
            decimal subtotal = item.product.price * item.quantity;

            Console.WriteLine($"Product ID: {item.product.productId}");
            Console.WriteLine($"Product Name: {item.product.productName}");
            Console.WriteLine($"Price: ${item.product.price}");
            Console.WriteLine($"Quantity: {item.quantity}");
            Console.WriteLine($"Subtotal: ${subtotal}");

            Console.WriteLine("-----------------------------------");
        }

        Console.WriteLine($"Total: ${CalculateTotal()}");
    }


    static decimal CalculateTotal()
    {
        decimal total = 0;

        foreach (CartItem item in cart)
        {
            decimal subtotal = item.product.price * item.quantity;

            total += subtotal;
        }

        return total;
    }

    
    static void CheckOut()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty!");
            return;
        }

        decimal total = CalculateTotal();

        Console.WriteLine("\n======== CHECKOUT ========");
        Console.WriteLine($"Total Amount: ${total}");

        Console.Write("Enter your payment: $");

        if (!decimal.TryParse(Console.ReadLine(), out decimal payment))
        {
            Console.WriteLine("Invalid payment!");
            return;
        }

        if (payment < total)
        {
            Console.WriteLine("Not enough payment!");
            return;
        }

        decimal change = payment - total;

        foreach (CartItem item in cart)
        {
            item.product.stock -= item.quantity;
        }

        PrintReceipt(payment, change);

        cart.Clear();

        Console.WriteLine("Checkout successful!");
    }

    
    static void PrintReceipt(decimal payment, decimal change)
    {
        Console.WriteLine("\n========= OFFICIAL RECEIPT ==========");

        foreach (CartItem item in cart)
        {
            decimal subtotal = item.product.price * item.quantity;

            Console.WriteLine(item.product.productName);
            Console.WriteLine($"Price: ${item.product.price}");
            Console.WriteLine($"Quantity: {item.quantity}");
            Console.WriteLine($"Subtotal: ${subtotal}");
            Console.WriteLine("---------------------------------------");
        }

        Console.WriteLine($"Total: ${CalculateTotal()}");
        Console.WriteLine($"Payment: ${payment}");
        Console.WriteLine($"Change: %{change}");

        Console.WriteLine("=============================================");
        Console.WriteLine("Thank you for shopping!");
    }
}
