using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
using TaskAPI.Services;

namespace TaskAPI.Controllers
{
    /// <summary>
    /// task controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        BaseTaskService _taskCollectionService;
        BaseUserService _userService;

        public TaskController(BaseTaskService taskCollectionService, BaseUserService userService)
        {
            _taskCollectionService = taskCollectionService ?? throw new ArgumentNullException(nameof(TaskService));
            _userService = userService ?? throw new ArgumentNullException(nameof(UserService));
        }

        /// <summary>
        /// returns all tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            List<TaskModel> tasks = _taskCollectionService.GetAll();
            return Ok(tasks);
        }


        /// <summary>
        /// adds a task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskModel task)
        {
            _taskCollectionService.Create(task);
            return Ok(task);
        }

        /// <summary>
        /// replaces the task that has the matching id with the sent task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] TaskModel task)
        {
            _taskCollectionService.Update(task.Id, task);
            return Ok(task);
        }

        /// <summary>
        /// deletes task with matching id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            bool deleted = _taskCollectionService.Delete(id);

            if (!deleted)
                return NotFound();

            return Ok(200);
        }
    }
}
