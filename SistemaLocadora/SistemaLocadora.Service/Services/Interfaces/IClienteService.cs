using SistemaLocadora.Shared.DTOs;

namespace SistemaLocadora.Service.Services.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> GetAll();
        Task<ClienteDTO> GetById(int id);

        ClienteDTO Add(ClienteDTO clienteDTO);
        Task<ClienteDTO> Update(int id, ClienteDTO clienteDTO);
        Task<ClienteDTO> Delete(int id);
    }
}
