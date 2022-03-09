using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Server.Context;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Domain.Models;

namespace SistemaLocadora.Server.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly LocadoraContext _context;
        private readonly IMapper _mapper;

        public ClienteRepository(LocadoraContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IQueryable<Cliente> Select()
        {
            IQueryable<Cliente> query = _context.cliente.AsNoTracking();
            return query;
        }

        public Cliente Add(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public Cliente Update(Cliente cliente)
        {
            _context.Update(cliente);
            _context.SaveChanges();

            return cliente;
        }

        public Cliente Delete(Cliente cliente)
        {
            _context.Remove(cliente);
            _context.SaveChanges();

            return cliente;
        }
    }
}
