using CarAgencyAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAgencyAPI.Data
{
    public class ClientCRUD : ICRUD<Client>
    {
        private readonly CarAgencyContext _context;

        public ClientCRUD(CarAgencyContext context)
        {
            _context = context;
        }

        public Client Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return client;
        }

        public void Delete(int id)
        {
            var client = GetById(id);
            if(client is not null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

        public Client GetById(int id)
        {
            return _context.Clients.Find(id);
        }

        public IEnumerable<Client> GetAll()
        {
            return _context.Clients.OrderBy(client => client.DNI);
        }

        public Client Update(Client client,int id)
        {
            var updatedClient = GetById(id);
            updatedClient.Address = client.Address;
            updatedClient.City = client.City;
            updatedClient.DNI = client.DNI;
            updatedClient.Name = client.Name;
            updatedClient.PhoneNumber = client.PhoneNumber;
            updatedClient.State = client.State;
            updatedClient.Surname = client.Surname;
            updatedClient.ZipCode = client.ZipCode;
            updatedClient.LastUpdate = DateTime.Now;
            _context.SaveChanges();
            return updatedClient;
        }
    }
}
