using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Models;
using AthlocoServer.Dto.Tournaments;

namespace AthlocoServer.Mappers
{
    public static class TournamentMappers
    {
        public static TournamentDto toTournamentDto (this Tournaments tournamentModel)
        {
            return new TournamentDto
            {
                Id = tournamentModel.Id,
                Title = tournamentModel.Title,
                Location = tournamentModel.Location,
                Date = tournamentModel.Date,
                Type = tournamentModel.Type,
                TeamSize = tournamentModel.TeamSize,
                Style = tournamentModel.Style,
                Prize = tournamentModel.Prize,
                Host = tournamentModel.Host
            };
        }
    }
}