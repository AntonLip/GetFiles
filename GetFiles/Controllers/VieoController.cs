using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GetFiles.Models;
using GetFiles.Models.dataBaseModel;
using GetFiles.Models.dataTransferModel;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace GetFiles.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VieoController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppdbContext _context;
        private readonly IFileProvider _fileProvider;

        public VieoController(IWebHostEnvironment env, AppdbContext context, IFileProvider fileProvider)
        {
            _env = env;
            _context = context;
            _fileProvider = fileProvider;
        }
        [HttpGet]
        public string hi()
        {
            return String.Format("Hi");
        }

        [Route("GetVideos")]
        [HttpGet]
        public async Task<IActionResult> GetVideos(string name)
        {
            if (name == null)
                return Content("name is empty");
            var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "Content", name).ToString();

            var memory = new MemoryStream();
            using (var stream = new FileStream(pathFile, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            try
            {
                memory.Position = 0;
                return File(memory, GetContentType(pathFile), Path.GetFileName(pathFile));
            }
            catch (Exception ex) 
            {
                return Content("Exeption message is {0}", ex.Message);
            }
        }
        [Route("Image")]
       
        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 1073741824)]
        [RequestSizeLimit(1073741824)]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile body)
        {
            try
            {
                if (body == null || body.Length == 0)
                    return BadRequest();

                var path = Path.Combine(
                            Directory.GetCurrentDirectory(), "photo",
                            body.GetFilename());

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await body.CopyToAsync(stream);
                }

                return Ok("Successfly");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
        
        [Route("Image")]
        [HttpGet]
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "photo", filename);

            var memory = new MemoryStream();
            try
            {
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(path), Path.GetFileName(path));
            }
            catch (FileNotFoundException ex)
            {
                return Content("Error is {0}", ex.Message);
            }

        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".mp4", "applicatioan/mp4"}
            };
        }

        // GET: api/Vieo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Video>> GetVideoCourse(Guid id)
        {
            var video = await _context.Video.FindAsync(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }
        [HttpPost]
        public async Task<ActionResult<Video>> PostVideoCourse(VideoDTO video)
        {
            var Course = await _context.VideoCourse.Where(c => c.idCourse == video.VideoCourseId).FirstOrDefaultAsync();
            Video videoNew = new Video(video, Course);
            _context.Video.Add(videoNew);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetVieo", new { id = videoNew.idVideo }, videoNew);
        }
    }
}
