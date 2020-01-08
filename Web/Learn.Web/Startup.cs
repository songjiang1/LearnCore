using Learn.Util;
using Learn.Util.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders; 
using Microsoft.Extensions.Options; 
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.HttpOverrides;
using Learn.Web.Controllers;
using UEditor.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;

namespace Learn.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IConfigurationRoot ConfigurationRoot { get; }

        public IHostingEnvironment Env { get; }
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            this.Configuration = configuration;
            this.Env = env;
            LogHelper.Configure(); //使用前先配置
            GlobalContext.LogWhenStart(env); 
            GlobalContext.HostingEnvironment = env; 
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                                                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                                                    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                                                    .AddEnvironmentVariables();
          ConfigurationRoot = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container. 
        //IServiceProvider
        public void ConfigureServices(IServiceCollection services)
        {
            //将Redis分布式缓存服务添加到服务中
            //services.AddDistributedRedisCache(options =>
            //{
            //    //用于连接Redis的配置  Configuration.GetConnectionString("RedisConnectionString")读取配置信息的串
            //    options.Configuration = "localhost";// Configuration.GetConnectionString("RedisConnectionString");
            //    //Redis实例名RedisDistributedCache
            //    options.InstanceName = "RedisDistributedCache";
            //});
            services.AddCors(c =>
            {  
                //一般采用这种方法
                c.AddPolicy("AllowSpecificOrigins", policy =>
                {
                    // 支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                    // 注意，http://127.0.0.1:1818 和 http://localhost:1818 是不一样的，尽量写两个
                    policy
                    .WithOrigins("http://127.0.0.1", "http://localhost")
                    .AllowAnyHeader()//Ensures that the policy allows any header.
                    .AllowAnyMethod();
                });
            });
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
           
            services.AddUEditorService();
            services.AddMvc(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            // 取消默认驼峰 System.Text.Json方式
            .AddJsonOptions(options => { 
                options.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All);
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });
            //NewtonsoftJson 方式 
            //AddNewtonsoftJson(options =>   options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddOptions();
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(GlobalContext.HostingEnvironment.ContentRootPath + Path.DirectorySeparatorChar + "DataProtection"));
            services.AddRazorPages();
            GlobalContext.Services = services;
            GlobalContext.ServiceProvider = services.BuildServiceProvider();
            GlobalContext.Configuration = Configuration;


            var builder = new ContainerBuilder();
            services.AddSingleton(new Appsettings(Env));

            ////将services填充到Autofac容器生成器中
            //builder.Populate(services); 
            ////使用已进行的组件登记创建新容器
            //var ApplicationContainer = builder.Build();   
            //return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            GlobalContext.SystemConfig = Configuration.GetSection("SystemConfig").Get<SystemConfig>();
            if (!string.IsNullOrEmpty(GlobalContext.SystemConfig.VirtualDirectory))
            {
                app.UsePathBase(new PathString(GlobalContext.SystemConfig.VirtualDirectory)); // 让 Pathbase 中间件成为第一个处理请求的中间件， 才能正确的模拟虚拟路径
            }
            if (env.IsDevelopment())
            {
                GlobalContext.SystemConfig.Debug = true;
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            #region 实现跨域 
            app.UseCors("AllowSpecificOrigins");
            #endregion
            // 跳转https
            //app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();
            string resource = Path.Combine(env.ContentRootPath, "Resource");
            if (!Directory.Exists(resource))
            {
                Directory.CreateDirectory(resource);
            }
            //app.UseSession();


            //静态文件注册
            app.UseStaticFiles();
            //自定义静态文件夹 并过滤文件
            var provider = new FileExtensionContentTypeProvider();
            //provider.Mappings.Remove("gif");
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"upload")),
                RequestPath = new PathString("/upload"),
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=36000");
                },
                ContentTypeProvider = provider
            }); ;
            ////启用静态文件目录游览
            //app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //    Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
            //    RequestPath = new PathString("/MyStaticFiles")
            //});
            ////UseFileServer的功能结合了UseStaticFiles，UseDefaultFiles和UseDirectoryBrowser。
            //app.UseFileServer(new FileServerOptions()
            //{
            //    FileProvider = new PhysicalFileProvider(
            //    Path.Combine(Directory.GetCurrentDirectory(), @"StaticFiles")),
            //    RequestPath = new PathString("/StaticFiles"),
            //    EnableDirectoryBrowsing = true
            //});


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapHub<ChatHub>("/api2/chatHub");
            });
        }

        /// <summary>
        /// 跨域方法
        /// </summary>
        /// <param name="services"></param>
        //private void OptionConfigure(IServiceCollection services)
        //{
        //    services.Configure<CorsOptions>(Configuration.GetSection("AllowedHosts"));
        //}
    }
}
