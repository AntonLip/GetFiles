using System;
using AutoMapper;
using GetFiles.Models.dataBaseModel;
using GetFiles.Models.dataTransferModel;
using Models.DTO;

namespace Models
{
    class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<VideoCourse, VideoCourseDTO>().ReverseMap();
            CreateMap<AddVideoCourceDto, VideoCourse>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());
        }
    }
}
