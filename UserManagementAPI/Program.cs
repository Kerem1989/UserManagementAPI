using FluentValidation;
using Microsoft.AspNetCore.HttpLogging;
using UserManagementAPI.Endpoints;
using UserManagementAPI.Exceptions;
using UserManagementAPI.Middleware;
using UserManagementAPI.Models;

var builder = WebApplication.CreateBuilder(args);

    Dictionary<int, User> users = new Dictionary<int, User>
    {
        { 1, new User { Id = 1, Name = "John" } },
        { 2, new User { Id = 2, Name = "Jane" } },
        { 3, new User { Id = 3, Name = "Bob" } },
        { 4, new User { Id = 4, Name = "Alice" } },
        { 5, new User { Id = 5, Name = "Eve" } },
        { 6, new User { Id = 6, Name = "David" } },
    };

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddControllers();
    builder.Services.AddValidatorsFromAssemblyContaining<Program>();
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();
    builder.Services.AddHttpLogging(logging =>
    {
        logging.LoggingFields = HttpLoggingFields.RequestMethod;
        logging.LoggingFields = HttpLoggingFields.RequestPath;
        logging.LoggingFields = HttpLoggingFields.RequestHeaders;
    });
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.MapControllers();
    app.UseExceptionHandler();
    app.UseMiddleware<ApiKeyMiddleware>();
    app.UseHttpsRedirection();
    app.MapEndpoints(users);
    app.Run();