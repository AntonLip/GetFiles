using GetFiles.Models.dataTransferModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetFiles.Models.dataBaseModel
{
    public class Video
    {
        public Video()
        {
                
        }

        public Video(string name, string _path, VideoCourse videoCourse)
        {
            nameOfVideo = name;
            path = _path;
            VideoCourse = videoCourse;
        }
        public Video(VideoDTO videoDTO, VideoCourse videoCourse )
        {
            nameOfVideo = videoDTO.nameOfVideo;
            path = videoDTO.path;
            VideoCourse = videoCourse;
        }

        [Key]
        public Guid idVideo { get; set; }
        public string nameOfVideo { get; set; }
        public string path { get; set; }

        public VideoCourse VideoCourse { get; set; }
       
    }
}
