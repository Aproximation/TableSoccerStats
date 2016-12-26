using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSoccerStats.Models
{
    public class NewGameInfo
    {
        public int GameId { get; set; }
        [Required]
        [Display(Name = "Match Date")]
        public DateTime DatePlayed { get; set; }
        [Required]
        [Display(Name = "Team 1 points")]
        [Range(0, 10, ErrorMessage = "Only values between 0-10 are allowed")]
        public int Team12Points { get; set; }
        [Required]
        [Display(Name = "Team 2 points")]
        [Range(0, 10, ErrorMessage = "Only values between 0-10 are allowed")]
        [MatchPointsValidation("Team12Points")]
        public int Team34Points { get; set; }
        [Required]
        [Display(Name = "Team 1, player A")]
        public int Player1A { get; set; }
        [Display(Name = "Team 1, player B")]
        public int Player1B { get; set; }
        [Required]
        [Display(Name = "Team 2, player A")]
        public int Player2A { get; set; }
        [Display(Name = "Team 2, player B")]
        public int Player2B { get; set; }
    }
}