using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Data;
using Microsoft.AspNetCore.Mvc;

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
            var tournaments = _context.Tournaments.ToList();

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
            return Ok(tournament);
        }

    
    }
}