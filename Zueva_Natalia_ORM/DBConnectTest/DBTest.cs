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
            var reader = factory.DbConnection.ExecuteCommand("CREATE TABLE TEST (PersonID int,LastName nvarchar(255));");
        }
    }
}
