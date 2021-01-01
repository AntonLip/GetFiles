using GetFiles.Models.dataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetFiles.Models.dataTransferModel
{
    public class VideosDTO
    {
        public VideosDTO()
        {

        }
        public VideosDTO( Video video)
        {
            id = video.idVideo;
            name = video.nameOfVideo;
            path = video.path;
        }
        public Guid id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
    }

    
}
