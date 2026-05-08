using System;
using System.Collections.Generic;
using System.Text;

namespace JAShoppingCartSystem
{
    class Products
    {
        public int prodIds;
        public string prodNames;
        public double prodPrices;
        public int prodStocks;
        public string prodCategory;
        public Products (int productIds, String productNames, double productPrices, int productStocks, string prodCategory)
        {
            this.prodIds = productIds;
            this.prodNames = productNames;
            this.prodPrices = productPrices;
            this.prodStocks = productStocks;
            this.prodCategory = prodCategory;
        }
        public void displayProducts()
        {
            Console.WriteLine($"{prodIds,-7} {prodNames,-12} {prodCategory,-15} {prodPrices,10:F2}   {prodStocks,8}");
        }
        public double getCartTotal(int quantity)
        {
            return prodPrices * quantity;
        }
        public bool enoughStock(int quantity)
        {
            return ( prodStocks >= quantity );
        }
        public void deductStock(int quantity)
        {
            prodStocks -= quantity;
        }
    }
}
