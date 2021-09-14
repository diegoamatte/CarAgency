using CarAgencyAPI.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarAgencyAPI.Data
{
    public class ClientCRUD : ICRUD<Client>
    {
        private DataManager<Client> _data;

        private IList<Client> _clientsList;

        public ClientCRUD(IConfiguration configuration)
        {
            _data = new DataManager<Client>(configuration["Paths:Clients"]);
            _clientsList = _data.ReadData();
        }

        public Client Create(Client client)
        {
            client.Id = _clientsList.LastOrDefault() is not null ? _clientsList.Last().Id +1 : 1;
            client.LastUpdate = DateTime.Now;
            _clientsList.Add(client);
            _data.SaveData(_clientsList);
            return client;
        }

        public void Delete(int id)
        {
            var clientToDelete = GetById(id);
            if(clientToDelete is not null)
            {
                _clientsList.Remove(clientToDelete);
                _data.SaveData(_clientsList);
            }
        }

        public Client GetById(int id)
        {
            return _clientsList.Where(client => client.Id == id).FirstOrDefault();
        }

        public IEnumerable<Client> GetAll()
        {
            return _clientsList.ToList().OrderBy(client => client.DNI);
        }

        public Client Update(Client client,int id)
        {
            client.LastUpdate = DateTime.Now;
            client.Id = id;
            var index = _clientsList.IndexOf(GetById(client.Id));
            _clientsList[index] = client;
            _data.SaveData(_clientsList);
            return client;
        }
    }
}
