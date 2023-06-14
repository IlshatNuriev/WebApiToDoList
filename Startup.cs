using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using WebApiToDoList.Data;
using WebApiToDoList.Filters;
using WebApiToDoList.SeedData;

namespace WebApiToDoList
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {



            services.AddDbContext<WebApiToDoListContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebApiToDoListContext") ?? throw new InvalidOperationException("Connection string 'WebApiToDoListContext' not found.")));


            services.AddControllers()
                    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "WebApiToDoList",
                    Version = "v1"
                });
            });

            services.AddScoped<ISortByNameOrStartDate, SortByNameOrStartDate>();
     
            using (var context = services.BuildServiceProvider())
            {
                var scope = context.CreateScope().ServiceProvider;
                SeedData.SeedData.Initialize(scope);
            }

        }

        
        


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
                        
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiToDoList v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
