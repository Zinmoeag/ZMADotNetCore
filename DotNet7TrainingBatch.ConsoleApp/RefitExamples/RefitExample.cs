using DotNet7TrainingBatch.ConsoleApp.Models;
using Refit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DotNet7TrainingBatch.ConsoleApp.RefitExamples
{
    public class RefitExample
    {
        private readonly IBLogApi refitApi = RestService.For<IBLogApi>("https://localhost:7116");
        public async Task Run() 
        {
            //await Read();
            //await Edit(10);
            //await Edit(1000);
            await Create("Api Call", "api author", "thsi si api call");
            await Update(20, "Api Call 16", "api 16  author", "thsi si api call 16");
            await Delete(20);
        }

        public async Task Read()
        {
            List<BlogModel> lst = await refitApi.GetBlogs();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.blog_title);
                Console.WriteLine(item.blog_content);
                Console.WriteLine(item.blog_author);
            }
        }


        public async Task Edit(int id)
        {
            try
            {
                BlogModel item = await refitApi.GetBlog(id);
                Console.WriteLine(item.blog_title);
                Console.WriteLine(item.blog_content);
                Console.WriteLine(item.blog_author);
            }
            catch (Refit.ApiException e)
            {
                Console.WriteLine(e.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        public async Task Create(string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    blog_title = title,
                    blog_author = author,
                    blog_content = content,
                };

                string res = await refitApi.CreateBlog(blog);

                Console.WriteLine(res);
            }
            catch(Refit.ApiException e)
            {
                Console.WriteLine(e.Content);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
            try
            {
                BlogModel blog = new BlogModel()
                {
                    blog_title = title,
                    blog_author = author,
                    blog_content = content,
                };

                string res = await refitApi.UpdateBlog(id, blog);

                Console.WriteLine(res);
            }
            catch (Refit.ApiException e)
            {
                Console.WriteLine(e.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                string res = await refitApi.DeleteBlog(id);
            }
            catch (Refit.ApiException e)
            {
                Console.WriteLine(e.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}
