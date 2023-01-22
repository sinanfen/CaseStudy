using CaseStudy.Data;
using CaseStudy.Data.Services.Abstract;
using CaseStudy.Data.Services.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        //dbcontext configuration
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

        //AddRazorRuntimeCompilation -->> This package 
        services.AddControllersWithViews().AddRazorRuntimeCompilation();

        services.AddScoped<INoteService, NoteManager>();
        services.AddScoped<INoteDetailService, NoteDetailManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Notes}/{action=Index}/{id?}");
        });

        //Seed database
        AppDbInitializer.Seed(app);

    }
}

