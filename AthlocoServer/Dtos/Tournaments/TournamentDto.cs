using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AthlocoServer.Models;

namespace AthlocoServer.Dto.Tournaments
{
    public class TournamentDto
    {
        public int Id { get; set; }
        //the string.Empty sets the default value to an empty string instead of a null value
        public string Title { get; set; } = string.Empty; 
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TournamentType Type { get; set; }
        public int TeamSize { get; set; }   
        public TournamentStyle Style { get; set; }
        public decimal Prize { get; set; }
        public string Host { get; set; } = string.Empty;
    }
}