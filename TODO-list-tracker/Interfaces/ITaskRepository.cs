using System.Collections.Generic;
using System.Threading.Tasks;
using TODO_list_tracker.Models;

namespace TODO_list_tracker.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskItem>> GetByUserAsync(string userId);
        Task<TaskItem?> GetByIdForUserAsync(int id, string userId);
        Task<TaskItem> AddAsync(TaskItem item);
        Task UpdateAsync(TaskItem item);
        Task DeleteAsync(TaskItem item);
    }
}