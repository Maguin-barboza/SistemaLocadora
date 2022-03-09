using SistemaLocadora.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Service.Services.Interfaces.ReportServices
{
    public interface IClienteServiceReport
    {
        Task<IEnumerable<ClienteDTO>> ClientesEmAtraso();
        Task<ClienteDTO> SegundoClienteQueMaisAlugou();
    }
}
