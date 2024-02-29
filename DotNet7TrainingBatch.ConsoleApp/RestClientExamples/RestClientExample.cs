using DotNet7TrainingBatch.ConsoleApp.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DotNet7TrainingBatch.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {

        private string _apiUri = "https://localhost:7116/api/Blog";
        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(100);
            //await Create("Api Call", "api author", "thsi si api call");
            //await Update(17, "Api Call 16", "api 16  author", "thsi si api call 16");
            //await Delete(16);
        }

        public async Task Read()
        {
            RestRequest req = new RestRequest(_apiUri, Method.Get);
            RestClient client = new RestClient();
            RestResponse res = await client.ExecuteAsync(req);    

            if (res.IsSuccessStatusCode)
            {
                string jsonStr = res.Content!;

                List<BlogModel> blog = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;

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
            string url = $"{_apiUri}/{id}";

            RestRequest req = new RestRequest(url, Method.Get);
            RestClient client = new RestClient();
            RestResponse res = await client.ExecuteAsync(req);
            if (res.IsSuccessStatusCode)
            {
                string jsonStr = res.Content!;

                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;

                Console.WriteLine(item.blog_title);
                Console.WriteLine(item.blog_content);
                Console.WriteLine(item.blog_author);
            }
            else
            {
                Console.WriteLine(res.Content);
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

            RestRequest req = new RestRequest(_apiUri, Method.Post);
            req.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse res = await client.ExecuteAsync(req);


            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine( res.Content);
            }
            else
            {
                Console.WriteLine( res.Content);
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
            string url = $"{_apiUri}/{id}";

            BlogModel blog = new BlogModel()
            {
                blog_title = title,
                blog_author = author,
                blog_content = content,
            };

            RestRequest req = new RestRequest(url, Method.Put);
            req.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse res = await client.ExecuteAsync(req);
            
            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content);
            }
            else
            {
                Console.WriteLine(res.Content);
            }
        }


        public async Task Delete(int id)
        {
            string url = $"{_apiUri}/{id}";

            RestRequest req = new RestRequest(url, Method.Delete);
            RestClient client = new RestClient();
            RestResponse res = await client.ExecuteAsync(req);

            if (res.IsSuccessStatusCode)
            {
                Console.WriteLine(res.Content);
            }
            else
            {
                Console.WriteLine(res.Content);
            }
        }
    }
}

