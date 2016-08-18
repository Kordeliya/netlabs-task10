using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class SQLCeConnection : DBConnection
    {
        public SQLCeConnection(SqlCeConnection conection)
        {
            Connection = conection;
        }

        public override void ExecuteCommand(string command)
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
            SqlCeCommand sqlCommand = new SqlCeCommand(command, (SqlCeConnection)Connection);
            try
            {
                var result = sqlCommand.ExecuteNonQuery();
                if (result == -1)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
            finally
            {
                Connection.Close();
            }
        }



        public override DataSet ExecuteCommand(string command, string nameTable)
        {
            DataSet result = new DataSet();
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
            SqlCeDataAdapter adapter = new SqlCeDataAdapter(command, (SqlCeConnection)Connection);
            try
            {
                adapter.Fill(result, nameTable);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}
