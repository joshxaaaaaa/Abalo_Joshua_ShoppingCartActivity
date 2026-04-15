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
    }
}
