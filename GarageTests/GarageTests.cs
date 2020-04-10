using Microsoft.VisualStudio.TestTools.UnitTesting;
using Exercise5Garage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise5Garage.Tests
{
    [TestClass()]
    public class GarageTests
    {
        [TestMethod()]
        public void NewInstanceOfGarageCreatedWithNameAndCapacity()
        {
            // Arrange
            var expectedName = "Kalles";
            uint expectedCapacity = 12;
            var garage = new Garage<Vehicle>(expectedName, expectedCapacity);

            //Act
            var actualName = garage.Name;
            var actualCapacity = garage.MaxCapacity;

            //Assert
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
    }
}