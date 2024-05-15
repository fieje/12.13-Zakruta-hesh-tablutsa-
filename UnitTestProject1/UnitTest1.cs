using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class ClosedHashTableTests
    {
        [TestMethod]
        public void Insert_Search_Success()
        {
            ClosedHashTable hashTable = new ClosedHashTable();
            Price price1 = new Price("Product1", "Shop1", 10.0);
            Price price2 = new Price("Product2", "Shop2", 20.0);
            Price price3 = new Price("Product3", "Shop3", 30.0);

            hashTable.Insert(price1.ProductName, price1);
            hashTable.Insert(price2.ProductName, price2);
            hashTable.Insert(price3.ProductName, price3);

            Assert.AreEqual(price1, hashTable.Search("Product1"));
            Assert.AreEqual(price2, hashTable.Search("Product2"));
            Assert.AreEqual(price3, hashTable.Search("Product3"));
        }

        [TestMethod]
        public void Search_NotFound_ReturnsNull()
        {
            ClosedHashTable hashTable = new ClosedHashTable();
            Price price1 = new Price("Product1", "Shop1", 10.0);

            hashTable.Insert(price1.ProductName, price1);

            Assert.IsNull(hashTable.Search("NonExistentProduct"));
        }

        [TestMethod]
        public void Insert_Collision_Success()
        {
            ClosedHashTable hashTable = new ClosedHashTable();
            Price price1 = new Price("Product1", "Shop1", 10.0);
            Price price2 = new Price("Product2", "Shop2", 20.0);

            hashTable.Insert(price1.ProductName, price1);
            hashTable.Insert(price2.ProductName, price2); 

            Assert.AreEqual(price1, hashTable.Search("Product1"));
            Assert.AreEqual(price2, hashTable.Search("Product2"));
        }
    }
}
