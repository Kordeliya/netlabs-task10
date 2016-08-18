using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class SQLConnection : DBConnection
    {
        public SQLConnection(SqlConnection conection)
        {
            Connection = conection;
        }

        public override void ExecuteCommand(string command)
        {
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
            SqlCommand sqlCommand = new SqlCommand(command, (SqlConnection)Connection);
            try
            {
                var result = sqlCommand.ExecuteNonQuery();
                if(result == -1)
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
            DataSet result = null;
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
            SqlDataAdapter adapter = new SqlDataAdapter(command, (SqlConnection)Connection);
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
