using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Domain.Models;
using SistemaLocadora.Service.Services.Interfaces.ReportServices;
using SistemaLocadora.Shared.DTOs;

namespace SistemaLocadora.Service.Services.ReportServices
{
    public class ClienteServiceReport : IClienteServiceReport
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteServiceReport(ILocacaoRepository locacaoRepository, IClienteRepository clienteRepository, IMapper mapper)
        {
            _locacaoRepository = locacaoRepository;
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClienteDTO>> ClientesEmAtraso()
        {
            try
            {
                IQueryable<Locacao> query = _locacaoRepository.Select();
                IEnumerable<Cliente> clientesAtrasados = await query.Where(locacao => locacao.DataDevolucao < DateTime.Now.Date).Select(locacao => locacao.Cliente).Distinct().ToListAsync();
                IEnumerable<ClienteDTO> clientesAtrasadosDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientesAtrasados);

                return clientesAtrasadosDTO;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<ClienteDTO> SegundoClienteQueMaisAlugou()
        {
            try
            {
                IQueryable<Locacao> query = _locacaoRepository.Select();
                //var result = from locacao in _locacaoRepository.Select()
                //             join cliente in _clienteRepository.Select()
                //             on locacao.ClienteId equals cliente.Id
                //             group locacao by locacao.ClienteId into grouping
                //             select new { Id = cliente.Id, Nome = cliente.Nome };

                var result = from locacao in _locacaoRepository.Select()
                             group locacao by locacao.Cliente into grouping
                             select new { Id = grouping.Key.Id, Nome = grouping.Key.Nome, Count = grouping.Key.Locacoes.Count() };

                var clientes = result.ToListAsync();

                throw new NotImplementedException();
                        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
