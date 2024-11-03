using System.Collections.Generic;
using System.Linq;
using Web_Api_Project.Models;
using Web_Api_Project.Helpers;

namespace Web_Api_Project.Services
{
    public class LoginService : ILoginService
    {
        private readonly List<User> users;

        public LoginService()
        {
            // טוען את רשימת המשתמשים מקובץ JSON
            users = JsonFileHelper.LoadFromFile<User>("DATA/Users.json");
        }

        public User Authenticate(string username, string password)
        {
            // בדיקה אם קיים משתמש עם שם משתמש וסיסמה תואמים
            return users.SingleOrDefault(user => user.UserName == username && user.Password == password);
        }
    }
}
