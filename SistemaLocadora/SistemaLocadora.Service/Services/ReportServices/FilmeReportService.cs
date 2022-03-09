using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Domain.Models;
using SistemaLocadora.Service.Services.Interfaces.ReportServices;
using SistemaLocadora.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Service.Services.ReportServices
{
    public class FilmeReportService : IFilmeReportService
    {
        private readonly IFilmeRepository _repository;

        public FilmeReportService(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<FilmeDTO>> FilmesNuncaAlugados()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FilmeDTO>> Top3MenosAlugadosUltimaSemana()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FilmeDTO>> Top5MaisAlugadosDoAno()
        {
            throw new NotImplementedException();
        }
    }
}
