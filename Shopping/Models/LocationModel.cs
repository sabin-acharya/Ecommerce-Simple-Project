﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping.Models
{
    public class LocationModel
    {
        public int Id { get; set; }

        [Required] 
        public string? CustomerName { get; set; }
        [Required]
        public long FloorNo {  get; set; }

        [Required]
        public string? StreetName { get; set; }

        [Required]
        public string? City { get; set; }

        [Required]
        public string? State { get; set; }

        [Required]
        public long PinCode { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public double PhoneNumber { get; set; }
       
       
    }
}
