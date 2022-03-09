using SistemaLocadora.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaLocadora.Service.Services.Interfaces
{
    public interface IFilmeService
    {
        Task<IEnumerable<FilmeDTO>> GetAll();
        Task<FilmeDTO> GetById(int id);

        FilmeDTO Add(FilmeDTO filmeDTO);
        Task<FilmeDTO> Update(int id, FilmeDTO filmeDTO);
        Task<FilmeDTO> Delete(int id);
    }
}
