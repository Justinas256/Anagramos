using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class Database
    {
        String _connectionString = "Data Source=LT-LIT-SC-0428;Initial Catalog=Anagrams;Integrated Security=sspi;";

        public void AddWordsToDatabase(List<string> words)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (string word in words)
                {
                    string sql = "INSERT INTO dbo.Words (Word) VALUES(@Word)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add(new SqlParameter("@Word", word));
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
