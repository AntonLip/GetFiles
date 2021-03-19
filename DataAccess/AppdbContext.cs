using GetFiles.Models.dataBaseModel;
using Microsoft.EntityFrameworkCore;

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
