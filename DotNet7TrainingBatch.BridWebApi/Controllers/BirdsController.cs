using DotNet7TrainingBatch.BridWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNet7TrainingBatch.BridWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.GetAsync("https://burma-project-ideas.vercel.app/birds");

            if(res.IsSuccessStatusCode) {

                string jsonBirds = await res.Content.ReadAsStringAsync();
                List<BirdDataModel> birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(jsonBirds)!;

                // mapping way of list
                //List<BirdViewModel> lst = birds.Select(bird => GetBirdViewData(bird)).ToList();

                List<BirdViewModel> lst = new List<BirdViewModel>();

                foreach(BirdDataModel bird in birds)
                {
                    lst.Add(GetBirdViewData(bird));
                }

                return Ok(lst);
            }
            return BadRequest();
        }

        [HttpGet(template: "{id}")]
        public async Task<IActionResult> Edit(int id)
        {

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage res = await httpClient.GetAsync($"https://burma-project-ideas.vercel.app/birds/{id}");

            if (res.IsSuccessStatusCode)
            {
                string jsonBird = await res.Content.ReadAsStringAsync();
                BirdDataModel bird = JsonConvert.DeserializeObject<BirdDataModel>(jsonBird);

                BirdViewModel birdView = GetBirdViewData(bird);

                return Ok(birdView);
            }
            return BadRequest();
        }

        private BirdViewModel GetBirdViewData(BirdDataModel bird)
        {
            BirdViewModel data = new BirdViewModel()
            {
                Id = bird.Id,
                BirdName = bird.BirdMyanmarName,
                Behaviour = bird.Description,
                Image = "https://burma-project-ideas.vercel.app/" + bird.ImagePath,
            };

            return data;
        }
    }
}
