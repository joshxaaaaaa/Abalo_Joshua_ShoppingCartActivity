using System;
using System.Collections.Generic;
using System.Text;

namespace JAShoppingCartSystem
{
    class CartItems
    {
        public Products CartProduct;
        public int Quantity; 
        public double GetSubtotal()
        {
            return CartProduct.getCartTotal(Quantity);
        }
        public static double viewCart (CartItems [] cart, int cartCount)
        {
            Console.WriteLine($"{"ID", -5} | {"Product Name",-15} | {"Qty",-5} | {"Price",-10} | {"Subtotal"}");
            Console.WriteLine("----------------------------------------------------------");
            double grandTotal = 0;
            for (int x = 0; x < cartCount; x++)
            {
                CartItems currentItem = cart[x];
                int id = currentItem.CartProduct.prodIds;
                string name = currentItem.CartProduct.prodNames;
                int qty = currentItem.Quantity;
                double price = currentItem.CartProduct.prodPrices;
                double subTotal = currentItem.GetSubtotal();
                grandTotal += subTotal;
                Console.WriteLine($"{id,-5} | {name,-15} | {qty,-5} | {price,-9:F2} | {subTotal:F2}");
            }
            Console.WriteLine("==========================================================");
            Console.WriteLine($"GRAND TOTAL:                                  {grandTotal:F2}");

            return grandTotal;
        }

        public static void removeItem (CartItems[] cart, ref int cartCount)
        {
            Console.Write("Enter the Product ID to remove: ");
            string remove = Console.ReadLine();
            int removeID;
            if (int.TryParse(remove, out removeID))
            {
                bool foundItem = false;
                for (int a = 0; a < cartCount; a++)
                {
                    if (cart[a].CartProduct.prodIds == removeID)
                    {
                        foundItem = true;
                        cart[a].CartProduct.prodStocks += cart[a].Quantity;
                        Console.WriteLine($"You successfully removed {cart[a].CartProduct.prodNames} to your cart");

                        for (int b = a; b < cartCount - 1; b++)
                        {
                            cart[b] = cart[b + 1];
                        }
                        cart[cartCount - 1] = null;
                        cartCount--;
                        break;
                    }
                }
                if (!foundItem)
                {
                    Console.WriteLine("Product ID not found in your CART!");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format");
            }
        }
    }
}
