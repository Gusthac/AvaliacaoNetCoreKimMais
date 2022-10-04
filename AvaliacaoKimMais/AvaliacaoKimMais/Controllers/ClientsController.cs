using AvaliacaoKimMais.DTO;
using AvaliacaoKimMais.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AvaliacaoKimMais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("orderbyname")]
        [ProducesResponseType((200), Type = typeof(DataDTO))]
        [ProducesResponseType(400)]
        public ActionResult<DataDTO> ClientOrderByName([FromBody] DataDTO list)
        {
            if (list.Clientes == null)
            {
                return BadRequest();
            }

            list.Clientes = _clientService.GetClientsOrderByName(list.Clientes).ToArray();
            return Ok(list);
        }

        [HttpPost]
        [Route("filterbyid/{id}")]
        [ProducesResponseType((200), Type = typeof(ClientDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ClientDTO> ClienteFilterById(int id, [FromBody] DataDTO list)
        {
            if (list.Clientes == null)
            {
                return BadRequest();
            }

            var client = _clientService.GetClientById(list.Clientes, id);
            if (client is null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        [Route("filterbyCPF/{CPF}")]
        [ProducesResponseType((200), Type = typeof(ClientDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<ClientDTO> ClienteFilterByCPF(string CPF, [FromBody] DataDTO list)
        {
            if (list.Clientes == null)
            {
                return BadRequest();
            }

            var client = _clientService.GetClientsByCPF(list.Clientes, CPF);
            if (client is null)
            {
                return NotFound();
            }
            return Ok(client);
        }
    }
}
