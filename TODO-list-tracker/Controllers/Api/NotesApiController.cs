using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TODO_list_tracker.DTOs;
using TODO_list_tracker.Models;
using TODO_list_tracker.Repositories;

namespace TODO_list_tracker.Controllers.Api
{
    [Route("api/notes")]
    [ApiController]
    [Authorize]
    public class NotesApiController : ControllerBase
    {
        private readonly INoteRepository _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public NotesApiController(INoteRepository repo, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = _userManager.GetUserId(User);
            var notes = await _repo.GetByUserAsync(userId);
            return Ok(_mapper.Map<IEnumerable<NoteDto>>(notes));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var userId = _userManager.GetUserId(User);
            var note = await _repo.GetByIdForUserAsync(id, userId);
            if (note == null) return NotFound();
            return Ok(_mapper.Map<NoteDto>(note));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateNoteDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = _userManager.GetUserId(User);
            var note = _mapper.Map<Note>(dto);
            note.UserId = userId;
            await _repo.AddAsync(note);
            var resultDto = _mapper.Map<NoteDto>(note);
            return CreatedAtAction(nameof(Get), new { id = note.Id }, resultDto);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateNoteDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = _userManager.GetUserId(User);
            var existing = await _repo.GetByIdForUserAsync(id, userId);
            if (existing == null) return NotFound();
            existing.Title = dto.Title;
            existing.Description = dto.Description;
            await _repo.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);
            var existing = await _repo.GetByIdForUserAsync(id, userId);
            if (existing == null) return NotFound();
            await _repo.DeleteAsync(existing);
            return NoContent();
        }
    }
}
