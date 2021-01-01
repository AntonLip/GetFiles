using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetFiles.Models.dataTransferModel
{
    public class VideoDTO
    {
        public Guid idVideo { get; set; }
        public string nameOfVideo { get; set; }
        public string path { get; set; }

        public Guid VideoCourseId { get; set; }
    }
}
