using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Domain.Models;
using SistemaLocadora.Service.Services.Interfaces;
using SistemaLocadora.Shared.DTOs;

namespace SistemaLocadora.Service.Services
{
    public class FilmeService: IFilmeService
    {
        private readonly IFilmeRepository _repository;
        private readonly IMapper _mapper;

        public FilmeService(IFilmeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FilmeDTO>> GetAll()
        {
            IQueryable<Filme> query = _repository.Select();
            IEnumerable<Filme> filmes = await query.ToListAsync();
            IEnumerable<FilmeDTO> filmesDTO = _mapper.Map<IEnumerable<FilmeDTO>>(filmes);

            return filmesDTO;
        }

        public async Task<FilmeDTO> GetById(int id)
        {
            IQueryable<Filme> query = _repository.Select();
            Filme? filme = await query.FirstOrDefaultAsync(cli => cli.Id == id);
            FilmeDTO filmeDTO = new FilmeDTO();

            if (filme is null)
                throw new Exception("Filme não existe.");

            filmeDTO = _mapper.Map<FilmeDTO>(filme);
            return filmeDTO;
        }

        public FilmeDTO Add(FilmeDTO filmeDTO)
        {
            try
            {
                Filme filme = _mapper.Map<Filme>(filmeDTO);
                filme = _repository.Add(filme);

                return _mapper.Map<FilmeDTO>(filme);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<FilmeDTO> Update(int id, FilmeDTO filmeDTO)
        {
            try
            {
                if (!await FilmeExist(id))
                    throw new Exception("Filme não encontrado.");

                Filme filme = _mapper.Map<Filme>(filmeDTO);
                filme = _repository.Update(filme);

                return _mapper.Map<FilmeDTO>(filme);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> FilmeExist(int id)
        {
            try
            {
                FilmeDTO filmeDTO = await GetById(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<FilmeDTO> Delete(int id)
        {
            try
            {
                FilmeDTO filmeDTO = await GetById(id);

                Filme filme = _mapper.Map<Filme>(filmeDTO);
                filme = _repository.Delete(filme);

                return _mapper.Map<FilmeDTO>(filme);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
