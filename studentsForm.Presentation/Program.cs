using Microsoft.EntityFrameworkCore;
using studentsForm.Application.Interfaces.Service;
using studentsForm.Application.Interfaces.UnitOfWork;
using studentsForm.Application.Mapping;
using studentsForm.Application.Services;
using studentsForm.Infrastructure;
using studentsForm.Infrastructure.UnitOfWork;

namespace studentsForm.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>

      options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
          b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))

  );
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IStudentService, StudentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Student}/{action=AddStudent}/{id?}");

            app.Run();
        }
    }
}
