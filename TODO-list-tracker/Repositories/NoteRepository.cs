using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODO_list_tracker.Data;
using TODO_list_tracker.Models;

namespace TODO_list_tracker.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApplicationDbContext _db;

        public NoteRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Note>> GetByUserAsync(string userId)
        {
            return await _db.Notes
                .AsNoTracking()
                .Where(n => n.UserId == userId)
                .ToListAsync();
        }

        public async Task<Note?> GetByIdForUserAsync(int id, string userId)
        {
            return await _db.Notes
                .FirstOrDefaultAsync(n => n.Id == id && n.UserId == userId);
        }

        public async Task AddAsync(Note note)
        {
            await _db.Notes.AddAsync(note);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Note note)
        {
            _db.Notes.Update(note);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Note note)
        {
            _db.Notes.Remove(note);
            await _db.SaveChangesAsync();
        }
    }
}