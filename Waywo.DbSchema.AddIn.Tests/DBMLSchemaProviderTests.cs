using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Waywo.DbSchema.Providers;

namespace Waywo.DbSchema.AddIn.Tests
{
    [TestClass]
    public class DBMLSchemaProviderTests
    {
        [TestMethod]
        public void GetSchema_SingleTable_Success()
        {
            //Arrange
            string expected = "// Use a tool like https://dbdiagram.io/ to render this DBML\r\n// https://waywo.co.uk/2021/12/20/entity-relationship-diagrams/\r\n\r\nTable CustTable {\r\n  AccountNum String [pk]\r\n  FactoringAccount String \r\n  InvoiceAccount String \r\n\r\n  Note: '''\r\n\r\n  The CustTable table contains a list of customers for the accounts receivable and customer relationship management.\r\n\r\n  Clustered    : AccountNum\r\n  Group        : Main\r\n  Cache        : Found\r\n  '''\r\n}\r\n\r\nRef: CustTable.FactoringAccount > CustTable.AccountNum\r\nRef: CustTable.InvoiceAccount > CustTable.AccountNum\r\n\r\n";
            var dataModelProvider = DataModelProviderFactory.Create();
            dataModelProvider.Tables.Add("CustTable");
            dataModelProvider.SimplifyTypes = true;

            var schemaProvider = new DBMLSchemaProvider(dataModelProvider);
            schemaProvider.JustKeys = true;

            //Act
            string dbml = schemaProvider.GetSchema();

            //Assert
            Assert.AreEqual(dbml, expected);
        }
    }
}
