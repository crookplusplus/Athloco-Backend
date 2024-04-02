using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Data;
using Microsoft.AspNetCore.Mvc;
using AthlocoServer.Mappers;
using AthlocoServer.Models;
using AthlocoServer.Dtos.Tournaments;

namespace AthlocoServer.Controllers
{
    [Route("api/tournaments")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public TournamentController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var tournaments = _context.Tournaments.ToList()
            .Select(t => t.toTournamentDto());

            return Ok(tournaments);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var tournament = _context.Tournaments.Find(id);

            if (tournament == null)
            {
                return NotFound();
            }
            return Ok(tournament.toTournamentDto());
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateTournamentRequestDto tournamentDto)
        {
            var tournamentModel = tournamentDto.ToTournamentFromCreateDTO();
            _context.Tournaments.Add(tournamentModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = tournamentModel.Id }, tournamentModel.toTournamentDto());
        }
    
    }
}