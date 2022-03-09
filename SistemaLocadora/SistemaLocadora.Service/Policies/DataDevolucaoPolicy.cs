using SistemaLocadora.Service.Policies.Interfaces;
using SistemaLocadora.Service.Services.Interfaces;
using SistemaLocadora.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Service.Policies
{
    public class DataDevolucaoPolicy : IDataDevolucaoPolicy
    {
        private readonly IFilmeService _service;

        public DataDevolucaoPolicy(IFilmeService service)
        {
            _service = service;
        }
        
        public async Task<DateTime> ReturnDataDevolucao(LocacaoDTO locacaoDTO)
        {
            try
            {
                FilmeDTO filmeDTO = await BuscarFilme(locacaoDTO.FilmeId);

                if (filmeDTO.Lancamento)
                    return locacaoDTO.DataLocacao.Value.AddDays(2);
                else
                    return locacaoDTO.DataLocacao.Value.AddDays(3);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private async Task<FilmeDTO> BuscarFilme(int id)
        {
            try
            {
                FilmeDTO filmeDTO = await _service.GetById(id);
                return filmeDTO;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
