using FluentValidation;
using UserManagementAPI.Endpoints;
using UserManagementAPI.Middleware;
using UserManagementAPI.Models;
var builder = WebApplication.CreateBuilder(args);

//Dictonary of users that simulates a database
Dictionary<int, User> users = new Dictionary<int, User>
{
    {1, new User{Id = 1, Name = "John"}},
    {2, new User{Id = 2, Name = "Jane"}},
    {3, new User{Id = 3, Name = "Bob"}},
    {4, new User{Id = 4, Name = "Alice"}},
    {5, new User{Id = 5, Name = "Eve"}},
    {6, new User{Id = 6, Name = "David"}},
};
// Add services to the container.
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();
    var app = builder.Build();
// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.MapControllers();
    app.UseMiddleware<ApiKeyMiddleware>();

    app.UseHttpsRedirection();
// Map endpoints from Endpoints.cs
    app.MapEndpoints(users);
    app.Run();
    