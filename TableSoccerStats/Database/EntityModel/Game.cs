using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSoccerStats.Database.EntityModel
{
    public class Game
    {
        public int GameId { get; set; }
        [Required]
        [Display(Name = "Match Date")]
        public DateTime  DatePlayed { get; set; }
        [Required]
        [Display(Name = "Team 1 points")]
        public int Team12Points { get; set; }
        [Required]
        [Display(Name = "Team 2 points")]
        public int Team34Points { get; set; }
        
        [Display(Name = "Team 1, player A")]
        public virtual Player Player1A { get; set; }
        [Display(Name = "Team 1, player B")]
        public virtual Player Player1B { get; set; }
        
        [Display(Name = "Team 2, player A")]
        public virtual Player Player2A { get; set; }
        [Display(Name = "Team 2, player B")]
        public virtual Player Player2B { get; set; }
    }
}