using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercices
{
    public class Stock
    {
        private readonly Dictionary<string, Product> _inventory;
        private readonly Action<Product, int> _alertProductStock;
        public Stock(Action<Product,int> alertProductStock)
        {
            _alertProductStock = alertProductStock;
            _inventory = new Dictionary<string, Product>();
        }

        public void AddProduct(Product prod)
        {
            if (prod == null)
            {
                throw new ArgumentNullException();
            }

            if (!_inventory.ContainsKey(prod.Name))
            {
                _inventory.Add(prod.Name, prod);
            }
            else
            {
                _inventory[prod.Name].Quantity += prod.Quantity;
            }
        }

        public void RemoveProduct(Product prod)
        {
            _inventory.Remove(prod.Name);
        }

        public void SellProduct(Product prod, int quantity)
        {
            ValidateProduct(prod);
            ValidateProductQuantity(prod, quantity);
            var threshold = prod.Quantity - quantity;
            if (prod.Quantity >= 10 && threshold >= 5 && threshold < 10)
            {
                _alertProductStock(prod, threshold);
            }
            else if (prod.Quantity >= 5 && threshold >= 2 && threshold < 5)
            {
                _alertProductStock(prod, threshold);
            }
            else if (prod.Quantity >= 2 && threshold >= 0 && threshold < 2)
            {
                _alertProductStock(prod, threshold);
            }

            _inventory[prod.Name].Quantity = threshold;
        }

        private void ValidateProductQuantity(Product prod, int quantity)
        {
            if (quantity < 1)
            {
                throw new ArgumentOutOfRangeException("quantity must be at least 1");
            }


            if (quantity > _inventory[prod.Name].Quantity)
            {
                throw new ArgumentException($"{prod.Name} stock is insufficient ({_inventory[prod.Name].Quantity} pcs available)");
            }
        }

        private void ValidateProduct(Product prod)
        {
            if (!_inventory.ContainsKey(prod.Name))
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
