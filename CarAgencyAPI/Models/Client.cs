using System;
using System.Text.Json.Serialization;

namespace CarAgencyAPI.Models
{
    public class Client
    {
        public int Id { get; set; } 

        public uint DNI { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public DateTime LastUpdate { get; set; }

    }
}

