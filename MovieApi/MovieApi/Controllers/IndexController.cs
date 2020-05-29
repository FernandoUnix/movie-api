using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
namespace MovieApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var readMe = System.IO.File.ReadAllText("READ_ME.txt");
            return readMe;
        }
    }
}
