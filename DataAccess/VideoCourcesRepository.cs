using GetFiles.Models;
using GetFiles.Models.dataBaseModel;
using Models.Interfaces.RepositryPattern;

namespace DataAccess
{
    public class VideoCourcesRepository:BaseRepository<VideoCourse>, IVideoCourcesRepository
    {
        public VideoCourcesRepository(AppdbContext context) :base(context)
        {
            
        }
    }
}
