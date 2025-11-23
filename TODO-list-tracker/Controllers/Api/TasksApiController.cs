using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TODO_list_tracker.DTOs;
using TODO_list_tracker.Interfaces;
using TODO_list_tracker.Models;

namespace TODO_list_tracker.Controllers.Api
{
    [Route("api/tasks")]
    [ApiController]
    [Authorize]
    public class TasksApiController : ControllerBase
    {
        private readonly IRepository<TaskItem> _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public TasksApiController(IRepository<TaskItem> repo, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userId = _userManager.GetUserId(User);
            var all = await _repo.GetAllAsync();
            var mine = new List<TaskItem>();
            foreach (var t in all)
            {
                if (t.UserId == userId) mine.Add(t);
            }
            return Ok(_mapper.Map<IEnumerable<TaskItemDto>>(mine));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var userId = _userManager.GetUserId(User);
            var item = await _repo.GetByIdAsync(id);
            if (item == null || item.UserId != userId) return NotFound();
            return Ok(_mapper.Map<TaskItemDto>(item));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTaskItemDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = _userManager.GetUserId(User);
            var task = _mapper.Map<TaskItem>(dto);
            task.UserId = userId;
            await _repo.AddAsync(task);
            return CreatedAtAction(nameof(Get), new { id = task.Id }, _mapper.Map<TaskItemDto>(task));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateTaskItemDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = _userManager.GetUserId(User);
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null || existing.UserId != userId) return NotFound();

            existing.Title = dto.Title;
            existing.Description = dto.Description;
            existing.DueDate = dto.DueDate;
            existing.IsCompleted = dto.IsCompleted;
            existing.Priority = dto.Priority;
            existing.CategoryId = dto.CategoryId;

            await _repo.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null || existing.UserId != userId) return NotFound();
            await _repo.DeleteAsync(existing);
            return NoContent();
        }
    }
}