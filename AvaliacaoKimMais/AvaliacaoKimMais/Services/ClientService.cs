using AvaliacaoKimMais.DTO;
using AvaliacaoKimMais.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaliacaoKimMais.Services
{
    public class ClientService : IClientService
    {
        public IEnumerable<ClientDTO> GetClientsOrderByName(IEnumerable<ClientDTO> clients)
        {
            return clients.OrderBy(p => p.Nome);
        }
        public ClientDTO GetClientById(IEnumerable<ClientDTO> clients, int Id)
        {
            return clients.FirstOrDefault(p => p.Id == Id);
        }

        public ClientDTO GetClientsByCPF(IEnumerable<ClientDTO> clients, string CPF)
        {
            var client = clients.FirstOrDefault(p => p.CPF.Replace(".","").Replace("-","") == CPF.Replace(".", "").Replace("-", ""));

            if (client is not null)
            {
                client.salario = Math.Round(client.salario * (decimal)0.3, 2);
            }
            return client;
        }
    }
}
