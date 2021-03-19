using System.Net;
using System.Threading.Tasks;
using GetFiles.Models.dataTransferModel;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using Models.Interfaces.Services;
using Services;
using Swashbuckle.AspNetCore.Annotations;

namespace FTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoCourcesController : ControllerBase
    {
        private readonly IVideoCoursesService _videoCoursesService;
       

        public VideoCourcesController(IVideoCoursesService videoCoursesService)
        {
            _videoCoursesService = videoCoursesService;
           
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> GetAllCources()
        {
           var courses =  await _videoCoursesService.GetAllAsync();
           return Ok(courses);
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK)]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> CreateCourse(AddVideoCourceDto model)
        {
            var course = await _videoCoursesService.AddAsync(model);
            return Ok(model);
        }

    }
}