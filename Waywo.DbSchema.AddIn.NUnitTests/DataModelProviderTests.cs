using System;
using Waywo.DbSchema.Providers;

namespace Waywo.DbSchema.AddIn.Tests
{
    public class DataModelProviderTests
    {
        [TestCase]
        public void AddOutwardTables_SingleTable_Success()
        {
            //Arrange
            var dataModelProvider = DataModelProviderFactory.Create();
            dataModelProvider.Tables.Add("CustTable");

            //Act
            dataModelProvider.AddOutwardTables("CustTable");

            //Assert
            Assert.That(dataModelProvider.Tables.Count, Is.EqualTo(69));
        }
    }
}
