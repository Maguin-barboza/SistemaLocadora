using SistemaLocadora.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Service.Services.Interfaces.ReportServices
{
    public interface IFilmeReportService
    {
        Task<IEnumerable<FilmeDTO>> FilmesNuncaAlugados();
        Task<IEnumerable<FilmeDTO>> Top5MaisAlugadosDoAno();
        Task<IEnumerable<FilmeDTO>> Top3MenosAlugadosUltimaSemana();
    }
}
