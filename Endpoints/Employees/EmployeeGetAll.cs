using IWantApp.Infra.Data;
using Microsoft.AspNetCore.Identity;

namespace IWantApp.Endpoints.Employees;

public class EmployeeGetAll
{
    public static string Template => "/employees";
    public static string[] Methods => new string[] { HttpMethod.Get.ToString() };
    public static Delegate Handle => Action;
    public static IResult Action(ApplicationDbContext context)
    {
        var employee = context.Users.ToList();
        var response = employee.Select(e => new IdentityUser { Id = e.Id,Email = e.Email, UserName = e.UserName, });
        return Results.Ok(response);
    }
}
