using System;
using System.ComponentModel.DataAnnotations;

namespace CarAgencyAPI.Models
{
    public class Client
    {
        public int Id { get; set; } 

        [Required]
        public uint DNI { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string ZipCode { get; set; }
        
        public DateTime LastUpdate { get; set; }

    }
}

