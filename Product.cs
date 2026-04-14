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
        public Products (int prodIds, String prodNames, double prodPrices, int proStocks)
        {
            this.prodIds = prodIds;
            this.prodNames = prodNames;
            this.prodPrices = prodPrices;
            this.prodStocks = proStocks;
        }
        public void displayProducts()
        {
            Console.WriteLine($"{prodIds,-7} {prodNames,-12} {prodPrices,10:F2}   {prodStocks,8}");
        }
    }
}
