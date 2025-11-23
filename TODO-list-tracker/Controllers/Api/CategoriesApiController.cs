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
    [Route("api/categories")]
    [ApiController]
    [Authorize]
    public class CategoriesApiController : ControllerBase
    {
        private readonly IRepository<Category> _repo;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public CategoriesApiController(IRepository<Category> repo, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            _repo = repo;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userId = _userManager.GetUserId(User);
            var all = await _repo.GetAllAsync();
            var mine = new List<Category>();
            foreach (var c in all)
            {
                if (string.IsNullOrEmpty(c.UserId) || c.UserId == userId) mine.Add(c);
            }
            return Ok(_mapper.Map<IEnumerable<CategoryDto>>(mine));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var cat = await _repo.GetByIdAsync(id);
            if (cat == null) return NotFound();
            var userId = _userManager.GetUserId(User);
            if (!string.IsNullOrEmpty(cat.UserId) && cat.UserId != userId) return NotFound();
            return Ok(_mapper.Map<CategoryDto>(cat));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userId = _userManager.GetUserId(User);
            var cat = _mapper.Map<Category>(dto);
            if (string.IsNullOrEmpty(cat.UserId)) cat.UserId = userId;
            await _repo.AddAsync(cat);
            return CreatedAtAction(nameof(Get), new { id = cat.Id }, _mapper.Map<CategoryDto>(cat));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCategoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();
            var userId = _userManager.GetUserId(User);
            if (!string.IsNullOrEmpty(existing.UserId) && existing.UserId != userId) return Forbid();
            existing.Name = dto.Name;
            await _repo.UpdateAsync(existing);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return NotFound();
            var userId = _userManager.GetUserId(User);
            if (!string.IsNullOrEmpty(existing.UserId) && existing.UserId != userId) return Forbid();
            await _repo.DeleteAsync(existing);
            return NoContent();
        }
    }
}