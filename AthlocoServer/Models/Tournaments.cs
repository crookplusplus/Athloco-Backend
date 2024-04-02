using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AthlocoServer.Models
{
    public enum TournamentType
    {
        COED, //0
        //Men and Women play together
        MENS_WOMENS, //1
        //Men and Women play separately
        MENS, //2
        WOMENS, //3
        BLIND_DRAW//4
        //coed blind draw
    }
    public enum CostType
    {
        PER_TEAM, //0
        PER_PERSON //1
    }
    public enum TournamentStyle
    {
        FUN, //0
        COMPETITIVE, //1
        BOTH,//2
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
        public TournamentStyle Style { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Prize { get; set; }
        public string Host { get; set; } = string.Empty;
    }
}