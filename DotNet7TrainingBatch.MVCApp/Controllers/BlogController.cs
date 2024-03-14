using DotNet7TrainingBatch.MVCApp;
using DotNet7TrainingBatch.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7TrainingBatch.MVCApp.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController()
        {
            _db = new AppDbContext();
        }

        [ActionName("Index")]
        public IActionResult BlogIndex()
        {
            List<BlogModel> lst = _db.Blogs.ToList();

            return View(lst);
        }


        [ActionName("Edit")]
        public IActionResult BlogEdit(int id)
        {
            BlogModel blog = _db.Blogs.FirstOrDefault(item => item.blog_id == id);

            if(blog is null)
            {
                return Redirect("Blog");
            }

            return View("BlogEdit", blog);

        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPut]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, BlogModel blog)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.blog_id == id);

            if(item is null)
            {
                return Redirect("/Blog");
            }

            item.blog_title = blog.blog_title;
            item.blog_author = blog.blog_author;
            item.blog_content = blog.blog_content;
            _db.SaveChanges();

            return Redirect("/Blog");

        }

        [ActionName("Delete")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel blog = _db.Blogs.FirstOrDefault(item => item.blog_id == id);

            if(blog is null) {
                return Redirect("/Blog");
            }

            _db.Remove(blog);
            _db.SaveChanges();
            return Redirect("/Blog");
        }
    }
}
