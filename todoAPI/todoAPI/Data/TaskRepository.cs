using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using todoAPI.Context;
using todoAPI.Entities;
using todoAPI.Interfaces;

namespace todoAPI.Data
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public void AddTaskItem(TaskItem taskItem)
        {
            _context.tasks.Add(taskItem);
        }

        public void DeleteTaskItem(TaskItem task)
        {
            _context.tasks.Remove(task);
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _context.tasks.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TaskItem>> GetTasksAsync()
        {
            return await _context.tasks.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateStatus(TaskItem taskItem)
        {
            _context.Entry(taskItem).State = EntityState.Modified;
        }

        public void UpdateTaskItem(TaskItem taskItem)
        {
            _context.Entry(taskItem).State = EntityState.Modified;
        }
    }
}
