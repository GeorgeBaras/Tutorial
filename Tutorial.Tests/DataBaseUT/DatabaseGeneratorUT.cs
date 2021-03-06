﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tutorial.My_EntityClasses;
using Tutorial.MyClasses;
using System.Collections.Generic;

namespace Tutorial.Tests.DataBaseUT
{
    [TestClass]
    public class DatabaseGeneratorUT
    {
        [TestMethod]
        public void TestGenerateVehicles()
        {
            List<Vehicle> vehicles = My_EntityClasses.ModelWorld.generateVehicles(1000);
            Assert.AreEqual(1000, vehicles.Count, "Vehicles were not created successfully");
        }


        [TestMethod]
        public void TestGeneratePriceBands()
        {
            List<PriceBand> priceBands = My_EntityClasses.ModelWorld.generatePriceBands(100);
            Assert.AreEqual(100, priceBands.Count, "PriceBands were not created successfully");
        }

        [TestMethod]
        public void TestGeneratePriceRecords()
        {
            List<PriceRecord> priceRecords = My_EntityClasses.ModelWorld.generatePriceRecords(1000,10);
            Assert.AreEqual(1000, priceRecords.Count, "PriceRecords were not created successfully");
        }
    }
}
