using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using todoAPI.Entities;
using todoAPI.Interfaces;

namespace todoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var tasks = await _taskRepository.GetTasksAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                var task = await _taskRepository.GetTaskByIdAsync(id);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskItem task)
        {
            try
            {
                _taskRepository.AddTaskItem(task);

                if (await _taskRepository.SaveAllAsync()) return Ok(new { message = "Task added successfully" });
                return BadRequest("Fail to add task");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(TaskItem taskItem, int id)
        {
            try
            {
                var task = await _taskRepository.GetTaskByIdAsync(id);

                if (task == null)
                {
                    return NotFound();
                }

                task.Title = taskItem.Title;
                task.Due_date = taskItem.Due_date;
                task.Priority_id = taskItem.Priority_id;
                task.Is_completed = taskItem.Is_completed;

                _taskRepository.UpdateStatus(task);

                if (await _taskRepository.SaveAllAsync()) return NoContent();
                return BadRequest("Fail to update user");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await _taskRepository.GetTaskByIdAsync(id);

                if (task == null)
                {
                    return NotFound();
                }

                _taskRepository.DeleteTaskItem(task);

                if (await _taskRepository.SaveAllAsync()) return Ok();
                return Ok(new { message = "task removed successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
