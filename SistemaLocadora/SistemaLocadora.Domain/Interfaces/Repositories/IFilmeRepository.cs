using SistemaLocadora.Domain.Models;

namespace SistemaLocadora.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        IQueryable<Filme> Select();

        Filme Add(Filme filme );
        Filme Update(Filme filme );
        Filme Delete(Filme filme );
    }
}
