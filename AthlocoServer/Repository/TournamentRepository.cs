using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Data;
using AthlocoServer.Dtos.Tournaments;
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

        public async Task<Tournaments> CreateAsync(Tournaments tournamentModel)
        {
            await _context.Tournaments.AddAsync(tournamentModel);
            await _context.SaveChangesAsync();
            return tournamentModel;
        }

        public async Task<Tournaments?> DeleteAsync(int id)
        {
            var tournamentModel = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == id);

            if(tournamentModel == null)
            {
                return null;
            }

            _context.Tournaments.Remove(tournamentModel);
            await _context.SaveChangesAsync();
            return tournamentModel;
        }

        public async Task<List<Tournaments>> GetAllAsync()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public async Task<Tournaments?> GetByIdAsync(int id)
        {
            return await _context.Tournaments.FindAsync(id);
        }

        public async Task<Tournaments?> UpdateAsync(int id, UpdateTournamentRequestDto tournamentDto)
        {
            var existingTournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == id);

            if (existingTournament == null)
            {
                return null;
            }

            existingTournament.Title = tournamentDto.Title;
            existingTournament.Location = tournamentDto.Location;  
            existingTournament.Date = tournamentDto.Date;
            existingTournament.Type = tournamentDto.Type;
            existingTournament.TeamSize = tournamentDto.TeamSize;
            existingTournament.Cost = tournamentDto.Cost;
            existingTournament.CostPer = tournamentDto.CostPer;
            existingTournament.Style = tournamentDto.Style;
            existingTournament.Prize = tournamentDto.Prize;
            existingTournament.Host = tournamentDto.Host;

            await _context.SaveChangesAsync();
            return existingTournament;
        }
    }
}