using EmployeeManagementSystem.Interfaces;
using EmployeeManagementSystem.Repositories;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connectionString = "server=localhost;port=3306;uid=root;pwd=bhavana;database=employee";

builder.Services.AddDbContext<EmployeeDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddScoped<IEmployee, EmployeeRepository>();
builder.Services.AddScoped<EmployeeService>();

builder.Services.AddScoped<IProject, ProjectRepository>();
builder.Services.AddScoped<ProjectService>();

builder.Services.AddScoped<ITask, TaskRepository>();
builder.Services.AddScoped<TaskService>();

builder.Services.AddAuthentication("default").AddCookie("default",
    options =>
    {
        options.Cookie.Name = "default";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", pb => pb.RequireClaim("Role", "Admin"));
    options.AddPolicy("AdminAndProjectManager",
        pb => pb.RequireClaim("Role", new string[] { "Admin", "ProjectManager" }));
    options.AddPolicy("AdminAndDeveloper",
       pb => pb.RequireClaim("Role", new string[] { "Admin", "Developer" }));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.MapPost("/login", async (string role, HttpContext ctx) =>
{

    await ctx.SignInAsync(new ClaimsPrincipal(
        new ClaimsIdentity(new Claim[] { new Claim("Role", role) }, "default")),
        new AuthenticationProperties { IsPersistent = true });

    return "Login";
});


app.MapGet("/logout", async (HttpContext ctx) =>
{

    await ctx.SignOutAsync();

    return "logout";
});

app.Run();
