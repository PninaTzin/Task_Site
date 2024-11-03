using Web_Api_Project.Models;

namespace Web_Api_Project.Services
{
    public interface ILoginService
    {
        // פונקציה שמקבלת שם משתמש וסיסמה ומחזירה את המשתמש אם ההזדהות הצליחה
        User Authenticate(string username, string password);
    }
}
