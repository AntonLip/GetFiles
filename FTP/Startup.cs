using System;
using System.Threading.Tasks;
using GetFiles.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FTP
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRouting(options => options.LowercaseUrls = true);
           
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0",
                    Title = "exadel-bonus-plus API 1.0",
                });
               
            });
            

            services.AddDbContextPool<AppdbContext>(opts =>
                opts.UseSqlServer(Configuration["ConnectionStrings:connectionString"])
            );
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.Parse(Configuration["FileSizeLimit"]);
            });
            services.AddVideoTransient();
            services.AddVideoCoursesTransient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseSwagger();

            app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Exadel Bonus Plus API 1.0");
                }
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", context =>
                {
                    context.Response.Redirect("/swagger/");
                    return Task.CompletedTask;
                });
                endpoints.MapControllers();
            });
        }
    }
}
