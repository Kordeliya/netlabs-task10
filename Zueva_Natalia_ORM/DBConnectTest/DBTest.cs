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
            var reader = factory.DbConnection.ExecuteCommand("SELECT * FROM BOOK  WHERE ID = 3;");
            while (reader.Read())
            {
                Assert.IsNotNull(reader.GetInt32(0));
                Assert.IsNotNull(reader.GetString(1));
                Assert.IsNotNull(reader.GetString(2));
            }
            reader.Close();
        }
    }
}
