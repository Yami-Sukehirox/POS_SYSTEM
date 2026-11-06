using System;
using System.Collections.Generic;

class POSSystem
{
    class product 
    {
        public int productId;
        public string productName;
        public decimal Price;
        public int stock;
    }
    class CartItem 
    {
        public Product product;
        public int quantity;
    }

    static List<Product> product = new List<Product>();
    static List<CartItem> cart = new List<CartItem>();

    static void Main(String[] args) 
    {
        LoadProducts();

        int choice = 0;

        while (choice != 5) 
        {
            DisplayMenu();

            Console.WriteLine("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice!");
                continue;
            }
            switch (choice) 
            {
                case 1:
                    viewProducts();
                    break;
                case 2:
                    AddToCart();
                    break;
                case 3:
                    Viewcart();
                    break;
                case 4:
                    CheckOut();
                    break;
                case 5:
                    Console.WriteLine("Thank you for shopping!");
                    break;
                default:
                    Console.WriteLine("Invalid Choice!");
                    break;               
            }
        }
    }

    static void LoadProducts()
    {
        Product Hamburger = new Product()
        {
            productId = 1,
            productName = "Hamburger",
            price = 45,
            stock = 100
        };

        product.Add(Hamburger);

        Product Coke Float = new Product()
        {
            productId = 2,
            productName = "Coke Float",
            price = 75,
            stock = 50
        };

        product.Add(Coke Float);

        Product Chicken = new Product()
        {
            productId = 3,
            productName = "Chicken",
            price = 100,
            stock = 30
        };
        
        product.Add(Chicken);
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

    static void viewProducts()
    {
        if (products.Count == 0)
        {
            Console.WriteLine("No Products available!")
            return;
        }

        Console.WriteLine("\n========= PRODUCT LIST ==========");

        foreach (Product product in products)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"Product ID: {product.productId}");
            Console.WriteLine($"Product Name: {product.productName}");
            Console.WriteLine($"Price: {product.price}");
            Console.WriteLine($"Stock: {product.stock}");
        }
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

        if(product == null) 
        {
            Console.WriteLine("Product not found");
            return;
        }

        Console.WriteLine("Enter Quantity: ");

        if(!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Invalid quantity!");
            return;
        }

        if (quantity < 0) 
        {
            Console.WriteLine("Invalid Quantity.");
            return;
        }

        if (quantity > product.stock)
        {
            Console.WriteLine("Not enough stock.");
            return;
        }

        CartItem existingItem = null;

        foreach (CartItem item in cart)
        {
            if(item.product.productId == productId)
            {
                existingItem = item;
                break;
            }
        }

        if (existingItem != null)
        {
            existingItem.quantity += quantity;
        }
        else 
        {
            CartItem newItem = new CartItem()
            {
                product = quantity,
                quantity = quantity
            };

            cart.Add(newItem);
        }
        Console.WriteLine("Product Added to cart successfully!");
    }

    static void Viewcart()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty!")
            return;
        }

        decimal total = 0;

        Console.WriteLine("\n========= SHOPPING CART ==========");

        foreach (CartItem item in cart)
        {
            decimal subtotal = item.product.price * item.quantity;

            total += subtotal;

            Console.WriteLine($"Product ID: {item.product.productId}");
            Console.WriteLine($"Product Name: {item.product.productName}");
            Console.WriteLine($"Price: ${item.product.price}");
            Console.WriteLine($"Quantity: {item.product.quantity}");
            Console.WriteLine($"Subtotal: {subtotal}");

            Console.WriteLine("-----------------------------------");
        }
        Console.WriteLine($"Total: ${total}");
    }

    static void CheckOut()
    {
        if (cart.Count == 0)
        {
            Console.WriteLine("Your cart is empty");
            return;
        }

        decimal total = CalculateTotal();

        Console.WriteLine("\n======== CHECK OUT ========");
        Console.WriteLine($"Total Amount: ${total}");

        Console.Write("Enter your payment: ");

        if(!decimal.TryParse(Console.ReadLine(), out decimal payment))
        {
            Console.WriteLine("Invalid Payment!");
            return;
        }

        if (payment < total)
        {
            Console.WriteLine("Not Enough Payment");
            return;
        }

        decimal change = payment - total;

        foreach (CartItem item in cart) 
        {
            item.product.stock -= item.quantity;
        }

        PrintRecipt(Payment, change);
        cart.Clear();

        Console.WriteLine("Checkout Successful");
    }
}
    
 