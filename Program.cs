using System;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace JAShoppingCartSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Products product1 = new Products(001, "Laptop", 40000.00, 60); 
            Products product2 = new Products(002, "Tablet", 30000.00, 60); 
            Products product3 = new Products(003, "Smartphone", 20000.00, 60); 
            Products product4 = new Products(004, "Earphone", 400.00, 80); 
            Products product5 = new Products(005, "Headphone", 1000.00, 80); 
            Products product6 = new Products(006, "Keyboard", 1000.00, 75); 
            Products product7 = new Products(007, "Mouse", 500.00, 75); 
            Products product8 = new Products(008, "Microphone", 3000.00, 50); 
            Products product9 = new Products(009, "Printer", 30000.00, 30); 
            Products product10 = new Products(010, "Fan Cooler", 2000.00, 90);

            Products[] prods = new Products[10];
            prods[0] = product1;
            prods[1] = product2;
            prods[2] = product3;
            prods[3] = product4;
            prods[4] = product5;
            prods[5] = product6;
            prods[6] = product7;
            prods[7] = product8;
            prods[8] = product9;
            prods[9] = product10;

            CartItems[] cart = new CartItems[10];

            int cartCount = 0;

            bool isHere = true;

            while (isHere)
            {
                Console.WriteLine("Welcome to JA Gadgets & Accessories");
                Console.WriteLine("1 - View Products");
                Console.WriteLine("2 - Add to Cart");
                Console.WriteLine("3 - Check Cart");
                Console.WriteLine("4 - Payment");
                Console.WriteLine("5 - Exit");
                Console.Write("Select a number ONLY: ");
                string user = Console.ReadLine();
                int choice;

                if (!int.TryParse(user, out choice))
                {
                    Console.WriteLine("Non-numeric numbers are not acceptable");
                }

                if (choice > 5 || choice < 1)
                {
                    Console.WriteLine("Select from number 1 to 5 ONLY!");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("PRODUCTS");
                        Console.WriteLine("IDs |     Names     |   Prices   |   Stocks");
                        foreach (var product in prods)
                        {
                            product.displayProducts();
                        }
                        break;

                    case 2:

                        Console.WriteLine("IDs |     Names     |   Prices   |   Stocks");
                        foreach (var product in prods)
                        {
                            product.displayProducts();
                        }
                        
                        Console.Write("Choose product ID number to add to cart: ");
                        string choiceProd = Console.ReadLine();
                        if (int.TryParse(choiceProd, out int choiceProd1))
                        {
                            bool productFound = false;
                            foreach (var product in prods)
                            {
                                if (choiceProd1 == product.prodIds)
                                {
                                    productFound = true;
                                    Console.Write("Enter quantity to buy: ");
                                    string qtyInput = Console.ReadLine();
                                    if (int.TryParse(qtyInput, out int quantity) && quantity > 0)
                                    {
                                        if (product.enoughStock(quantity))
                                        {
                                            product.deductStock(quantity);

                                            if (cartCount < cart.Length)
                                            {
                                                CartItems newItem = new CartItems();
                                                newItem.CartProduct = product;
                                                newItem.Quantity = quantity;
                                                cart[cartCount] = newItem;
                                                cartCount++;

                                                Console.WriteLine($"Succcessfully added to cart!");
                                                Console.WriteLine($"Total: {product.getCartTotal(quantity):F2}");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Your cart is full!");
                                            }
                                        }

                                        else
                                        {
                                            Console.WriteLine($"Sorry! Not enough stock. Only {product.prodStocks} left");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid quantity entered!");
                                    }
                                    break;
                                }
                            }
                            if (!productFound)
                            {
                                Console.WriteLine("Product ID not found!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID format!");
                        }
                        
                        break;

                    case 3:
                        Console.WriteLine("Your Shopping Cart");
                        if (cartCount == 0)
                        {
                            Console.WriteLine("Your cart is empty");
                        }
                        else
                        {
                            Console.WriteLine($"{"Product Name", -15} | {"Qty", -5} | {"Price", -10} | {"Subtotal"}");
                            Console.WriteLine("=======================================================================");
                            double grandTotal = 0;

                            for (int x = 0; x < cartCount; x++)
                            {
                                CartItems currentItem = cart[x];
                                string name = currentItem.CartProduct.prodNames;
                                int qty = currentItem.Quantity;
                                double price = currentItem.CartProduct.prodPrices;
                                double subTotal = currentItem.GetSubtotal();
                                grandTotal += subTotal;
                                Console.WriteLine($"{name, -15} | {qty, -5} | {price, -9:F2} | {subTotal:F2}");
                            }
                            Console.WriteLine("=====================================================================");
                            Console.WriteLine($"Grand Total: {grandTotal:F2}");
                        }

                        break;
                    
                    case 5:
                        Console.WriteLine("Thanks for visiting!");
                        isHere = false;
                        break;
                        
                }
            }
        }
    }
}       