using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GetFiles.Models.dataBaseModel;
using Models.Interfaces.RepositryPattern;
using Models.Interfaces.Services;

namespace Services
{
    public class VideoServices : IVideoService
    {
        private readonly IVideoRepositry _videoRepositry;

        public VideoServices(IVideoRepositry videoRepositry)
        {
            _videoRepositry = videoRepositry;
        }

        public async Task<Video> AddAsync(Video obj, CancellationToken cancellationToken = default)
        {
            await _videoRepositry.AddAsync(obj, cancellationToken);
            return obj;
        }

        public async Task<IEnumerable<Video>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _videoRepositry.GetAllAsync(cancellationToken);
        }

        public async Task<Video> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _videoRepositry.GetByIdAsync(id,cancellationToken);
        }

        public async Task<Video> RemoveAsync(Video item, CancellationToken cancellationToken = default)
        {
            await _videoRepositry.RemoveAsync(item, cancellationToken);
            return item;
        }

        public async Task<Video> UpdateAsync(Video item, CancellationToken cancellationToken = default)
        {
            await _videoRepositry.UpdateAsync(item, cancellationToken);
            return await _videoRepositry.GetByIdAsync(item.Id, cancellationToken);
        }
    }
}
