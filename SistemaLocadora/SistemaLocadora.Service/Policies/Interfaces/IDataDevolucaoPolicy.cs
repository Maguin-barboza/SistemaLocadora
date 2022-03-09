using SistemaLocadora.Shared.DTOs;

namespace SistemaLocadora.Service.Policies.Interfaces
{
    public interface IDataDevolucaoPolicy
    {
        Task<DateTime> ReturnDataDevolucao(LocacaoDTO locacaoDTO);
    }
}
