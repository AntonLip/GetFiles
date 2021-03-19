using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GetFiles.Models.dataBaseModel;

namespace Models.Interfaces.Services
{
    public interface IVideoService
    {
        Task<Video> AddAsync(Video obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<Video>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Video> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Video> UpdateAsync(Video item, CancellationToken cancellationToken = default);
        Task<Video> RemoveAsync(Video item, CancellationToken cancellationToken = default);
    }
}
