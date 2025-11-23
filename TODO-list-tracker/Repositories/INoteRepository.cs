using System.Collections.Generic;
using System.Threading.Tasks;
using TODO_list_tracker.Models;

namespace TODO_list_tracker.Repositories
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetByUserAsync(string userId);
        Task<Note?> GetByIdForUserAsync(int id, string userId);
        Task AddAsync(Note note);
        Task UpdateAsync(Note note);
        Task DeleteAsync(Note note);
    }
}