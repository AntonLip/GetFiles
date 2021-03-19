using GetFiles.Models.dataTransferModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models.Interfaces;

namespace GetFiles.Models.dataBaseModel
{
    public class Video :IEntity<Guid>
    {

      
         [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string nameOfVideo { get; set; }
        public string path { get; set; }

        public VideoCourse VideoCourse { get; set; }
      
    }
}
