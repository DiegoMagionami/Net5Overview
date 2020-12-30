using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

namespace Net5Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsFeedController : ControllerBase
    {
        private readonly ILogger<NewsFeedController> _logger;
        private readonly IHostEnvironment _hostingEnvironment;

        public NewsFeedController(ILogger<NewsFeedController> logger, IHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet]
        public News Get()
        {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string path = Path.Combine(contentRootPath, "SampleData/news.json");
            string data = System.IO.File.ReadAllText(path);
            News result = JsonSerializer.Deserialize<News>(data);
            
            return result;
        }
    }
}
