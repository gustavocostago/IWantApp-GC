using IWantApp.Endpoints.Categories;
using IWantApp.Endpoints.Employees;
using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;

namespace IWantApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionStrings:IWantDb"]);
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            
            app.UseAuthorization();

            app.MapMethods(CategoryPost.Template, CategoryPost.Methods,CategoryPost.Handle);
            app.MapMethods(CategoryGetAll.Template, CategoryGetAll.Methods, CategoryGetAll.Handle);
            app.MapMethods(CategoryPut.Template, CategoryPut.Methods, CategoryPut.Handle);
            app.MapMethods(EmployeePost.Template, EmployeePost.Methods, EmployeePost.Handle);
            app.MapMethods(EmployeeGetAll.Template, EmployeeGetAll.Methods, EmployeeGetAll.Handle);

            app.Run();
        }
    }
}