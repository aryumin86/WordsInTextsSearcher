using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
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

            services.AddDbContext<SearcherDbContext>(options =>
                options.UseNpgsql(appConf.MainDbConnString));

            services.AddScoped<IWordsRepo, WordsRepo>();
            services.AddScoped<IWordFormsRepo, WordFormsRepo>();
            services.AddScoped<ITextRecordsRepo, TextRecordsRepo>();
            services.AddScoped<ITagsRepo, TagsRepo>();

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<TextRecordsService>();
            services.AddScoped<WordsService>();
            services.AddScoped<WordFormsService>();
            services.AddScoped<StatsService>();
            services.AddScoped<TagsService>();

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
