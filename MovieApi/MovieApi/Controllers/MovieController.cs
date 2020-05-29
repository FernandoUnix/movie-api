using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;
using MovieApi.Service;
using Newtonsoft.Json;

namespace MovieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Video>> Get()
        {
            IJsonVideoService jsonService = new JsonVideoService();

            DadosVideo videos = jsonService.read();

            if (videos != null)
            {
                return videos.resource.videos;
            }
            else
            {
                RequestJsonVideoService requestJsonVideoService = new RequestJsonVideoService();

                DadosVideo dadosVideo = await requestJsonVideoService.GetDadosVideo();
                jsonService.save(dadosVideo);

                return dadosVideo.resource.videos;
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Video video)
        {
            IJsonVideoService jsonService = new JsonVideoService();
            DadosVideo dadosVideo = jsonService.read();

            if (dadosVideo != null)
            {
                dadosVideo.resource.videos.Add(video);
                jsonService.save(dadosVideo);

                return Created("Criado com sucesso", video);
            }
            else
            {
                return NotFound("Arquivo não encontrado, por favor atualize a lista de arquivos");
            }
        }
    }
}
