using Web_Api_Project.Models;

namespace Web_Api_Project.Interface
{
    public interface IUserService
    {
        List<User> GetAll();
        User Get(int userId);
        Result Post(User currentUser, User user);
        Result Delete(User user, int userId);
    }
}
