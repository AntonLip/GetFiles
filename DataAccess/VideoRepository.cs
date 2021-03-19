using GetFiles.Models;
using GetFiles.Models.dataBaseModel;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces.RepositryPattern;

namespace DataAccess
{
    public class VideoRepository: BaseRepository<Video>, IVideoRepositry
    {
        public VideoRepository(AppdbContext context) :base(context)
        {
        }
    }
}
