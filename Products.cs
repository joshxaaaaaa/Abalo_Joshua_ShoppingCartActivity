using System;
using System.Collections.Generic;
using System.Text;

namespace JAShoppingCartSystem
{
    class Products
    {
        private int prodIds;
        private string prodNames;
        private double prodPrices;
        private int prodStocks;
        private string prodCategory;

        public Products(int productIds, string productNames, double productPrices, int productStocks, string prodCategory)
        {
            this.prodIds = productIds;
            this.prodNames = productNames;
            this.prodPrices = productPrices;
            this.prodStocks = productStocks;
            this.prodCategory = prodCategory;
        }

        public void SetProdIds(int id) 
        { 
            this.prodIds = id; 
        }
        public int GetProdIds() 
        { 
            return this.prodIds; 
        }

        public void SetProdNames(string name) 
        { 
            this.prodNames = name; 
        }
        public string GetProdNames() 
        { 
            return this.prodNames; 
        }

        public void SetProdPrices(double price) 
        { 
            this.prodPrices = price; 
        }
        public double GetProdPrices() 
        { 
            return this.prodPrices; 
        }

        public void SetProdCategory(string category)
        {
            this.prodCategory = category;
        }
        public string GetProdCategory()
        {
            return this.prodCategory;
        }

        public void SetProdStocks(int stocks)
        {
            if (stocks < 0)
            {
                this.prodStocks = 0;
            }
            else
            {
                this.prodStocks = stocks;
            }
        }
        public int GetProdStocks() 
        { 
            return this.prodStocks; 
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
        public void addStock(int quantity) 
        { 
            this.prodStocks += quantity; 
        }
    }
}
