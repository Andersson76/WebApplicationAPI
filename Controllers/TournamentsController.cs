using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentService _service;

        public TournamentsController(ITournamentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TournamentResponseDto>>> GetAll([FromQuery] string? search)
        {
            var tournaments = await _service.GetAllAsync(search);

            var result = tournaments.Select(t => new TournamentResponseDto
            {
                Id = t.Id,
                Title = t.Title
            });

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tournament>> GetById(int id)
        {
            var tournament = await _service.GetByIdAsync(id);

            if (tournament is null)
                return NotFound($"Tournament med id {id} hittades inte.");

            return Ok(tournament);
        }

        [HttpPost]
        public async Task<ActionResult<Tournament>> Create([FromBody] TournamentCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tournament = new Tournament
            {
                Title = dto.Title,
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            var created = await _service.CreateAsync(tournament);

            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TournamentUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updatedTournament = new Tournament
            {
                Title = dto.Title,
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            var success = await _service.UpdateAsync(id, updatedTournament);

            if (!success)
                return NotFound($"Tournament med id {id} hittades inte.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);

            if (!success)
                return NotFound($"Tournament med id {id} hittades inte.");

            return NoContent();
        }
    }
}