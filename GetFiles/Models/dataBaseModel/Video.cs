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

        public Video(VideoDTO videoDTO, VideoCourse videoCourse )
        {
            idVideo = videoDTO.idVideo;
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
