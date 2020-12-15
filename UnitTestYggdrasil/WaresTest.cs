//using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Yggdrasil.Interfaces;
//using Yggdrasil.Models;
//using Yggdrasil.Services;

//namespace UnitTestYggdrasil
//{
//    [TestClass]
//    public class WaresTest
//    {
//        [TestMethod]
//        public void AddWareTest()
//        {
//            IWareCatalog repo = new JsonWareRepository();
//            int expectedNo = repo.AllWares().Count + 1;
//            Ware w = new Ware();
            
//            repo.AddWare(w);
//            int number = repo.AllWares().Count;

//            Assert.AreEqual(expectedNo, number);
//        }

//        [TestMethod]
//        public void CheckIdIsCorrectForNewWareTest()
//        {
//            IWareCatalog repo = new JsonWareRepository();
//            Ware w = new Ware();
//            Ware w2 = new Ware();
            
//            repo.AddWare(w);
//            repo.AddWare(w2);

//            Assert.AreEqual(w.Id, w2.Id - 1);
//        }
//    }
//}
