using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waywo.DbSchema.Providers;

namespace Waywo.DbSchema.AddIn.Tests
{
    [TestClass]
    public class DataModelProviderTests
    {
        [TestMethod]
        public void AddOutwardTables_SingleTable_Success()
        {
            //Arrange
            var dataModelProvider = DataModelProviderFactory.Create();
            dataModelProvider.Tables.Add("CustTable");

            //Act
            dataModelProvider.AddOutwardTables("CustTable");

            //Assert
            Assert.AreEqual(69, dataModelProvider.Tables.Count);
        }
    }
}
