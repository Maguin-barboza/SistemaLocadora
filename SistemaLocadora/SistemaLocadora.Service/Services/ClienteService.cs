using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Domain.Models;
using SistemaLocadora.Service.Services.Interfaces;
using SistemaLocadora.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Service.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;

        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAll()
        {
            IQueryable<Cliente> query = _repository.Select();
            IEnumerable<Cliente> clientes = await query.ToListAsync();
            IEnumerable<ClienteDTO> clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            
            return clientesDTO;
        }

        public async Task<ClienteDTO> GetById(int id)
        {
            IQueryable<Cliente> query = _repository.Select();
            Cliente? cliente = await query.FirstOrDefaultAsync(cli => cli.Id == id);
            ClienteDTO clienteDTO = new ClienteDTO();

            if (cliente is null)
                throw new Exception("Cliente não existe.");

            clienteDTO = _mapper.Map<ClienteDTO>(cliente);
            return clienteDTO;
        }

        public ClienteDTO Add(ClienteDTO clienteDTO)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
                cliente = _repository.Add(cliente);

                return _mapper.Map<ClienteDTO>(cliente);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<ClienteDTO> Update(int id, ClienteDTO clienteDTO)
        {
            try
            {
                if (!await ClienteExist(id))
                    throw new Exception("Cliente não encontrado.");

                Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
                cliente = _repository.Update(cliente);

                return _mapper.Map<ClienteDTO>(cliente);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> ClienteExist(int id)
        {
            try
            {
                ClienteDTO clienteDTO = await GetById(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<ClienteDTO> Delete(int id)
        {
            try
            {
                ClienteDTO clienteDTO = await GetById(id);

                Cliente cliente = _mapper.Map<Cliente>(clienteDTO);
                cliente = _repository.Delete(cliente);

                return _mapper.Map<ClienteDTO>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
