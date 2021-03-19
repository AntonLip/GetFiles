using System;
using GetFiles.Models.dataBaseModel;

namespace Models.Interfaces.RepositryPattern
{
   public  interface IVideoRepositry : IRepository<Video, Guid>
   {
    }
}
