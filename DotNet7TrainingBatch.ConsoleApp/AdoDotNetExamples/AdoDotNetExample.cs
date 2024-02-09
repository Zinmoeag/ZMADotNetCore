using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;


namespace DotNet7TrainingBatch.ConsoleApp.AdoDotNetExamples
{
    public class AdoDotNetExample
    {
        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "zma123";

            string query = @"SELECT [blog_id]
                            ,[blog_title]
                            ,[blog_content]
                            ,[blog_author]
                            FROM [dbo].[tbl_blogs]";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            connection.Close();

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine("author = " + row["blog_author"]);
                Console.WriteLine("title = " + row["blog_title"]);
                Console.WriteLine("content = " + row["blog_content"]);
            }
            
        }

        public void Edit(int blogId)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "zma123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            string query = @"SELECT [blog_id]
                            ,[blog_title]
                            ,[blog_content]
                            ,[blog_author]
                            FROM [dbo].[tbl_blogs] Where blog_id = @blog_id";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);

            // prevent sql injection put value as parimeter
            cmd.Parameters.AddWithValue("blog_id", blogId);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            sqlConnection.Close();

            if(dt.Rows.Count == 0)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            DataRow row = dt.Rows[0];
            Console.WriteLine("row");
            Console.WriteLine("author = " + row["blog_author"]);
            Console.WriteLine("title = " + row["blog_title"]);
            Console.WriteLine("content = " + row["blog_content"]);

        }
    
        public void Create(string blogAuthor, string blogContent, string blogtitle)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog  = "testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "zma123";

            SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"INSERT INTO [dbo].[tbl_blogs]
                            ([blog_title]
                            ,[blog_content]
                            ,[blog_author])
                            VALUES
                            (@blog_title
                            ,@blog_content
                            ,@blog_title)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@blog_title", blogtitle);
            cmd.Parameters.AddWithValue("@blog_content", blogContent);
            cmd.Parameters.AddWithValue("@blog_author", blogAuthor);
            int result = cmd.ExecuteNonQuery();

            string message  = result > 0 ? "success" : "failed";

            Console.WriteLine(message);

            connection.Close();
        }

        public void Update(int id, string blogAuthor, string blogContent, string blogtitle)
        {
            SqlConnectionStringBuilder sqlConnectionString = new SqlConnectionStringBuilder();
            sqlConnectionString.DataSource = ".";  
            sqlConnectionString.InitialCatalog = "testing";
            sqlConnectionString.UserID = "sa";
            sqlConnectionString.Password = "zma123";


            SqlConnection connection = new SqlConnection(sqlConnectionString.ConnectionString);
            string query = @"UPDATE [dbo].[tbl_blogs]
                        SET [blog_title] = @blogtitle
                        ,[blog_content] = @blogContent
                        ,[blog_author] = @blogAuthor
                        WHERE blog_id = @id";

            connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@blogtitle", blogtitle);
            cmd.Parameters.AddWithValue("@blogAuthor", blogAuthor);
            cmd.Parameters.AddWithValue("@blogContent", blogContent);

            int result = cmd.ExecuteNonQuery();

            connection.Close();

            string msg = result > 0 ? "success" :   "failed";
            Console.WriteLine(msg);

        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = ".";
            sqlConnectionStringBuilder.InitialCatalog = "testing";
            sqlConnectionStringBuilder.UserID = "sa";
            sqlConnectionStringBuilder.Password = "zma123";

            SqlConnection sqlConnection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            string query = @"DELETE FROM [dbo].[tbl_blogs]
                            WHERE blog_id = @id";

            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            cmd.Parameters.AddWithValue("@id", id);
            int result = cmd.ExecuteNonQuery();
            sqlConnection.Close();
             
            string msg = result > 0 ? "deleted" : "deleteFailed";

            Console.WriteLine(msg);
        }
    }
}
