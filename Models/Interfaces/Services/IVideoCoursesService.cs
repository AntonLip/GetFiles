using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GetFiles.Models.dataBaseModel;
using GetFiles.Models.dataTransferModel;
using Models.DTO;

namespace Models.Interfaces.Services
{
    public interface IVideoCoursesService
    {
        Task<VideoCourseDTO> AddAsync(AddVideoCourceDto obj, CancellationToken cancellationToken = default);
        Task<IEnumerable<VideoCourseDTO>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<VideoCourseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<VideoCourse> UpdateAsync(VideoCourse item, CancellationToken cancellationToken = default);
        Task<VideoCourse> RemoveAsync(VideoCourse item, CancellationToken cancellationToken = default);
    }
}
