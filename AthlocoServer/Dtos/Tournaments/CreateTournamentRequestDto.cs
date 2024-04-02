using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Models;

namespace AthlocoServer.Dtos.Tournaments
{
    public class CreateTournamentRequestDto
    {
        public string Title { get; set; } = string.Empty; 
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TournamentType Type { get; set; }
        public int TeamSize { get; set; }   
        public decimal Cost { get; set; }
        public CostType CostPer { get; set; }
        public TournamentStyle Style { get; set; }
        public decimal Prize { get; set; }
        public string Host { get; set; } = string.Empty;
    }
}