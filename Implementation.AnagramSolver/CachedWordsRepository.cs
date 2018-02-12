using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.AnagramSolver
{

    //to do - atskirti logika ir duombaziu uzklausas
    //to do - isskaidyti duombaziu uzklausas i skirtingas klases pagal tai, su kokiomis lentelemis dirbama

    public class CachedWordsRepository
    {
        String _connectionString;

        public CachedWordsRepository(String connectionString)
        {
            _connectionString = connectionString;
        }

        public CachedWordsRepository()
        {
            _connectionString = @"Data Source=LT-LIT-SC-0428;Initial Catalog=Anagrams;Integrated Security=sspi;";
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

        public List<int> FindCachedWords(string word)
        {
            int wordId = FindWordID(word);
            if(wordId == 0)
            {
                return null;
            }
            else
            {
                return FindCachedWords(wordId);
            }
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

        public void InsertIntoCashedWords(string word, List<string> anagrams)
        {
            int anagramId;
            List<int> anagramsID = new List<int>();
            foreach(string anagram in anagrams)
            {
                anagramId = this.FindWordID(anagram);
                anagramsID.Add(anagramId);
            }
            InsertIntoCashedWords(word, anagramsID);
        }

    }
}
