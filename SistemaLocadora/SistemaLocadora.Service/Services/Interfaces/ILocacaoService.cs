using SistemaLocadora.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Service.Services.Interfaces
{
    public interface ILocacaoService
    {
        Task<IEnumerable<LocacaoDTO>> GetAll();
        Task<LocacaoDTO> GetById(int id);

        Task<LocacaoDTO> Add(LocacaoDTO locacaoDTO);
        Task<LocacaoDTO> Update(int id, LocacaoDTO locacaoDTO);
        Task<LocacaoDTO> Delete(int id);
    }
}
