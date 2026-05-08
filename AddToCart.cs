using System;
using System.Collections.Generic;
using System.Text;

namespace JAShoppingCartSystem
{
    class AddToCart 
    {
        public void cartProcess (Products[] prods, CartItems[] cart, ref int cartCount) 
        {
            bool orderMore = true;
            while (orderMore)
            {
                Console.WriteLine("----------------  ADD TO CART  ----------------");
                Console.WriteLine($"{"IDs",-7} {"Name",-12} {"Category",-15} {"Price",10}   {"Stocks",8}");
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
            
        }
    }
}
