using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GetFiles.Models.dataBaseModel;
using GetFiles.Models.dataTransferModel;
using Models.DTO;
using Models.Interfaces.RepositryPattern;
using Models.Interfaces.Services;

namespace Services
{
   public class VideoCoursesService : IVideoCoursesService

   {
       private readonly IVideoCourcesRepository _videoCourcesRepository;
       private readonly IMapper _mapper;

        public VideoCoursesService(IVideoCourcesRepository videoCourcesRepository,
            IMapper mapper)
       {
           _videoCourcesRepository = videoCourcesRepository;
           _mapper = mapper;
        }

        public async Task<VideoCourseDTO> AddAsync(AddVideoCourceDto model, CancellationToken cancellationToken = default)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(VideoCourse));
            }

            var modelDB = _mapper.Map<VideoCourse>(model);
            modelDB.CreatedDate = DateTime.UtcNow;
            modelDB.IsDeleted = false;
            await _videoCourcesRepository.AddAsync(modelDB, cancellationToken);
            return _mapper.Map<VideoCourseDTO>(modelDB);
        }

        public async Task<IEnumerable<VideoCourseDTO>> GetAllAsync(CancellationToken cancellationToken = default)
        {
             var courses = await  _videoCourcesRepository.GetAllAsync(cancellationToken);
             return courses is null ? throw new ArgumentNullException() : _mapper.Map<List<VideoCourseDTO>>(courses);

        }

        public async Task<VideoCourseDTO> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var courses = await _videoCourcesRepository.GetByIdAsync(id, cancellationToken);
            return courses is null ? throw new ArgumentNullException() : _mapper.Map<VideoCourseDTO>(courses);
        }

        public async Task<VideoCourse> UpdateAsync(VideoCourse item, CancellationToken cancellationToken = default)
        {
            await _videoCourcesRepository.UpdateAsync(item, cancellationToken);
            return await _videoCourcesRepository.GetByIdAsync(item.Id, cancellationToken);
        }

        public async Task<VideoCourse> RemoveAsync(VideoCourse item, CancellationToken cancellationToken = default)
        {
            await _videoCourcesRepository.RemoveAsync(item, cancellationToken);
            return item;
        }
    }
}
