using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetFiles.Models;
using GetFiles.Models.dataBaseModel;
using GetFiles.Models.dataTransferModel;

namespace GetFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoCoursesController : ControllerBase
    {
        private readonly AppdbContext _context;

        public VideoCoursesController(AppdbContext context)
        {
            _context = context;
        }

        // GET: api/VideoCourses
        [HttpGet]
        public async Task<ActionResult<VideoCoursesDTO>> GetVideoCourse()
        {
            var courses =  await _context.VideoCourse.ToListAsync();
            VideoCoursesDTO videoCourses = new VideoCoursesDTO();
            foreach (var c in courses)
            {
                var couese = new VideoCourseDTO(c);
                videoCourses.videoCourses.Add(couese);
            }
            videoCourses.countCourse = videoCourses.videoCourses.Count;
            return videoCourses;
        }

        // GET: api/VideoCourses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoCourseWithVideoDTO>> GetVideoCourse(Guid id)
        {
            var videoCourse = await _context.VideoCourse.Where(c => c.idCourse == id).Include(c => c.Video).FirstAsync();
            if (videoCourse == null)
            {
                return NotFound();
            }
            VideoCourseWithVideoDTO videoDTO = new VideoCourseWithVideoDTO(videoCourse);
            


            return videoDTO;
        }

        // PUT: api/VideoCourses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoCourse(Guid id, VideoCourse videoCourse)
        {
            if (id != videoCourse.idCourse)
            {
                return BadRequest();
            }

            _context.Entry(videoCourse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoCourseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VideoCourses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VideoCourse>> PostVideoCourse(VideoCourse videoCourse)
        {
            _context.VideoCourse.Add(videoCourse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVideoCourse", new { id = videoCourse.idCourse }, videoCourse);
        }

        // DELETE: api/VideoCourses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VideoCourse>> DeleteVideoCourse(Guid id)
        {
            var videoCourse = await _context.VideoCourse.FindAsync(id);
            if (videoCourse == null)
            {
                return NotFound();
            }

            _context.VideoCourse.Remove(videoCourse);
            await _context.SaveChangesAsync();

            return videoCourse;
        }

        private bool VideoCourseExists(Guid id)
        {
            return _context.VideoCourse.Any(e => e.idCourse == id);
        }
    }
}
