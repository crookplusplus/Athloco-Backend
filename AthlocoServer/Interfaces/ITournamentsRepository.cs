using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Dtos.Tournaments;
using AthlocoServer.Models;

namespace AthlocoServer.Interfaces
{
    public interface ITournamentsRepository
    {
        Task<List<Tournaments>> GetAllAsync();
        Task<Tournaments?> GetByIdAsync(int id); //This will call FirstOrDefault() which CAN return NULL thus the need for the ?
        Task<Tournaments> CreateAsync(Tournaments tournamentModel); //cannot be NULL
        Task<Tournaments?> UpdateAsync(int id, UpdateTournamentRequestDto tournamentDto);
        Task<Tournaments?> DeleteAsync(int id);
    }
}