using SistemaLocadora.Domain.Models;

namespace SistemaLocadora.Domain.Interfaces.Repositories
{
    public interface ILocacaoRepository
    {
        IQueryable<Locacao> Select();

        Locacao Add(Locacao locacao);
        Locacao Update(Locacao locacao);
        Locacao Delete(Locacao locacao);
    }
}
