﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TableSoccerStats.Database.EntityModel
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Last name cannot be longer than 30 characters.")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Initials cannot be longer than 4 characters.")]
        public string Initials { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Created {get;set;}
    }
}