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
            Products product11 = new Products(011, "Power Bank", 1000.00, 25);
            Products product12 = new Products(012, "Flash Drive", 200.00, 100);
            Products product13 = new Products(013, "Memory Card", 100.00, 100);
            Products product14 = new Products(014, "Camera Lens", 2000.00, 15);
            Products product15 = new Products(015, "Camera", 10000.00, 10);

            Products[] prods = new Products[15];
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
            prods[10] = product11;
            prods[11] = product12;
            prods[12] = product13;
            prods[13] = product14;
            prods[14] = product15;

            CartItems[] cart = new CartItems[10];
            int cartCount = 0;
            bool isHere = true;

            while (isHere)
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("Welcome to JA Gadgets & Accessories");
                Console.WriteLine("===============================================");
                Console.WriteLine("1 - | - View Products");
                Console.WriteLine("2 - | - Add to Cart");
                Console.WriteLine("3 - | - View Cart");
                Console.WriteLine("4 - | - Payment");
                Console.WriteLine("5 - | - Exit");
                Console.WriteLine("===============================================");
                Console.Write("Select a number ONLY: ");    
                string user = Console.ReadLine();
                int choice;
                Console.WriteLine("-----------------------------------------------");
                if (!int.TryParse(user, out choice))
                {
                    Console.WriteLine("INVALID! Non-numeric inputs are not acceptable");
                }
                else if (choice > 5 || choice < 1)
                {
                    Console.WriteLine("INVALID! Select from number 1 to 5 ONLY!");
                }

                switch (choice)
                {

                    case 1:
                        bool isView = true;
                        while (isView)
                        {
                            Console.WriteLine("---------------  VIEW PRODUCTS  ---------------");
                            Console.WriteLine("IDs       Names         Prices        Stocks");
                            foreach (var product in prods)
                            {
                                product.displayProducts();
                            }
                            Console.WriteLine("------------------------------------------------");
                            Console.Write("Press anything to back to the main dashboard: ");
                            Console.ReadLine();
                            break;
                        }
                        break;

                    case 2:
                        bool orderMore = true; 
                        while (orderMore)
                        {
                            Console.WriteLine("----------------  ADD TO CART  ----------------");
                            Console.WriteLine("IDs       Names         Prices        Stocks");
                            foreach (var product in prods)
                            {
                                product.displayProducts();
                            }
                            Console.WriteLine("------------------------------------------------");

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
                                        Console.Write("Enter quantity: ");
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
                                                        Console.WriteLine("------------------------------------------------");
                                                        Console.WriteLine($"Succcessfully added to cart!");
                                                        Console.WriteLine($"New Subtotal for Product {product.prodNames}: {cart[x].GetSubtotal():F2}");
                                                        Console.WriteLine("------------------------------------------------");
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
                                                        Console.WriteLine("------------------------------------------------");
                                                        Console.WriteLine($"Succcessfully added to cart!");
                                                        Console.WriteLine($"Total: {product.getCartTotal(quantity):F2}");
                                                        Console.WriteLine("------------------------------------------------");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("------------------------------------------------");
                                                        Console.WriteLine("Your cart is full!");
                                                        Console.WriteLine("------------------------------------------------");
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("------------------------------------------------");
                                                Console.WriteLine($"Sorry! Not enough stock. Only {product.prodStocks} left");
                                                Console.WriteLine("------------------------------------------------");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("------------------------------------------------");
                                            Console.WriteLine("Invalid quantity format! Please enter quantity number");
                                            Console.WriteLine("------------------------------------------------");
                                        }
                                        break;
                                    }
                                }
                                if (!productFound)
                                {
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine("Product ID not found!");
                                    Console.WriteLine("------------------------------------------------");
                                }
                            }
                            else
                            {
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("Invalid ID format! Please enter Product ID number");
                                Console.WriteLine("------------------------------------------------");
                            }
                            Console.Write("Do you want to order again? (Press anything to order again / Press 'X' to exit): ");
                            string userOrderMore = Console.ReadLine().ToUpper();

                            if (userOrderMore == "X")
                            {
                                orderMore = false;
                            }
                        }                    
                        break;

                    case 3:
                        bool isCheckingCart = true;
                        while (isCheckingCart)
                        {
                            Console.WriteLine("-----------------  VIEW CART  -----------------");
                            if (cartCount == 0)
                            {
                                Console.WriteLine("------------------------------------------------");
                                Console.WriteLine("Your cart is empty!");
                                Console.WriteLine("------------------------------------------------");
                            }
                            else
                            {
                                Console.WriteLine($"{"Product Name",-15} | {"Qty",-5} | {"Price",-10} | {"Subtotal"}");
                                Console.WriteLine("------------------------------------------------");
                                double grandTotal = 0;
                                for (int x = 0; x < cartCount; x++)
                                {
                                    CartItems currentItem = cart[x];
                                    string name = currentItem.CartProduct.prodNames;
                                    int qty = currentItem.Quantity;
                                    double price = currentItem.CartProduct.prodPrices;
                                    double subTotal = currentItem.GetSubtotal();
                                    grandTotal += subTotal;
                                    Console.WriteLine($"{name,-15} | {qty,-5} | {price,-9:F2} | {subTotal:F2}");
                                }
                                Console.WriteLine("===============================================");
                                Console.WriteLine($"GRAND TOTAL:                          {grandTotal:F2}");
                            }
                            Console.WriteLine("------------------------------------------------");
                            Console.Write("Press anything to back to the main dashboard: ");
                            Console.ReadLine();
                            break;
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
                        Console.WriteLine("------------------  PAYMENT  ------------------");
                        Console.WriteLine($"Grand Total: {totalPayment:F2}");
                        double finalTotal = totalPayment;
                        double discountAmount = 0;
                        if (finalTotal >= 5000)
                        {
                            discountAmount = totalPayment * .1;
                            finalTotal = totalPayment - discountAmount;
                            Console.WriteLine($"10% Discount Applied: {discountAmount:F2}");
                        }
                        Console.WriteLine($"FINAL AMOUNT TO PAY: {finalTotal:F2}");
                        Console.WriteLine("===============================================");
                        bool isPaid = false;
                        while (!isPaid)
                        {
                            Console.Write("Enter your cash payment: ");
                            string paymentInput = Console.ReadLine();
                            if (double.TryParse(paymentInput, out double cashPayment))
                            {
                                if (cashPayment >= finalTotal)
                                {
                                    double change = cashPayment - finalTotal;
                                    Console.WriteLine("--------------- OFFICIAL RECEIPT  ---------------");
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine($"{"Product Name",-15} | {"Qty",-5} | {"Subtotal"}");
                                    Console.WriteLine("------------------------------------------------");
                                    for (int x = 0; x < cartCount; x++)
                                    {
                                        CartItems item = cart[x];
                                        string itemName = item.CartProduct.prodNames;
                                        Console.WriteLine($"{itemName,-15} | {item.Quantity,-5} | {item.GetSubtotal():F2}");
                                    }
                                    Console.WriteLine("------------------------------------------------");
                                    Console.WriteLine($"Grant Total: {totalPayment}");
                                    if (discountAmount > 0)
                                    {
                                        Console.WriteLine($"Discount 10%: {discountAmount:F2}");
                                    }
                                    Console.WriteLine($"Final Total: {finalTotal:F2}");
                                    Console.WriteLine($"Cash Paid: {cashPayment:F2}");
                                    Console.WriteLine($"Change: {change:F2}");
                                    Console.WriteLine("===============================================");
                                    Console.WriteLine("Thank you for Shopping in JA Gadgets & Accessories");
                                    Console.WriteLine("===============================================");
                                    Console.Write("Press anything to back to the main dashboard: ");
                                    Console.ReadLine();
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