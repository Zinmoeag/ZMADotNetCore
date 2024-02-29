using DotNet7TrainingBatch.ConsoleApp.Models;
using Microsoft.Identity.Client;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotNet7TrainingBatch.ConsoleApp.RefitExamples
{
    public interface IBLogApi
    {
        [Get("/api/Blog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/Blog/{id}")]
        Task<BlogModel> GetBlog(int id);

        [Post("/api/Blog")]
        Task<string> CreateBlog(BlogModel blog);

        [Put("/api/Blog/{id}")]
        Task<string> UpdateBlog(int id, BlogModel blog);

        [Delete("/api/Blog/{id}")]
        Task<string> DeleteBlog(int id);
    }
}
