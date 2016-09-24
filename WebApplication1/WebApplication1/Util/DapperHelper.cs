using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using WebApplication1.Interface;

namespace WebApplication1.Util
{
    public class DapperHelper : IDapper
    {
        public IEnumerable<T> Query<T>(string connection, string sql, object parameter = null)
        {
            IEnumerable<T> response;
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(connection);
                sqlConnection.Open();

                response = sqlConnection.Query<T>(sql, parameter);

                sqlConnection.Close();
            }
            finally
            {
                sqlConnection?.Dispose();
            }

            return response;
        }

    }
}
