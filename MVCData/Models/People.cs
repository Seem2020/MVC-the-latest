﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCData.Models
{
    public class People
    {
        [Required]      
        [Display(Name = "StudentName")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        public int Telephone { get; set; }

        [Key]
        [Required]
        public int PersonId { get; set; }        
    }
}
