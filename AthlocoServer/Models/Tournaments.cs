using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AthlocoServer.Models
{
    public enum TournamentType
    {
        COED,
        //Men and Women play together
        MENS_WOMENS,
        //Men and Women play separately
        MENS,
        WOMENS,
        BLIND_DRAW
        //coed blind draw
    }
    public enum CostType
    {
        PER_TEAM,
        PER_PERSON
    }
    public enum TournamentStyle
    {
        FUN,
        COMPETITIVE,
        BOTH,
    }
    public class Tournaments
    {
        public int Id { get; set; }
        //the string.Empty sets the default value to an empty string instead of a null value
        public string Title { get; set; } = string.Empty; 
        public string Location { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public TournamentType Type { get; set; }
        public int TeamSize { get; set; }   

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Cost { get; set; }
        public CostType CostPer { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Prize { get; set; }
        public string Host { get; set; } = string.Empty;
    }
}