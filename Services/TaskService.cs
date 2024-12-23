using Web_Api_Project.Models;
using Web_Api_Project.Interface;
using Web_Api_Project.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Web_Api_Project.Services
{
    public class TaskService : ITaskServices
    {
        private string filePath = "DATA/Tasks.json";
        private List<TaskItem> tasks;
        private IUserService _userService;
        private HttpClient _httpClient; // הוסף את HttpClient


        public TaskService(IUserService userService, HttpClient httpClient)
        {
            this._userService = userService;
            this._httpClient = httpClient;
            tasks = JsonFileHelper.LoadFromFile<TaskItem>(filePath);

        }
        //    public void DeleteTasksByUserId(int userId)
        // {
        //     var tasks = JsonFileHelper.LoadFromFile<TaskItem>("DATA/Tasks.json");
        //    tasks = tasks.Where(t => t.UserId != userId).ToList();
        //     JsonFileHelper.SaveToFile("DATA/Tasks.json", tasks);
        // }

        public List<TaskItem> GetAll(int userId)
        {
            return tasks.Where(t => t.UserId == userId).ToList();
        }
        public TaskItem Get(int taskId)
        {
            return tasks.FirstOrDefault(t => t.TaskId == taskId);
        }
        public Result Post(int userId, TaskItem task)
        {
            var existingUser = _userService.GetAll().FirstOrDefault(u => u.UserId == userId);
            if (existingUser != null)
            {
                task.TaskId = tasks.Count + 1;
                task.UserId = userId;
                tasks.Add(task);
                JsonFileHelper.SaveToFile(filePath, tasks);
                return new Result(true, $"Task {task.Description} added successfully.");

            }
            else
            {
                return new Result(false, $"User with ID {userId} does not exist. Task cannot be added.");
            }

        }

        public Result Delete(int userId, int taskId)
        {
            var taskToDelete = tasks.FirstOrDefault(t => t.TaskId == taskId && t.UserId == userId);
            if (taskToDelete != null)
            {
                // שלח בקשה לשרת למחוק את המשימה
                var response = _httpClient.DeleteAsync($"https://http://localhost:5050//tasks/{taskId}");
                // if (response.IsCompletedSuccessfully)
                // {
                tasks.Remove(taskToDelete);
                JsonFileHelper.SaveToFile(filePath, tasks);
                return new Result(true, $"Task {taskId} deleted successfully.");
            }
            // else
            // {
            // return new Result(false, "Error deleting task on the server.");
            // }
            else
            {
                return new Result(false, "Task not found.");
            }
        }
        // var DeletTask = tasks.FirstOrDefault(t => t.TaskId == taskId && t.UserId == userId);
        // if (DeletTask != null)
        // {
        //     tasks.Remove(DeletTask);
        //     JsonFileHelper.SaveToFile(filePath, tasks);
        //     return new Result(true, $"Task {taskId} deleted successfully.");
        // }
        // else
        // {
        //     return new Result(false, "Task not found.");

        // }
        // }
        public Result Update(int userId, int taskId, TaskItem task)
        {
            var taskIndex = tasks.FindIndex(t => t.UserId == userId && t.TaskId == taskId);
            if (taskIndex >= 0)
            {
                tasks[taskIndex].TaskId = taskId;
                tasks[taskIndex].Description = task.Description;
                tasks[taskIndex].Status = task.Status;
                tasks[taskIndex].UserId = userId;

                JsonFileHelper.SaveToFile(filePath, tasks);
                return new Result(true, $"Task {task.Description} Update successfully.");
            }
            else
            {
                return new Result(false, "Task or User not found.");

            }
            LoadTasks();

        }

        private void LoadTasks()
        {
            // כאן תוכל לטעון את המשימות מחדש או לוגיקה אחרת לעדכון הממשק
            tasks = JsonFileHelper.LoadFromFile<TaskItem>(filePath);
        }
    }
}
// task.TaskId = tasks.Count > 0 ? tasks.Max(t => t.TaskId) + 1 : 1;
