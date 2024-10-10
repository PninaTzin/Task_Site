using Web_Api_Project.Helpers;
using Web_Api_Project.Models;

namespace Web_Api_Project.Services
{
    public class UserTaskServices :  IUserTaskServices
    {
           public void DeleteTasksByUserId(int userId)
        {
            var tasks = JsonFileHelper.LoadFromFile<TaskItem>("DATA/Tasks.json");
           tasks = tasks.Where(t => t.UserId != userId).ToList();
            JsonFileHelper.SaveToFile("DATA/Tasks.json", tasks);
        }
    }
}