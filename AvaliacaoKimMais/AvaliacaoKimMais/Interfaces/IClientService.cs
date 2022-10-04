using AvaliacaoKimMais.DTO;
using System.Collections.Generic;

namespace AvaliacaoKimMais.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientDTO> GetClientsOrderByName(IEnumerable<ClientDTO> clients);
        ClientDTO GetClientById(IEnumerable<ClientDTO> clients, int Id);
        ClientDTO GetClientsByCPF(IEnumerable<ClientDTO> clients, string CPF);
    }
}
