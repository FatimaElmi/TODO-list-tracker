using System.Collections.Generic;
using System.Threading.Tasks;
using TODO_list_tracker.Models;

namespace TODO_list_tracker.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetByUserAsync(string userId);
        Task<Category?> GetByIdForUserAsync(int id, string userId);
        Task<Category> AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Category category);
    }
}