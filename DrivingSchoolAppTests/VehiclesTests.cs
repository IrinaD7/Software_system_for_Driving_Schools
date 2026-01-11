using System;
using NUnit.Framework;
using DrivingSchoolApp.Models;

namespace Tests
{
    [TestFixture]
    public class VehiclesTests
    {
        [Test]
        public void canAddVehicle()
        {
            using var context = TestHelpers.TestDbContextFactory.Create();

            var vehicle = new Vehicle
            {
                Model = "Toyota Corolla",
                VIN = "0123456789",
                Color = "Белый",
                ManufactureYear = 2015
            };

            context.Vehicles.Add(vehicle);
            context.SaveChanges();

            Assert.AreEqual(1, context.Vehicles.Count());
        }

        [Test]
        public void canEditVehicle()
        {
            using var context = TestHelpers.TestDbContextFactory.Create();

            var vehicle = new Vehicle
            {
                Model = "Ford",
                VIN = "0123456789",
                Color = "Тёмно-синий",
                ManufactureYear = 2008
            };

            context.Vehicles.Add(vehicle);
            context.SaveChanges();

            vehicle.Model = "Ford Focus";
            context.SaveChanges();

            var updatedVehicle = context.Vehicles.First();

            Assert.AreEqual("Ford Focus", updatedVehicle.Model);
        }

        [Test]
        public void canDeleteVehicle()
        {
            using var context = TestHelpers.TestDbContextFactory.Create();

            var vehicle = new Vehicle
            {
                Model = "Mazda",
                VIN = "0123456789",
                Color = "Красный",
                ManufactureYear = 2018
            };

            context.Vehicles.Add(vehicle);
            context.SaveChanges();

            context.Vehicles.Remove(vehicle);
            context.SaveChanges();

            Assert.AreEqual(0, context.Vehicles.Count());
        }
    }
}
