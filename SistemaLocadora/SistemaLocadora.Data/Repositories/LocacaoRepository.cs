using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Server.Context;
using SistemaLocadora.Domain.Models;
using SistemaLocadora.Domain.Interfaces.Repositories;

namespace SistemaLocadora.Server.Repositories
{
    public class LocacaoRepository: ILocacaoRepository
    {
        private readonly LocadoraContext _context;

        public LocacaoRepository(LocadoraContext context)
        {
            _context = context;
        }
        public IQueryable<Locacao> Select()
        {
            IQueryable<Locacao> query = _context.locacao.AsNoTracking();
            return query;
        }

        public Locacao Add(Locacao locacao)
        {
            _context.Add(locacao);
            _context.SaveChanges();

            return locacao;
        }

        public Locacao Update(Locacao locacao)
        {
            _context.Update(locacao);
            _context.SaveChanges();

            return locacao;
        }

        public Locacao Delete(Locacao locacao)
        {
            _context.Remove(locacao);
            _context.SaveChanges();

            return locacao;
        }
    }
}
