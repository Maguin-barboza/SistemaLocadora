using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Server.Context;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Domain.Models;

namespace SistemaLocadora.Server.Repositories
{
    public class FilmeRepository: IFilmeRepository
    {
        private readonly LocadoraContext _context;

        public FilmeRepository(LocadoraContext context)
        {
            _context = context;
        }
        public IQueryable<Filme> Select()
        {
            IQueryable<Filme> query = _context.filme.AsNoTracking();
            return query;
        }

        public Filme Add(Filme filme)
        {
            _context.Add(filme);
            _context.SaveChanges();

            return filme;
        }

        public Filme Update(Filme filme)
        {
            _context.Update(filme);
            _context.SaveChanges();

            return filme;
        }

        public Filme Delete(Filme filme)
        {
            _context.Remove(filme);
            _context.SaveChanges();

            return filme;
        }
    }
}
