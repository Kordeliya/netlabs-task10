using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBConnect;

namespace DBConnectTest
{
    [TestClass]
    public class DBTest
    {
        [TestMethod]
        public void CreateConnection()
        {
            ConnectionFactory factory = new SQLCeConnectionFactory(@"Data Source=|DataDirectory|\ForTEST.sdf; Persist Security Info=False;");
            var dataset = factory.DbConnection.ExecuteCommand("SELECT * FROM BOOK  WHERE ID = 3;", "Book");
            Assert.IsNotNull(dataset);
        }
    }
}
