using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConsole
{
    class DatabaseSQL : IDatabase
    {
        String _connectionString = "Data Source=LT-LIT-SC-0428;Initial Catalog=AnagramsCF;Integrated Security=sspi;";

        public void AddWordsToDatabase(List<string> words)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                foreach (string word in words)
                {
                    string sql = "INSERT INTO dbo.Words (Word1) VALUES(@Word)";
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.Parameters.Add(new SqlParameter("@Word", word));
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /*
         * USE [Anagrams]
            GO
                    SET ANSI_NULLS ON
                    GO
            SET QUOTED_IDENTIFIER ON
            GO
            ALTER PROCEDURE[dbo].[DeleteTable]
                    @TableName varchar(50)
            AS
            BEGIN
             declare @sql varchar(200);
                    set @sql = 'Delete From ' + @TableName
             EXECUTE(@sql)
            END
        */
       
        public void DeleteTable(string table)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteTable";
                cmd.Parameters.Add(new SqlParameter("@TableName", table));
                cmd.ExecuteNonQuery();
            }
        }

        /*

        public void DeleteTable(string table)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Delete From " + table;
                //cmd.Parameters.Add(new SqlParameter("@Table", table));
                cmd.ExecuteNonQuery();
            }
        }

         */
    }
}
