using DotNet7TrainingBatch.ConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace DotNet7TrainingBatch.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(100);
            //await Create("Api Call", "api author", "thsi si api call");
            //await Update(16, "Api Call 16", "api 16  author", "thsi si api call 16");
            await Delete(16);
        }

        public async Task Read()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(requestUri : "https://localhost:7116/api/Blog");

            if(res.IsSuccessStatusCode)
            {
                string jsonStr = await res.Content.ReadAsStringAsync();
                
                List<BlogModel> blog = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr);

                foreach (BlogModel item in blog)
                {
                    Console.WriteLine(item.blog_title);
                    Console.WriteLine(item.blog_content);
                    Console.WriteLine(item.blog_author);
                }
            } 
        }

        public async Task Edit(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.GetAsync(requestUri: $"https://localhost:7116/api/Blog/{id}");
            if(res.IsSuccessStatusCode) {
                string jsonStr = await res.Content.ReadAsStringAsync();

                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;

                Console.WriteLine(item.blog_title);
                Console.WriteLine(item.blog_content);
                Console.WriteLine(item.blog_author);
            }
            else
            {
                Console.WriteLine(res.Content.ReadAsStringAsync());
            }
        }

        public async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                blog_title = title,
                blog_author = author,
                blog_content = content,
            };

            string jsonBlog = JsonConvert.SerializeObject(blog);

            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.PostAsync(requestUri: "https://localhost:7116/api/Blog", httpContent);

            if (res.IsSuccessStatusCode)
            {
                string jsonres = await res.Content.ReadAsStringAsync();
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await res.Content.ReadAsStringAsync());
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
            string url = $"https://localhost:7116/api/Blog/{id}";

            BlogModel blog = new BlogModel()
            {
                blog_title=title,
                blog_author=author,
                blog_content=content,
            };

            string jsonBlog = JsonConvert.SerializeObject(blog);

            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);

            HttpClient httpClient = new HttpClient();

            HttpResponseMessage res = await httpClient.PutAsync(url, httpContent);

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(res.Content.ReadAsStringAsync());
            }
        }


        public async Task Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage res = await client.DeleteAsync(requestUri: $"https://localhost:7116/api/Blog/{id}");

            if (res.IsSuccessStatusCode)
            {
                string jsonStr = await res.Content.ReadAsStringAsync();

                Console.WriteLine(res.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(res.Content.ReadAsStringAsync());
            }
        }
    }
}
