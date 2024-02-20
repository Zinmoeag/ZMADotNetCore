using DotNet7TrainingBatch.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DotNet7TrainingBatch.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult getBlog()
        {
            List<BlogModel> lst =  _db.Blogs.OrderByDescending(x => x.blog_id).ToList();
            return Ok(lst);
        }


        [HttpGet(template:"{id}")]
        public IActionResult getEditBlog(int id)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(item => item.blog_id == id);

            if(item is null)
            {
                return NotFound("no data fund");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult blogCreate(BlogModel blog)
        {

            _db.Blogs.Add(blog);
            int result = _db.SaveChanges();

            string message = result > 0 ? "created successfull" : "created Failed";
            return Ok(message);
        }

        [HttpPut(template:"{id}")]
        public IActionResult blogUpdate(int id, BlogModel blog)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(blog => blog.blog_id == id);

            if (item == null)
            {
                return BadRequest();
            }

            item.blog_title = blog.blog_title;
            item.blog_author = blog.blog_author;
            item.blog_content = blog.blog_content;
            int result = _db.SaveChanges();

            string msg = result > 0 ? "update success" : "update failed";

            return Ok(msg);
        }

        [HttpDelete(template:"{id}")]  
        public IActionResult blogDelete(int id)
        {
            BlogModel item = _db.Blogs.FirstOrDefault(blog => blog.blog_id == id);

            if(item is null)
            {
                return NotFound();
            }
            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();
            string msg = result > 0 ? "deleting success" : "deletig failed";


            return Ok(msg);
        }
    }
}
