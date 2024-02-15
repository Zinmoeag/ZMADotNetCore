using DotNet7TrainingBatch.ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet7TrainingBatch.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.ToList();

            foreach (BlogModel blog in lst)
            {
                Console.WriteLine(blog.blog_title);
                Console.WriteLine(blog.blog_content);
                Console.WriteLine(blog.blog_author);
            }
        }

        public void Edit(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel blog = db.Blogs.FirstOrDefault(item => item.blog_id == id);

            if(blog is null)
            {
                Console.WriteLine("no data found");
                return;
            }

            Console.WriteLine(blog.blog_title);
            Console.WriteLine(blog.blog_content);
            Console.WriteLine(blog.blog_author);
        }

        public void Create(string blogAuthor, string blogTitle, string blogContent)
        {
            BlogModel blog = new BlogModel()
            {
                blog_author = blogAuthor,
                blog_title = blogTitle,
                blog_content = blogContent,
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();

            string message = result > 0 ? "saving successful" : "saving Failed";
            Console.WriteLine(message);
        }


        public void Update(int id, string authour, string title, string content)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item =  db.Blogs.FirstOrDefault(item => item.blog_id == id);

            if(item is null)
            {
                Console.WriteLine("no data found");
                return;
            }

            item.blog_title = title;
            item.blog_author = authour;
            item.blog_content = content;

            int result = db.SaveChanges();

            string message = result > 0 ? "updated successful" : "update Failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.blog_id == id);

            if (item is null)
            {
                Console.WriteLine("no data found");
                return;
            }

            db.Blogs.Remove(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "delete successful" : "delete Failed";
            Console.WriteLine(message);
        }
    }
}
