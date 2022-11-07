using System.Collections.Generic;
using System.Threading.Tasks;
using todoAPI.Entities;

namespace todoAPI.Interfaces
{
    public interface ITaskRepository
    {
        void AddTaskItem(TaskItem task);
        void UpdateTaskItem(TaskItem taskItem);
        void UpdateStatus(TaskItem taskItem);
        Task<IEnumerable<TaskItem>> GetTasksAsync();
        Task<TaskItem> GetTaskByIdAsync(int id);
        void DeleteTaskItem(TaskItem taskItem);
        Task<bool> SaveAllAsync();
        
    }
}
