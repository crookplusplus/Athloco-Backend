using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Models;
using AthlocoServer.Dto.Tournaments;
using AthlocoServer.Dtos.Tournaments;

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

        public static Tournaments ToTournamentFromCreateDTO(this CreateTournamentRequestDto tournamentRequestDto){
            
            return new Tournaments
            {
                Title = tournamentRequestDto.Title,
                Location = tournamentRequestDto.Location,
                Date = tournamentRequestDto.Date,
                Type = tournamentRequestDto.Type,
                TeamSize = tournamentRequestDto.TeamSize,
                Cost = tournamentRequestDto.Cost,
                CostPer = tournamentRequestDto.CostPer,
                Style = tournamentRequestDto.Style,
                Prize = tournamentRequestDto.Prize,
                Host = tournamentRequestDto.Host
            };
        }
    }
}