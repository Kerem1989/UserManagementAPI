using UserManagementAPI.Models;

namespace UserManagementAPI.Services ;

    public class UserService
    {

        public User GetUser(int id, Dictionary<int, User> users)
        {
            return users.TryGetValue(id, out User user) ? user : null;
        }

        public User CreateUser(User user, Dictionary<int, User> users)
        {
            int id = users.Keys.Count == 0 ? 1 : users.Keys.Max() + 1;
            user.Id = id;
            users.Add(id, user);
            return user;
        }
        
        public User UpdateUser(int id, User user, Dictionary<int, User> users)
        {
            if (users.TryGetValue(id, out User existingUser))
            {
                existingUser.Name = user.Name;
                return existingUser;
            }
            return null;
  
        }

        public void DeleteUser(int id, Dictionary<int, User> users)
        {
            users.Remove(id);
        }
    }
    
