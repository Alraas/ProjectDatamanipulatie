using AutoVerhuurKantoor_DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace AutoVerhuurKantoor_UnitTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void ID_ValueGroterDanNull_NummerIsGelijkAanValue()
        {
            Customer klant = new Customer();
            klant.customer_id = 5;
            Assert.AreEqual(5, klant.customer_id);
        }

        [TestMethod]
        public void lname_ValueISValue_lnameIsGelijkAanValue()
        {
            Customer klant = new Customer();
            klant.lname = "KlantTest";
            Assert.AreEqual("KlantTest", klant.lname);
        }

        [TestMethod]
        public void fname_ValueISValue_fnameIsGelijkAanValue()
        {
            Customer klant = new Customer();
            klant.fname = "KlantTest";
            Assert.AreEqual("KlantTest", klant.fname);
        }

        [TestMethod]
        public void email_ValueISValue_emailIsGelijkAanValue()
        {
            Customer klant = new Customer();
            klant.email = "email@test.com";
            Assert.AreEqual("email@test.com", klant.email);
        }

        [TestMethod]
        public void Prijs_ValueGroterDanNull_PrijsIsGelijkAanValue()
        {
            Agency_Car kantoor_auto = new Agency_Car();
            kantoor_auto.pricePerNight = 20;
            Assert.AreEqual(20, kantoor_auto.pricePerNight);
        }
        [TestMethod]
        public void datum_ValueIsDatumVandaag_DatumIsGelijkAanValue()
        {
            Rental kantoor_auto = new Rental();
            kantoor_auto.startDdate = DateTime.Today;
            Assert.AreEqual(DateTime.Today, kantoor_auto.startDdate);
        }



    }
}
