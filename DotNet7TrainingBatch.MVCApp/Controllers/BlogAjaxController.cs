using DotNet7TrainingBatch.MVCApp;
using DotNet7TrainingBatch.MVCApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNet7TrainingBatch.MVCApp.Controllers
{
    public class BlogAjaxController : Controller
    {
        private readonly AppDbContext _db;
        public BlogAjaxController()
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

            return View("BlogAjaxEdit", blog);

        }

        [ActionName("Create")]
        public IActionResult BlogCreate()
        {
            return View("BlogAjaxCreate");
        }

        [HttpPost]
        [ActionName("Save")]
        public IActionResult BlogSave(BlogModel blog)
        {
            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();
            bool isSuccess = result > 0;
            BlogResponseModel blogResponse = new BlogResponseModel {
                isSuccess = isSuccess,
                message = isSuccess ? "saving successfull" : "saving failed",
            };

            return Json(blogResponse);
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult BlogUpdate(int id, BlogModel blog)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.blog_id == id);

            if(item is null)
            {
                BlogResponseModel blogResponse = new BlogResponseModel
                {
                    isSuccess = false,
                    message = "not data found",
                };
                return Json(blogResponse);
            }

            item.blog_title = blog.blog_title;
            item.blog_author = blog.blog_author;
            item.blog_content = blog.blog_content;
            int result = _db.SaveChanges();
            bool isSuccess = result > 0;

            BlogResponseModel blogResponseModel = new BlogResponseModel
            {
                isSuccess = isSuccess,
                message = isSuccess ? "updating successful" : "updating failed",
            };

            return Json(blogResponseModel);

        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteBlog(BlogModel blog)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.blog_id == blog.blog_id);

            if(blog is null) {
                BlogResponseModel blogMessageResponse = new BlogResponseModel
                {
                    isSuccess = false,
                    message = "not data found",
                };
                return Json(blogMessageResponse);
            }

            _db.Remove(item);
            int result = _db.SaveChanges();
            bool isSuccess = result > 0;

            BlogResponseModel blogResponse = new BlogResponseModel
            {
                isSuccess = isSuccess,
                message = isSuccess ? "deleting successful" : "deleting failed",
            };
            return Json(blogResponse);
        }
    }
}
