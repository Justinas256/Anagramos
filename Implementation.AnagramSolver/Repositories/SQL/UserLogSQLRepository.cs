using Implementation.AnagramSolver.Model;
using Interfaces.AnagramSolver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{
    public class UserLogSQLRepository : IUserLogRepository
    {
        String _connectionString;

        public UserLogSQLRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public UserLogSQLRepository()
        {
            _connectionString = @"Data Source=LT-LIT-SC-0428;Initial Catalog=Anagrams;Integrated Security=sspi;";
        }

        public void AddUserLog(UserLogFull userLog)
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

        public List<UserLogFull> GetUserLogs()
        {
            var userLogs = new List<UserLogFull>();
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
                        userLogs.Add(new UserLogFull(ip, time, cachedWordID));
                    }
                }
            }
            return userLogs;
        }

        public int CountActionsByIP(string ip_address, string action)
        {
            //throw new NotImplementedException();
            return 0;
        }
    }
}
