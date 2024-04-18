using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Data;
using AthlocoServer.Interfaces;
using AthlocoServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AthlocoServer.Repository
{
    public class TournamentRepository : ITournamentsRepository
    {
        private readonly ApplicationDBContext _context;
        public TournamentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<List<Tournaments>> GetAllAsync()
        {
            return _context.Tournaments.ToListAsync();
        }
    }
}