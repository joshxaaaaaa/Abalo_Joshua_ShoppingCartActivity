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

                    case 5:
                        Console.WriteLine("Thanks for visiting!");
                        isHere = false;
                        break;
                        
                }
            }
        }
    }
}       