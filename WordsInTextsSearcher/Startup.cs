using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WordsInTextsSearcher.Data;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    //.WithOrigins("http://localhost:5005", "http://127.0.0.1:5005", "http://localhost:4200")
                    //.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
                    //.AllowCredentials());
            });

            AppConf appConf = Configuration.GetSection("AppConf").Get<AppConf>();
            services.AddSingleton(appConf);

            //string sourcesFolder = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            var location = System.Reflection.Assembly.GetEntryAssembly().Location;
            var sourcesFolder = System.IO.Path.GetDirectoryName(location);

            var logsRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            var logsFile = new FileInfo(sourcesFolder + Path.DirectorySeparatorChar + appConf.LogsFile);
            XmlConfigurator.Configure(logsRepository, logsFile);
            services.AddLogging(x =>
                x.AddProvider(new Log4NetProvider(logsFile.FullName))
            );

            services.AddDbContext<SearcherDbContext>(options =>
                options.UseNpgsql(appConf.MainDbConnString));

            services.AddScoped<IWordsRepo, WordsRepo>();
            services.AddScoped<IWordFormsRepo, WordFormsRepo>();
            services.AddScoped<ITextRecordsRepo, TextRecordsRepo>();
            services.AddScoped<ITagsRepo, TagsRepo>();
            services.AddScoped<ITextAttributesRepo, TextAttributesRepo>();
            services.AddScoped<ITextAttributeValuesRepo, TextAttributeValuesRepo>();
            services.AddScoped<ITextAttrBindingsRepo, TextAttrBindingsRepo>();
            services.AddScoped<IProjectsRepo, ProjectsRepo>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            services.AddRazorPages();
            services.AddServerSideBlazor()
                .AddCircuitOptions(options => { options.DetailedErrors = true; });
            services.AddScoped<TextRecordsService>();
            services.AddScoped<WordsService>();
            services.AddScoped<WordFormsService>();
            services.AddScoped<StatsService>();
            services.AddScoped<TagsService>();
            services.AddScoped<TextAttributesService>();
            services.AddScoped<TextAttrBindingsService>();
            services.AddScoped<ProjectsService>();
            services.AddScoped<UsersService>();

            services.AddSignalR(hubOptions =>
            {
                hubOptions.MaximumReceiveMessageSize = 10 * 1024 * 1024; // 10MB
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
