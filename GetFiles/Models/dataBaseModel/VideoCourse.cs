using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GetFiles.Models.dataBaseModel
{
    public class VideoCourse
    {
        [Key]
        public Guid idCourse { get; set; }
        public string nameOfCourse { get; set; }
        public string info { get; set; }

        public List<Video> Video { get; set; }
    }
}
