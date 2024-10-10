using Microsoft.AspNetCore.Mvc;
using Web_Api_Project.Helpers;
using Web_Api_Project.Models;

namespace Web_Api_Project.Interface
{
    public interface ITaskServices
    {
        List<TaskItem> GetAll(int userId);
        TaskItem Get(int taskId);
        Result Post(int userId, TaskItem Task);
        Result Delete(int userId, int taskId);
        Result Update(int userId, int taskId, TaskItem Task);
    }
}
