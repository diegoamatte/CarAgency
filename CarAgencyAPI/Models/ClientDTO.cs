using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarAgencyAPI.Models
{
    public class ClientDTO
    {
        public uint DNI { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public Client ToClient()
        {
            var newClient = new Client();
            newClient.DNI = DNI;
            newClient.Name = Name;
            newClient.Surname = Surname;
            newClient.PhoneNumber = PhoneNumber;
            newClient.Address = Address;
            newClient.City = City;
            newClient.State = State;
            newClient.ZipCode = ZipCode;
            return newClient;
        }
    }
}
