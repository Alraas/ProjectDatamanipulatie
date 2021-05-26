using AutoVerhuurKantoor_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace AutoVerhuurKantoor_UnitTests
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void ID_ValueGroterDanNull_NummerIsGelijkAanValue()
        {
            Customer klant = new Customer();
            klant.customer_id = 5;
            Assert.AreEqual(5, klant.customer_id);
        }
    }
}
