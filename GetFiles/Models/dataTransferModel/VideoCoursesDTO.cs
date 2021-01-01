using GetFiles.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetFiles.Models.dataTransferModel
{
    public class VideoCourseDTO
    {
        public VideoCourseDTO()
        {

        }
        public VideoCourseDTO(VideoCourse videoCourse)
        {
            id = videoCourse.idCourse;
            name = videoCourse.nameOfCourse;
            info = videoCourse.info;

        }
        public Guid id { get; set; }
        public string name { get; set; }
        public string info { get; set; }
    }



    public class VideoCoursesDTO
    {
        public VideoCoursesDTO()
        {
            videoCourses = new List<VideoCourseDTO>();
        }        
        public List<VideoCourseDTO> videoCourses { get; set; }
        public int countCourse { get; set; }
    }

    public class VideoCourseWithVideoDTO
    {
        public VideoCourseWithVideoDTO()
        {
            videos = new List<VideosDTO>();
        }
        public VideoCourseWithVideoDTO(VideoCourse videoCourse)
        {
            videos = new List<VideosDTO>();
            foreach (var v in videoCourse.Video)
            {
                videos.Add(new VideosDTO(v));
            }
            countVideo = videos.Count;
            name = videoCourse.nameOfCourse;
            info = videoCourse.info;
            id = videoCourse.idCourse;
        }

        public List<VideosDTO> videos { get; set; }
        public Guid id { get; set; }
        public string name { get; set; }
        public string info { get; set; }
        public int countVideo { get; set; }
    }


}