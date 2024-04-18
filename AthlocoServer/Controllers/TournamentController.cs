using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Data;
using Microsoft.AspNetCore.Mvc;
using AthlocoServer.Mappers;
using AthlocoServer.Models;
using AthlocoServer.Dtos.Tournaments;
using Microsoft.EntityFrameworkCore;
using AthlocoServer.Interfaces;

namespace AthlocoServer.Controllers
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ITournamentsRepository _tournamentsRepo;
        public TournamentController(ApplicationDBContext context, ITournamentsRepository tournamentsRepo)
        {
            _tournamentsRepo = tournamentsRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tournaments = await _tournamentsRepo.GetAllAsync();

            var tournamentsDto = tournaments.Select(t => t.toTournamentDto());

            return Ok(tournaments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament.toTournamentDto());
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTournamentRequestDto tournamentDto)
        {
            var tournamentModel = tournamentDto.ToTournamentFromCreateDTO();
            await _context.Tournaments.AddAsync(tournamentModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = tournamentModel.Id }, tournamentModel.toTournamentDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTournamentRequestDto updateDto){
            var tournamentModel = await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);

            if (tournamentModel == null)
            {
                return NotFound();
            }

            tournamentModel.Title = updateDto.Title;
            tournamentModel.Location = updateDto.Location;  
            tournamentModel.Date = updateDto.Date;
            tournamentModel.Type = updateDto.Type;
            tournamentModel.TeamSize = updateDto.TeamSize;
            tournamentModel.Cost = updateDto.Cost;
            tournamentModel.CostPer = updateDto.CostPer;
            tournamentModel.Style = updateDto.Style;
            tournamentModel.Prize = updateDto.Prize;
            tournamentModel.Host = updateDto.Host;

            await _context.SaveChangesAsync();
            return Ok(tournamentModel.toTournamentDto());
        }
    
        [HttpDelete]
        [Route("{id}")]

        public async Task<IActionResult> Delete([FromRoute] int id){

            var tournamentModel = await _context.Tournaments.FirstOrDefaultAsync(t => t.Id == id);
        
            if (tournamentModel == null)
            {
                return NotFound();
            }

            _context.Tournaments.Remove(tournamentModel);

            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}