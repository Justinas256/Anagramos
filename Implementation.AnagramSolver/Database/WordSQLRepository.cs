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
    
    public class WordSQLRepository : IWordRepository
    {
        String _connectionString;

        public WordSQLRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public List<string> GetData()
        {
            var words = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Words";
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        words.Add(dr["Word"].ToString());
                    }
                }
            }
            return words;
        }

        public List<string> GetFilteredWords(string fragment)
        {
            var words = new List<string>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Words Where Word LIKE @fragment + '%'";
                cmd.Parameters.Add(new SqlParameter("fragment", fragment));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        words.Add(dr["Word"].ToString());
                    }
                }
            }
            return words;
        }

    }
}
