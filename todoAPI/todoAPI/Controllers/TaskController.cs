using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todoAPI.Context;
using todoAPI.Models;

namespace todoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _taskDbContext;

        public TaskController(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
        // GET: api/<TaskController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var tasks = await _taskDbContext.tasks.ToListAsync();
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// GET api/<TaskController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //POST api/<TaskController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TaskItem task)
        {
            try
            {
                _taskDbContext.tasks.Add(task);
                await _taskDbContext.SaveChangesAsync();
                return Ok(new { message = "Task added succesfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<TaskController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            try
            {
                var task = await _taskDbContext.tasks.SingleOrDefaultAsync(t => t.Id == id);
                if(task == null)
                {
                    return NotFound();
                }

                task.Is_completed = !task.Is_completed;
                _taskDbContext.Entry(task).State = EntityState.Modified;
                await _taskDbContext.SaveChangesAsync();
                return Ok(new { message = "task updated sucessfully!" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var task = await _taskDbContext.tasks.SingleOrDefaultAsync(t => t.Id == id);
                
                if(task == null)
                {
                    return NotFound();
                }

                _taskDbContext.tasks.Remove(task);
                await _taskDbContext.SaveChangesAsync();
                return Ok(new {message = "task removed sucessfully!"});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
