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
                        Console.WriteLine("IDs       Names         Prices        Stocks");
                        foreach (var product in prods)
                        {
                            product.displayProducts();
                        }
                        break;

                    case 2:

                        bool orderMore = true; 
                        while (orderMore)
                        {
                            Console.WriteLine("IDs       Names         Prices        Stocks");
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
                                                bool itemInCart = false;

                                                for (int x = 0; x < cartCount; x++)
                                                {
                                                    if (cart[x].CartProduct.prodIds == product.prodIds)
                                                    {
                                                        cart[x].Quantity += quantity;
                                                        product.deductStock(quantity);
                                                        itemInCart = true;

                                                        Console.WriteLine($"Succcessfully added to cart!");
                                                        Console.WriteLine($"New Subtotal for Product {product.prodNames}: {cart[x].GetSubtotal():F2}");
                                                        break;
                                                    }
                                                }

                                                if (!itemInCart)
                                                {
                                                    if (cartCount < cart.Length)
                                                    {
                                                        CartItems newItem = new CartItems();
                                                        newItem.CartProduct = product;
                                                        newItem.Quantity = quantity;

                                                        cart[cartCount] = newItem;
                                                        cartCount++;

                                                        product.deductStock(quantity);
                                                        Console.WriteLine($"Succcessfully added to cart!");
                                                        Console.WriteLine($"Total: {product.getCartTotal(quantity):F2}");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Your cart is full!");
                                                    }
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

                            Console.WriteLine("Do you want to order more? (Y/N): ");
                            string userOrderMore = Console.ReadLine().ToUpper();

                            if (userOrderMore == "N")
                            {
                                orderMore = false;
                            }
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

                    case 4:
                        if (cartCount == 0)
                        {
                            Console.WriteLine("Your cart is empty. Please add items to your cart before to proceed in payment");
                            break;
                        }

                        double totalPayment = 0;
                        for (int x = 0; x < cartCount; x++)
                        {
                            totalPayment += cart[x].GetSubtotal();
                        }
                        Console.WriteLine("Payment");
                        Console.WriteLine($"Grand Total: {totalPayment:F2}");

                        double finalTotal = totalPayment;
                        double discountAmount = 0;

                        if (finalTotal >= 20000)
                        {
                            discountAmount = totalPayment * .1;
                            finalTotal = totalPayment - discountAmount;
                            Console.WriteLine($"10% Discount Applied: {discountAmount:F2}");

                        }
                        Console.WriteLine($"Final Amount to Pay: {finalTotal:F2}");
                        bool isPaid = false;


                        while (!isPaid)
                        {
                            Console.Write("Enter payment amount: ");
                            string paymentInput = Console.ReadLine();

                            if (double.TryParse(paymentInput, out double cashPayment))
                            {
                                if (cashPayment >= finalTotal)
                                {
                                    double change = cashPayment - finalTotal;

                                    Console.WriteLine("Official Receipt");
                                    Console.WriteLine("==================================================");
                                    Console.WriteLine($"{"Product Name",-15} | {"Qty",-5} | {"Subtotal"}");
                                    Console.WriteLine("--------------------------------------------------");

                                    for (int x = 0; x < cartCount; x++)
                                    {
                                        CartItems item = cart[x];
                                        string itemName = item.CartProduct.prodNames;
                                        Console.WriteLine($"{itemName,-15} | {item.Quantity,-5} | {item.GetSubtotal():F2}");
                                    }
                                    Console.WriteLine("---------------------------------------------------");
                                    Console.WriteLine($"Grant Total: {totalPayment}");

                                    if (discountAmount > 0)
                                    {
                                        Console.WriteLine($"Discount 10%: {discountAmount:F2}");
                                    }

                                    Console.WriteLine($"Final Total: {finalTotal:F2}");
                                    Console.WriteLine($"Cash Paid: {cashPayment:F2}");
                                    Console.WriteLine($"Change: {change:F2}");
                                    Console.WriteLine("=====================================================");
                                    Console.WriteLine("Thank you for Shopping in JA Gadgets & Accessories");

                                    cartCount = 0;
                                    isPaid = true;
                                }
                                else
                                {
                                    double shortAmount = finalTotal - cashPayment;
                                    Console.WriteLine($"Insuficient amount! Your cash is insufficient by {shortAmount:F2}");
                                }
                            }

                            else
                            {
                                Console.WriteLine("Invalid input. Please enter numbers only!");
                            }
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