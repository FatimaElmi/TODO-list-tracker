using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODO_list_tracker.Data;
using TODO_list_tracker.Interfaces;
using TODO_list_tracker.Models;

namespace TODO_list_tracker.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _context;

        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskItem>> GetByUserAsync(string userId)
        {
            return await _context.TaskItems
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }

        public async Task<TaskItem?> GetByIdForUserAsync(int id, string userId)
        {
            return await _context.TaskItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

        public async Task<TaskItem> AddAsync(TaskItem item)
        {
            _context.TaskItems.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task UpdateAsync(TaskItem item)
        {
            _context.TaskItems.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskItem item)
        {
            _context.TaskItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}