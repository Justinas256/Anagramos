using Anagram.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.SQL
{
    public class CachedWordsSQLRepository : ICachedWordsRepository
    {
        String _connectionString;

        public CachedWordsSQLRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public CachedWordsSQLRepository()
        {
            _connectionString = AppConfig.ConnectionString;
        }

        public int? GetCachedWordID(string word)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CachedWords Where CachedWord = @Word";
                cmd.Parameters.Add(new SqlParameter("@Word", word));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        return Int32.Parse(dr["CachedWordID"].ToString());
                    }
                }
            }
            return null;
        }

        public string GetCachedWordByID(int cachedWordID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CachedWords Where CachedWordID = @cachedWordID";
                cmd.Parameters.Add(new SqlParameter("@cachedWordID", cachedWordID));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        return dr["CachedWord"].ToString();
                    }
                }
            }
            return null;
        }

        public void InsertIntoCashedAnagrams(int cachedWordID, List<int> anagramsID)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                if(anagramsID != null && anagramsID.Any())
                {
                    foreach (int anagramID in anagramsID)
                    {
                        string sql = "INSERT INTO CachedAnagrams (CachedWordID, AnagramID) VALUES(@cachedWordID,@anagramID)";
                        SqlCommand cmd = new SqlCommand(sql, connection);
                        cmd = new SqlCommand(sql, connection);
                        cmd.Parameters.Add(new SqlParameter("@cachedWordID", cachedWordID));
                        cmd.Parameters.Add(new SqlParameter("@anagramID", anagramID));
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        public void InsertIntoCashedWords(string word)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO CachedWords (CachedWord) VALUES(@cachedWord)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.Add(new SqlParameter("@cachedWord", word));
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();              
            }
        }

        public List<int> GetCachedAnagrams(int cachedWordID)
        {
            var anagramsID = new List<int>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CachedAnagrams Where CachedWordID = @CachedWordID";
                cmd.Parameters.Add(new SqlParameter("@CachedWordID", cachedWordID));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        anagramsID.Add(Int32.Parse(dr["AnagramID"].ToString()));
                    }
                }
            }
            return anagramsID;
        }


        /*
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

        public List<int> FindCachedWords (int wordID)
        {
            var wordsID = new List<int>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CachedWords Where WordID = @WordId";
                cmd.Parameters.Add(new SqlParameter("WordId", wordID));
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        wordsID.Add(Int32.Parse(dr["AnagramID"].ToString()));
                    }
                }
            }
            return wordsID;
        }

        public void InsertIntoCashedWords(string word, List<int> anagramsID)
        {
            int wordID = FindWordID(word);
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (int anagramID in anagramsID)
                {
                    string sql = "INSERT INTO CachedWords (WordID, AnagramID) VALUES(@wordID, @anagramID)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add(new SqlParameter("@wordID", wordID));
                    cmd.Parameters.Add(new SqlParameter("@anagramID", anagramID));
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        */

    }
}
