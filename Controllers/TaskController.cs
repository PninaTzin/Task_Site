using Microsoft.AspNetCore.Mvc;
using Web_Api_Project.Interface;
using Web_Api_Project.Services;
using Web_Api_Project.Models;
using Microsoft.AspNetCore.Http;

namespace Web_Api_Project.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private ITaskServices _taskService;
        public TaskController(ITaskServices taskService)
        {
            this._taskService = taskService;
        }

        [HttpGet("all/{userId}")]
        public IActionResult GetAll(int userId)
        {
            return Ok(_taskService.GetAll(userId));
        }

        [HttpGet("{taskId}")]
        public IActionResult Get(int taskId)
        {
            return Ok(_taskService.Get(taskId));
        }


        [HttpPost("{userId}")]
        public IActionResult Post(int userId, TaskItem task)
        {
            var result = _taskService.Post(userId, task);
            if (result.Success)
            {
                return Ok(result.Message);

            }
            else
            {
                return BadRequest(result.Message);

            }
        }

        [HttpDelete("{userId}delete{taskId}")]
        public IActionResult Delete(int userId, int taskId)
        {
            var result = _taskService.Delete(userId, taskId);
            if (result.Success)
            {
                return Ok(result.Message);

            }
            else
            {
                return BadRequest(result.Message);

            }
        }

        [HttpPut("{userId}update{taskId}")]
        public IActionResult Update(int userId, int taskId, TaskItem task)
        {
            var result = _taskService.Update(userId, taskId, task);
            if (result.Success)
            {
                return Ok(result.Message);

            }
            else
            {
                return BadRequest(result.Message);

            }
        }
    }
}