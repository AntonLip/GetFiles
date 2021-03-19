using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Models.Interfaces.RepositryPattern;
using Models.Interfaces.Services;
using Services;

namespace FTP
{
    public static class IServiceCollectionExtensions
    {
        public static void AddVideoTransient(this IServiceCollection services)
        {
            services.AddScoped<IVideoRepositry, VideoRepository>();
            services.AddTransient<IVideoService, VideoServices>();
        }

        public static void AddVideoCoursesTransient(this IServiceCollection services)
        {
            services.AddScoped<IVideoCourcesRepository, VideoCourcesRepository > ();
            services.AddTransient<IVideoCoursesService, VideoCoursesService>();
        }
    }
}
