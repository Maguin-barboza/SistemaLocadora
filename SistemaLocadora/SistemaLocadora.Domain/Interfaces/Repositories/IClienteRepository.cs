using SistemaLocadora.Domain.Models;

namespace SistemaLocadora.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        IQueryable<Cliente> Select();

        Cliente Add(Cliente cliente);
        Cliente Update(Cliente cliente);
        Cliente Delete(Cliente cliente);
    }
}
