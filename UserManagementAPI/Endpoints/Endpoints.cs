using UserManagementAPI.Models;
using UserManagementAPI.Services;

namespace UserManagementAPI.Endpoints ;

    public static class Endpoints
    {
        public static void MapEndpoints(this WebApplication app, Dictionary<int, User> users)
        {
            var userService = new UserService();
            
            app.MapGet("/users/{id}", (int id) =>
            {
                var user = userService.GetUser(id, users);
                return user is not null ? Results.Ok(user) : Results.NotFound();
            });
            
            app.MapGet("/users", () => Results.Ok(users.Values));
            
            app.MapPost("/users", (User user) =>
            {
                var createdUser = userService.CreateUser(user, users);
                return Results.Created($"/users/{createdUser.Id}", createdUser);
            });
            
            app.MapPut("/users/{id}", (int id, User user) =>
            {
                var updatedUser = userService.UpdateUser(id, user, users);
                return updatedUser is not null ? Results.Ok(updatedUser) : Results.NotFound();
            });
            
            app.MapDelete("/users/{id}", (int id) =>
            {
                userService.DeleteUser(id, users);
                return Results.NoContent();
            });
        }
    }