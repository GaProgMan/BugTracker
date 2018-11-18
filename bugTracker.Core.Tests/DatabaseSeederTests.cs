using System.Collections.Generic;
using bugTracker.Core.Tests.Helpers;
using Moq;
using Xunit;
using System.IO;
using System;
using bugTracker.Core.Entities;
using bugTracker.Core.Persistence;
using bugTracker.Core.Persistence.Helpers;

namespace bugTracker.Core.Tests
{
    public class DatabaseSeederTests
    {
        [Fact]
        public async void DbSeeder_SeedBookData_NoDataSupplied_ShouldThrowException()
        {
            // Arrange
            var bookList = new List<Bug>();
            var mockBookSet = DbSetHelpers.GetQueryableDbSet(bookList);
            var mockset = new Mock<IBugContext>();
            mockset.Setup(m => m.Bugs).Returns(mockBookSet.Object);

            // Act & Assert
            var dbSeeder = new DatabaseSeeder(mockset.Object);
            var argEx = await Assert.ThrowsAsync<ArgumentException>(() =>
                dbSeeder.SeedBugEntitiesFromJson(string.Empty));
        }

        [Fact]
        public void DbSeeder_SeedBookData_DataSupplied_ShouldNotThrowException()
        {
            // Arrange
            // TODO Add an interface here, to mock stuff properly
            var bookList = new List<Bug>();
            var mockBookSet = DbSetHelpers.GetQueryableDbSet(bookList);
            var mockset = new Mock<IBugContext>();
            mockset.Setup(m => m.Bugs).Returns(mockBookSet.Object);
            var testJsonDirectory = Path.Combine(Directory.GetCurrentDirectory(), "SeedData");
            var pathToSeedData = Path.Combine(testJsonDirectory, "TestBookSeedData.json");
            
            // Act & Assert
            var dbSeeder = new DatabaseSeeder(mockset.Object);
            
            dbSeeder.SeedBugEntitiesFromJson(pathToSeedData).Wait();
        }
    }
}