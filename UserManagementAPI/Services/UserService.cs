using UserManagementAPI.Models;

namespace UserManagementAPI.Services ;

    public class UserService
    {

        public User GetUser(int id, Dictionary<int, User> users)
        {
            users.TryGetValue(id, out User user);
            return user;
        }

        public User CreateUser(User user, Dictionary<int, User> users)
        {
            int id = users.Keys.Max() + 1;
            user.Id = id;
            users.Add(id, user);
            return user;
        }
        
        public User UpdateUser(int id, User user, Dictionary<int, User> users)
        {
            if (users.ContainsKey(id))
            {
                user.Id = id;
                users[id] = user;
                return user;
            }
            return null;
        }

        public void DeleteUser(int id, Dictionary<int, User> users)
        {
            users.Remove(id);
        }
    }
    
