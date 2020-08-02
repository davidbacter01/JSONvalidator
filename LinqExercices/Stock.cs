using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercices
{
    public class Stock
    {
        private readonly Dictionary<string, Product> inventory;
        private Action<Product, int> alertProductStock;
        public Stock(Action<Product,int> alertProductStock)
        {
            this.alertProductStock = alertProductStock;
            inventory = new Dictionary<string, Product>();
        }

        public void AddProduct(Product prod)
        {
            if (prod == null)
            {
                throw new ArgumentNullException();
            }

            if (!inventory.ContainsKey(prod.Name))
            {
                inventory.Add(prod.Name, prod);
            }
            else
            {
                inventory[prod.Name].Quantity += prod.Quantity;
            }
        }

        public void RemoveProduct(Product prod)
        {
            inventory.Remove(prod.Name);
        }

        public void SellProduct(Product prod, int quantity)
        {
            ValidateProduct(prod);
            ValidateProductQuantity(prod, quantity);
            inventory[prod.Name].Quantity -= quantity;
            if (inventory[prod.Name].Quantity < 10)
            {
                alertProductStock(prod, inventory[prod.Name].Quantity);
            }
        }

        private void ValidateProductQuantity(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentOutOfRangeException("quantity must be at least 1");
            }


            if (quantity > inventory[prod.Name].Quantity)
            {
                throw new ArgumentException($"{prod.Name} stock is insufficient ({inventory[prod.Name].Quantity} pcs available)");
            }
        }

        private void ValidateProduct(Product prod)
        {
            if (!inventory.ContainsKey(prod.Name))
            {
                throw new ArgumentException("Product doesn't exist");
            }

            if (prod == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
