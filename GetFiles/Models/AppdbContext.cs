using GetFiles.Models.dataBaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetFiles.Models
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options)
             : base(options)
        {

        }
        public DbSet<VideoCourse> VideoCourse { get; set; }
        public DbSet<Video> Video { get; set; }

    }
}
