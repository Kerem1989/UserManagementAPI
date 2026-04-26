using FluentValidation;
using UserManagementAPI.Models;
using UserManagementAPI.Services;

namespace UserManagementAPI.Endpoints ;

    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app, Dictionary<int, User> users)
        {
            var userService = new UserService();
            
            app.MapGet("/error-test", () =>
            {
                throw new InvalidOperationException("Test exception for middleware");
            });
            
            app.MapGet("/users/{id}", (int id) =>
            {
                var user = userService.GetUser(id, users);
                if (user is not null) return Results.Ok(user);
                return Results.NotFound();
            });
            
            app.MapGet("/users", () => Results.Ok(users.Values));
            
            app.MapPost("/users", (User user, IValidator<User> validator) =>
            {
                var validationResult = validator.Validate(user);
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary());
                }
                var createdUser = userService.CreateUser(user, users);
                return Results.Created($"/users/{createdUser.Id}", createdUser);
            });
            
            app.MapPut("/users/{id}", (int id, User user, IValidator<User> validator) =>
            {
                var validationResult = validator.Validate(user);
                if (!validationResult.IsValid)
                    return Results.ValidationProblem(validationResult.ToDictionary());
                var updatedUser = userService.UpdateUser(id, user, users);
                return updatedUser is not null ? Results.Ok(updatedUser) : Results.NotFound();
            });
            
            app.MapDelete("/users/{id}", (int id) =>
            {
                if (users.ContainsKey(id))
                {
                    userService.DeleteUser(id, users);
                    return Results.NoContent();
                }
                    return Results.NotFound();
            });
        }
    }