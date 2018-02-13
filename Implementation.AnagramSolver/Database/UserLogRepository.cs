using Implementation.AnagramSolver.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public class UserLogRepository
    {
        String _connectionString;

        public UserLogRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public UserLogRepository()
        {
            _connectionString = @"Data Source=LT-LIT-SC-0428;Initial Catalog=Anagrams;Integrated Security=sspi;";
        }

        public void AddUserLog(UserLog userLog)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                if (userLog != null)
                {
                    string sql = "INSERT INTO UserLogs (IP_address, CachedWordID, SearchTime) " +
                            "VALUES(@IP_address,@CachedWordID, @SearchTime)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add(new SqlParameter("@IP_address", userLog.IP_address));
                    cmd.Parameters.Add(new SqlParameter("@CachedWordID", userLog.CachedWordID));
                    cmd.Parameters.Add(new SqlParameter("@SearchTime", userLog.Time));
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UserLog> GetUserLogs()
        {
            var userLogs = new List<UserLog>();
            string ip;
            DateTime time;
            int cachedWordID;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM UserLogs";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        ip = dr["IP_address"].ToString();
                        time = DateTime.Parse((dr["SearchTime"].ToString()));
                        cachedWordID = Int32.Parse(dr["CachedWordID"].ToString());
                        userLogs.Add(new UserLog(ip, time, cachedWordID));
                    }
                }
            }
            return userLogs;
        }

    }
}
