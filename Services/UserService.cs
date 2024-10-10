using Web_Api_Project.Models;
using Web_Api_Project.Interface;
using Web_Api_Project.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Web_Api_Project.Services
{
    public class UserService : IUserService
    {
        private string filePath = "DATA/Users.json";
        private List<User> users;
        private IUserTaskServices _userTaskServices;
        public UserService(IUserTaskServices userTaskServices)
        {
            this._userTaskServices = userTaskServices;
            users = JsonFileHelper.LoadFromFile<User>(filePath);
        }
        public List<User> GetAll()
        {
            return users;
        }
        public User Get(int userId)
        {
            return users.FirstOrDefault(u => u.UserId == userId);
        }
        public Result Post(User currentUser, User user)
        {
            if (currentUser.Role == "Admin")
            {
                if (!users.Any(u => u.UserName == user.UserName))
                {
                    user.UserId = users.Count + 1;
                    users.Add(user);
                    JsonFileHelper.SaveToFile(filePath, users);
                    return new Result(true, $"User {user.UserName} added successfully.");
                }
                else
                {
                    return new Result(false, "User with the same username already exists.");
                }

            }
            else
            {
                return new Result(false, "Only administrators can add users.");
            }
        }

        public Result Delete(User currentUset, int userId)
        {
            if (currentUset.Role == "Admin")
            {
                var userToDelete = users.FirstOrDefault(u => u.UserId == userId);
                if (userToDelete != null)
                {
                    _userTaskServices.DeleteTasksByUserId(userId);
                    users.Remove(userToDelete);
                    JsonFileHelper.SaveToFile(filePath, users);
                    return new Result(true, $"User {userToDelete.UserName} deleted successfully.");
                }
                else
                {
                    return new Result(false, "User not found.");

                }
            }
            else
            {
                return new Result(false, "Only administrators can delete users.");
            }

        }
    }
}
