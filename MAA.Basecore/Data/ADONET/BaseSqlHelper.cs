using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAA.Basecore.Data.ADONET
{
    public interface ISqlHelper : IDisposable
    {
        int ExecuteCommand(string cmdText, List<SqlParameter> parameters = null, CommandType type = CommandType.Text);

        SqlDataReader GetData(string cmdText, List<SqlParameter> parameters = null);

        DataTable GetTable(string cmdText, List<SqlParameter> parameters = null, CommandType type = CommandType.Text);
    }

    public class BaseSqlHelper : ISqlHelper
    {
        internal string ConnectionString { get; set; }
        public BaseSqlHelper(string constrName)
        {
            ConnectionString = ConfigurationManager.ConnectionStrings[constrName].ConnectionString;
        }

        public int ExecuteCommand(string commandText, List<SqlParameter> parameters = null, CommandType type = CommandType.Text)
        {
            int result = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(commandText, con))
                    {
                        cmd.CommandType = type;
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters.ToArray());
                        }
                        con.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                }


            }
            catch (SqlException ex)
            {
                //Email gönderirsiniz. Subject : Sql Exception
                //Text yazdir
                throw ex;
            }
            catch (Exception ex)
            {
                //Email - Subject : genel exception
                throw ex;
                //Database kaydet.
            }
            return result;
        }

        public SqlDataReader GetData(string cmdText, List<SqlParameter> parameters = null)
        {
            SqlDataReader rd = null;
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                SqlCommand cmd = new SqlCommand(cmdText, con);

                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters.ToArray());
                }
                con.Open();
                rd = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
            return rd;
        }

        private bool Disposed { get; set; }

        private void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                }
                Disposed = true;
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        public DataTable GetTable(string cmdText, List<SqlParameter> parameters = null, CommandType type = CommandType.Text)
        {
            DataTable table = null;
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmdText, ConnectionString);
                table = new DataTable();
                if (parameters != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(parameters.ToArray());
                }
                adapter.SelectCommand.CommandType = type;
                adapter.Fill(table);
                
            }
            catch (SqlException ex)
            {
                //throw ex;
            }
            catch (Exception)
            {
                throw;
            }
            return table;
        }
    }
}
