using System;
using System.Runtime.CompilerServices;
using System.Transactions;

namespace JAShoppingCartSystem
{
    class Program
    {
        static void Main(string[] args)
        {      
            Products product1 = new Products(001, "Laptop", 40000.00, 60, "Gadgets"); 
            Products product2 = new Products(002, "Tablet", 30000.00, 60, "Gadgets"); 
            Products product3 = new Products(003, "Smartphone", 20000.00, 60, "Gadgets"); 
            Products product4 = new Products(004, "Earphone", 400.00, 80, "Audio"); 
            Products product5 = new Products(005, "Headphone", 1000.00, 80, "Audio"); 
            Products product6 = new Products(006, "Keyboard", 1000.00, 75, "Peripherals"); 
            Products product7 = new Products(007, "Mouse", 500.00, 75, "Peripherals"); 
            Products product8 = new Products(008, "Microphone", 3000.00, 50, "Audio"); 
            Products product9 = new Products(009, "Printer", 30000.00, 30, "Peripherals"); 
            Products product10 = new Products(010, "Fan Cooler", 2000.00, 90, "Peripherals");
            Products product11 = new Products(011, "Power Bank", 1000.00, 25, "Accessories");
            Products product12 = new Products(012, "Flash Drive", 200.00, 100, "Accessories");
            Products product13 = new Products(013, "Memory Card", 100.00, 100, "Accessories");
            Products product14 = new Products(014, "Camera Lens", 2000.00, 15, "Accessories");
            Products product15 = new Products(015, "Camera", 10000.00, 10, "Gadgets"); 

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
            int receiptNumber = 1;
            string[] historyOfOrder = new string[100];
            int countOfHistoryOrder = 0;
            bool isHere = true;

            while (isHere)
            {
                Console.WriteLine("==========================================================");
                Console.WriteLine("           Welcome to JA Gadgets & Accessories");
                Console.WriteLine("==========================================================");
                Console.WriteLine("1 - | - Products"); 
                Console.WriteLine("2 - | - Carts");
                Console.WriteLine("3 - | - Order History");
                Console.WriteLine("4 - | - Exit");
                Console.WriteLine("==========================================================");
                Console.Write("Select a number ONLY: ");    
                string user = Console.ReadLine();
                int choice;
                Console.WriteLine("----------------------------------------------------------");
                if (!int.TryParse(user, out choice))
                {
                    Console.WriteLine("INVALID! Non-numeric inputs are not acceptable");
                }
                else if (choice > 5 || choice < 1)
                {
                    Console.WriteLine("INVALID! Select from number 1 to 4 ONLY!");
                }

                switch (choice)
                {

                    case 1:
                        bool isCase1 = true;
                        while (isCase1)
                        {
                            Console.WriteLine("==========================================================");
                            Console.WriteLine("                    PRODUCTS                   ");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine("1 - | - View All Products");
                            Console.WriteLine("2 - | - View Products per Category");
                            Console.WriteLine("3 - | - Search Products");
                            Console.WriteLine("4 - | - Add Products to your Cart");
                            Console.WriteLine("5 - | - Exit");
                            Console.WriteLine("----------------------------------------------------------");

                            Console.Write("Select a number ONLY: ");
                            string userProduct = Console.ReadLine();
                            int choiceProduct;
                            Console.WriteLine("----------------------------------------------------------");

                            if (!int.TryParse(userProduct, out choiceProduct))
                            {
                                Console.WriteLine("INVALID! Non-numeric inputs are not acceptable");
                                continue;
                            }
                            else if (choiceProduct > 5 || choiceProduct < 1)
                            {
                                Console.WriteLine("INVALID! Select from number 1 to 5 ONLY!");
                                continue;
                            }

                            switch (choiceProduct)
                            {
                                case 1:
                                    bool isView = true;
                                    while (isView)
                                    {
                                        Console.WriteLine("---------------------  VIEW PRODUCTS  --------------------");
                                        Console.WriteLine($"{"IDs",-7} {"Name",-12} {"Category",-15} {"Price",10}   {"Stocks",8}");
                                        foreach (var product in prods)
                                        {
                                            product.displayProducts();
                                        }
                                        Console.WriteLine("----------------------------------------------------------");
                                        Console.Write("Press Enter to back to the product dashboard: ");
                                        Console.ReadLine();
                                        isView = false;
                                    }
                                    continue;
                                case 2:
                                    Console.WriteLine("--------------------  PRODUCT CATEGORIES  ----------------");
                                    Console.WriteLine("1 - | - Gadgets");
                                    Console.WriteLine("2 - | - Accessories");
                                    Console.WriteLine("3 - | - Audio");
                                    Console.WriteLine("4 - | - Peripherals");
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.Write("Select a product category (1-4): "); 
                                    string userCat = Console.ReadLine();
                                    string userCatChoice= "";

                                    if (int.TryParse(userCat, out int catIndex))
                                    {
                                        if (catIndex == 1)
                                        {
                                            userCatChoice = "Gadgets";
                                        }
                                        else if (catIndex == 2)
                                        {
                                            userCatChoice = "Accessories";
                                        }
                                        else if (catIndex == 3)
                                        {
                                            userCatChoice = "Audio";
                                        }
                                        else if (catIndex == 4)
                                        {
                                            userCatChoice = "Peripherals";
                                        }
                                        else
                                        {
                                            Console.WriteLine("INVALID! Please enter 1-4 only!");
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("INVALID! Non-numeric inputs are not acceptable");
                                        continue;
                                    }

                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.WriteLine($"                        {userCatChoice.ToUpper()}  ");
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.WriteLine($"{"IDs",-7} {"Name",-12} {"Category",-15} {"Price",10}   {"Stocks",8}");
                                    bool foundCat = false;
                                    foreach(var products in prods)
                                    {
                                        if (products.prodCategory == userCatChoice)
                                        {
                                            products.displayProducts();
                                            foundCat = true;
                                        }
                                        
                                    }
                                    if (!foundCat)
                                    {
                                        Console.WriteLine("No products found in this category");
                                    }
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.Write("Press Enter to back to the product dashboard: ");
                                    Console.ReadLine();
                                    continue;

                                case 3:
                                    Console.WriteLine("--------------------  SEARCH PRODUCTS  -------------------");
                                    Console.Write("Enter product name to search: ");
                                    string searchProd = Console.ReadLine().ToLower();
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.WriteLine($"               Search Result for '{searchProd}'");
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.WriteLine($"{"IDs",-7} {"Name",-12} {"Category",-15} {"Price",10}   {"Stocks",8}");

                                    bool foundProd = false;
                                    foreach (var products in prods)
                                    {
                                        if (products.prodNames.ToLower().Contains(searchProd))
                                        {
                                            products.displayProducts();
                                            foundProd = true;
                                        }
                                    }
                                    if (!foundProd)
                                    {
                                        Console.WriteLine("Product doesn't exist!");
                                    }
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.Write("Press Enter to back to the product dashboard: ");
                                    Console.ReadLine();
                                    continue;

                                case 4: 
                                    AddToCart cartExecute = new AddToCart();
                                    cartExecute.cartProcess(prods, cart, ref cartCount);
                                    continue;


                                case 5:
                                    isCase1 = false;
                                    break;


                            }
                            break;
                        }
                        break;
                        

                    case 2:
                        bool isCase2 = true;
                        while (isCase2)
                        {
                            Console.WriteLine("==========================================================");
                            Console.WriteLine("                     CARTS                     ");
                            Console.WriteLine("==========================================================");
                            Console.WriteLine("1 - | - View Cart");
                            Console.WriteLine("2 - | - Remove Item");
                            Console.WriteLine("3 - | - Update Item Quantity");
                            Console.WriteLine("4 - | - Clear Cart");
                            Console.WriteLine("5 - | - Checkout");
                            Console.WriteLine("6 - | - Exit");
                            Console.WriteLine("----------------------------------------------------------");
                            Console.Write("Select a number ONLY: ");
                            string userCart = Console.ReadLine();
                            int choiceCart;
                            Console.WriteLine("----------------------------------------------------------");
                            if (!int.TryParse(userCart, out choiceCart))
                            {
                                Console.WriteLine("INVALID! Non-numeric inputs are not acceptable");
                                continue;
                            }
                            else if (choiceCart > 6 || choiceCart < 1)
                            {
                                Console.WriteLine("INVALID! Select from number 1 to 6 ONLY!");
                                continue;
                            }

                            switch (choiceCart)
                            {
                                case 1:
                                    bool isCheckingCart = true;
                                    while (isCheckingCart)
                                    {
                                        Console.WriteLine("-----------------------  VIEW CART  ----------------------");
                                        if (cartCount == 0)
                                        {
                                            Console.WriteLine("----------------------------------------------------------");
                                            Console.WriteLine("Your cart is empty!");
                                            Console.WriteLine("----------------------------------------------------------");
                                        }
                                        else
                                        {
                                            CartItems.viewCart(cart, cartCount);
                                        }
                                        Console.WriteLine("----------------------------------------------------------");
                                        Console.Write("Press Enter to back to the cart dashboard: ");
                                        Console.ReadLine();
                                        break;
                                    }
                                    break;

                                case 2: 
                                    if (cartCount == 0)
                                    {
                                        Console.WriteLine("Your cart is empty!");
                                        break;
                                    }
                                    CartItems.viewCart(cart, cartCount);
                                    Console.WriteLine("----------------------------------------------------------");
                                    CartItems.removeItem(cart, ref cartCount);
                                    break; 

                                case 3:
                                    if (cartCount == 0)
                                    {
                                        Console.WriteLine("Your cart is empty!");
                                        break;
                                    }
                                    CartItems.viewCart(cart, cartCount);
                                    Console.WriteLine("----------------------------------------------------------");
                                    Console.Write("Enter the Product ID to update: ");
                                    string update = Console.ReadLine();
                                    int updateID;
                                    if (int.TryParse(update, out updateID))
                                    {
                                        bool itemFound = false;
                                        for (int c = 0; c < cartCount; c++)
                                        {
                                            if (cart[c].CartProduct.prodIds == updateID)
                                            {
                                                itemFound = true;
                                                Console.Write($"Enter new quantity for {cart[c].CartProduct.prodNames} (Current: {cart[c].Quantity}): ");
                                                string qty = Console.ReadLine();
                                                int newQty;
                                                if (int.TryParse(qty, out newQty) && newQty >= 0)
                                                {
                                                    if (newQty == 0)
                                                    {
                                                        cart[c].CartProduct.prodStocks += cart[c].Quantity;
                                                        for (int d = c; d < cartCount - 1; d++)
                                                        {
                                                            cart[d] = cart[d + 1];
                                                            
                                                        }
                                                        cart[cartCount - 1] = null;
                                                        cartCount--;
                                                        Console.WriteLine("Item removed from the cart since quantity has set to 0");
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        int difference = newQty - cart[c].Quantity;
                                                        if (difference > 0)
                                                        {
                                                            if (cart[c].CartProduct.enoughStock(difference))
                                                            {
                                                                cart[c].CartProduct.deductStock(difference);
                                                                cart[c].Quantity = newQty;
                                                                Console.WriteLine("Quantity successfully increased");
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine($"The stock of the this product is not enough. Only {cart[c].CartProduct.prodStocks} are available.");
                                                            }
                                                        }
                                                        else if (difference < 0)
                                                        {
                                                            cart[c].CartProduct.prodStocks += Math.Abs(difference);
                                                            cart[c].Quantity = newQty;
                                                            Console.WriteLine("Quantity successfully reduced");
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Quantity unchanged");
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("INVALID! Non-numeric inputs are not acceptable");
                                                    break;
                                                }
                                            }
                                            
                                        }
                                        if (!itemFound)
                                        {
                                            Console.WriteLine("Product ID not found!");
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ID format!");
                                    }
                                    break; 

                                case 4:
                                    if (cartCount == 0)
                                    {
                                        Console.WriteLine("Your cart is empty!");
                                        break;
                                    }
                                    Console.Write("Are you sure you want to completely clear your cart? (Y/N): ");
                                    string confirmClear = Console.ReadLine().ToUpper();

                                    if (confirmClear == "Y")
                                    {
                                        for (int e = 0; e < cartCount; e++)
                                        {
                                            cart[e].CartProduct.prodStocks += cart[e].Quantity;
                                            cart[e] = null;
                                        }
                                        cartCount = 0;
                                        Console.WriteLine("----------------------------------------------------------");
                                        Console.WriteLine("Cart has been completely cleared. All items returned to the inventory stocks.");
                                        Console.WriteLine("----------------------------------------------------------");
                                    }
                                    else if (confirmClear == "N")
                                    {
                                        Console.WriteLine("Clear cart canceled. Your items are safe!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input! Clear cart canceled.");
                                    }
                                    break;

                                case 5:
                                    if (cartCount == 0)
                                    {
                                        Console.WriteLine("Your cart is empty. Please add items to your cart before to proceed in payment");
                                        break;
                                    }

                                    double totalPayment = CartItems.viewCart(cart, cartCount);
                                    
                                    Console.WriteLine("-----------------------  CHECKOUT  -----------------------");
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
                                    Console.WriteLine("==========================================================");
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
                                                Console.WriteLine("-------------------- OFFICIAL RECEIPT  -------------------");
                                                Console.WriteLine("----------------------------------------------------------");
                                                Console.WriteLine($"Receipt No: {receiptNumber.ToString("D4")}");
                                                Console.WriteLine($"Date: {DateTime.Now.ToString("MMMM dd, yyyy h:mm tt")}");
                                                Console.WriteLine("----------------------------------------------------------");
                                                Console.WriteLine($"{"Product Name",-15} | {"Qty",-5} | {"Subtotal"}");
                                                Console.WriteLine("----------------------------------------------------------");
                                                for (int x = 0; x < cartCount; x++)
                                                {
                                                    CartItems item = cart[x];
                                                    string itemName = item.CartProduct.prodNames;
                                                    Console.WriteLine($"{itemName,-15} | {item.Quantity,-5} | {item.GetSubtotal():F2}");
                                                }
                                                Console.WriteLine("----------------------------------------------------------");
                                                Console.WriteLine($"Grant Total: {totalPayment}");
                                                if (discountAmount > 0)
                                                {
                                                    Console.WriteLine($"Discount 10%: {discountAmount:F2}");
                                                }
                                                Console.WriteLine($"Final Total: {finalTotal:F2}");
                                                Console.WriteLine($"Cash Paid: {cashPayment:F2}");
                                                Console.WriteLine($"Change: {change:F2}");
                                                Console.WriteLine("==========================================================");
                                                Console.WriteLine("Thank you for Shopping in JA Gadgets & Accessories");
                                                Console.WriteLine("==========================================================");

                                                if (countOfHistoryOrder < historyOfOrder.Length)
                                                {
                                                    
                                                    historyOfOrder[countOfHistoryOrder] = $"Receipt #{receiptNumber.ToString("D4")} ---------- Final Total: PHP {finalTotal:F2}";
                                                    countOfHistoryOrder++;
                                                }

                                                receiptNumber++;

                                                Console.WriteLine("LOW STOCK ALERT: ");
                                                foreach (var product in prods)
                                                {
                                                    if (product.prodStocks <= 5)
                                                    {
                                                        Console.WriteLine($"{product.prodNames} has only {product.prodStocks} stock/s only");                                                                                                                                                                                                                              
                                                    }
                                                }

                                                Console.Write("Press anything to back to the main dashboard: ");
                                                Console.ReadLine();
                                                cartCount = 0;
                                                isPaid = true;
                                                isCase2 = false;
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

                                case 6:
                                    isCase2 = false;
                                    break; 
                            }
                            
                        }
                        break;
                        

                    case 3:
                        Console.WriteLine("==========================================================");
                        Console.WriteLine("                ORDER HISTORY                  ");
                        Console.WriteLine("==========================================================");

                        if (countOfHistoryOrder == 0)
                        {
                            Console.WriteLine("No completed transactions yet.");
                        }
                        else
                        {

                            for (int i = 0; i < countOfHistoryOrder; i++)
                            {
                                Console.WriteLine(historyOfOrder[i]);
                            }
                        }

                        Console.WriteLine("==========================================================");
                        Console.Write("Press Enter to return to the main menu: ");
                        Console.ReadLine();
                        break;

                    case 4:
                        Console.WriteLine("Thanks for visiting!");
                        isHere = false;
                        break;                              
                }
            }
        }
    }
}       