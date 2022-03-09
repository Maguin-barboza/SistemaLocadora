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

                IEnumerable<Cliente> clientesAtrasados = await query.Where(locacao => locacao.DataDevolucao < DateTime.Now.Date)
                                                                    .Select(locacao => locacao.Cliente).Distinct().ToListAsync();
                IEnumerable<ClienteDTO> clientesAtrasadosDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientesAtrasados);

                return clientesAtrasadosDTO;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public  Task<ClienteDTO> SegundoClienteQueMaisAlugou()
        {
            throw new NotImplementedException();
        }
    }
}
