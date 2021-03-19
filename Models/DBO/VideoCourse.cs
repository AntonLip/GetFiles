using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models.Interfaces;

namespace GetFiles.Models.dataBaseModel
{
    public class VideoCourse : IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string name { get; set; }
        public string info { get; set; }

        public List<Video> Video { get; set; }
      
    }
}
