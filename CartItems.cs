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

            return grandTotal;
        }
    }
}
