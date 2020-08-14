using System;
using System.Collections.Generic;
using System.Text;
using  Xunit;

namespace LinqExercices.Tests
{
    public class StockTests
    { 
        Product apple = new Product() {Name = "apple", Quantity = 21};
        Product pear = new Product(){Name = "pear",Quantity = 7};
        Stock fruitStock = new Stock(Allert);

        [Fact]
        public void ThrowsAllertOnlyOnceForEachThreshold()
        {
            fruitStock.AddProduct(apple);
            fruitStock.AddProduct(pear);
            Assert.Throws<ArgumentOutOfRangeException>(() => fruitStock.SellProduct(apple, 12)); 
            Assert.Throws<ArgumentOutOfRangeException>(() => fruitStock.SellProduct(pear, 3));
        }
        private static void Allert(Product prod, int quantity)
        {
            throw new ArgumentOutOfRangeException($"{prod.Name} has only {quantity} left! ");
        }
    }
}
