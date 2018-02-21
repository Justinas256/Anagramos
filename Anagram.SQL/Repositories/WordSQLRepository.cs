using Anagram.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram.SQL
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

        public int FindWordID(string word)
        {
            int wordID = 0;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Words Where Word = @Word";
                cmd.Parameters.Add(new SqlParameter("@Word", word));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        wordID = Int32.Parse(dr["ID"].ToString());
                    }
                }
            }
            return wordID;
        }

        public string FindWordByID(int wordID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Words Where ID = @WordID";
                cmd.Parameters.Add(new SqlParameter("@WordID", wordID));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        return dr["Word"].ToString();
                    }
                }
            }
            return null;
        }

        public void AddNewWord(string word)
        {
            throw new NotImplementedException();
        }

        public void DeleteWord(int wordID)
        {
            throw new NotImplementedException();
        }

        public void UpdateWord(int wordID, string newWord)
        {
            throw new NotImplementedException();
        }
    }
}
