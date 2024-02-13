using Dapper;
using DotNet7TrainingBatch.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNet7TrainingBatch.ConsoleApp.DapperExamples
{
    public class DapperExample
    {
        public void Read()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "testing",
                UserID  = "sa",
                Password = "zma123",
            };

            string query = @"SELECT [blog_id]
                            ,[blog_title]
                            ,[blog_content]
                            ,[blog_author]
                            FROM [dbo].[tbl_blogs]";

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            List<BlogModel> lst = db.Query<BlogModel>(query).ToList();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine("author = " + item.blog_author);
                Console.WriteLine("title = " + item.blog_title);
                Console.WriteLine("content = " + item.blog_author);
            }
        }

        public void Edit(int blogId) {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "testing",
                UserID = "sa",
                Password = "zma123",
            };

            string query = @"SELECT [blog_id]
                            ,[blog_title]
                            ,[blog_content]
                            ,[blog_author]
                            FROM [dbo].[tbl_blogs] Where blog_id = @blog_id";


            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogModel>(query,new {blog_id = blogId}).FirstOrDefault();

            if(item is null)
            {
                Console.WriteLine("No data Found");
                return;
            }

            Console.WriteLine("author = " + item.blog_author);
            Console.WriteLine("title = " + item.blog_title);
            Console.WriteLine("content = " + item.blog_author);

        }

        public void Create(string blogTitle, string blogAuthor, string blogContent)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "testing",
                UserID = "sa",
                Password = "zma123",
            };

            string query = @"INSERT INTO [dbo].[tbl_blogs]
                            ([blog_title]
                            ,[blog_content]
                            ,[blog_author])
                            VALUES
                            (@blog_title
                            ,@blog_content
                            ,@blog_title)";

            BlogModel blog = new BlogModel()
            {
               blog_author = blogAuthor,
               blog_content = blogContent,
               blog_title = blogTitle,
            };

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "saving successful" : "saving failed";

            Console.WriteLine(message);
        }

        public void Update(int id , string blogTitle, string blogAuthor, string blogContent)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "testing",
                UserID = "sa",
                Password = "zma123",
            };

            string query = @"UPDATE [dbo].[tbl_blogs]
                        SET [blog_title] = @blog_title
                        ,[blog_content] = @blog_content
                        ,[blog_author] = @blog_author
                        WHERE blog_id = @blog_id";

            BlogModel blog = new BlogModel()
            {
                blog_id = id,
                blog_author = blogAuthor,
                blog_content = blogContent,
                blog_title = blogTitle,
            };

            using IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, blog);

            string message = result > 0 ? "saving successful" : "saving failed";

            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = ".",
                InitialCatalog = "testing",
                UserID = "sa",
                Password = "zma123",
            };

            string query = @"DELETE FROM [dbo].[tbl_blogs]
                            WHERE blog_id = @blog_id";

            BlogModel blog = new BlogModel()
            {
               blog_id = id,
            };

            using IDbConnection db  = new SqlConnection(sqlConnectionStringBuilder.ConnectionString); 
            int result = db.Execute(query, blog);

            string message = result > 0 ? "deleting successful" : "deleting failed";
            Console.WriteLine(message);
        }
    }
}
