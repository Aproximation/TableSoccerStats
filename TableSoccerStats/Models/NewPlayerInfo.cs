using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSoccerStats.Models
{
    public class NewPlayerInfo
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Last name cannot be longer than 30 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}