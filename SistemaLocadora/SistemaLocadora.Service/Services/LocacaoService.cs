using AutoMapper;
using Microsoft.EntityFrameworkCore;

using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Domain.Models;
using SistemaLocadora.Service.Policies.Interfaces;
using SistemaLocadora.Service.Services.Interfaces;
using SistemaLocadora.Shared.DTOs;

namespace SistemaLocadora.Service.Services
{
    public class LocacaoService: ILocacaoService
    {
        private readonly ILocacaoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IDataDevolucaoPolicy _dataDevolucaoPolicy;

        public LocacaoService(ILocacaoRepository repository, IMapper mapper, IDataDevolucaoPolicy dataDevolucaoPolicy)
        {
            _repository = repository;
            _mapper = mapper;
            _dataDevolucaoPolicy = dataDevolucaoPolicy;
        }

        public async Task<IEnumerable<LocacaoDTO>> GetAll()
        {
            IQueryable<Locacao> query = _repository.Select();
            IEnumerable<Locacao> locacaos = await query.ToListAsync();
            IEnumerable<LocacaoDTO> locacaosDTO = _mapper.Map<IEnumerable<LocacaoDTO>>(locacaos);

            return locacaosDTO;
        }

        public async Task<LocacaoDTO> GetById(int id)
        {
            IQueryable<Locacao> query = _repository.Select();
            Locacao? locacao = await query.FirstOrDefaultAsync(cli => cli.Id == id);
            LocacaoDTO locacaoDTO = new LocacaoDTO();

            if (locacao is null)
                throw new Exception("Locacao não existe.");

            locacaoDTO = _mapper.Map<LocacaoDTO>(locacao);
            return locacaoDTO;
        }

        public async Task<LocacaoDTO> Add(LocacaoDTO locacaoDTO)
        {
            try
            {
                locacaoDTO.DataDevolucao = await _dataDevolucaoPolicy.ReturnDataDevolucao(locacaoDTO);
                Locacao locacao = _mapper.Map<Locacao>(locacaoDTO);

                locacao = _repository.Add(locacao);
                return _mapper.Map<LocacaoDTO>(locacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<LocacaoDTO> Update(int id, LocacaoDTO locacaoDTO)
        {
            try
            {
                if (!await LocacaoExist(id))
                    throw new Exception("Locacao não encontrado.");

                locacaoDTO.DataDevolucao = await _dataDevolucaoPolicy.ReturnDataDevolucao(locacaoDTO);

                Locacao locacao = _mapper.Map<Locacao>(locacaoDTO);
                locacao = _repository.Update(locacao);

                return _mapper.Map<LocacaoDTO>(locacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private async Task<bool> LocacaoExist(int id)
        {
            try
            {
                LocacaoDTO locacaoDTO = await GetById(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<LocacaoDTO> Delete(int id)
        {
            try
            {
                LocacaoDTO locacaoDTO = await GetById(id);

                Locacao locacao = _mapper.Map<Locacao>(locacaoDTO);
                locacao = _repository.Delete(locacao);

                return _mapper.Map<LocacaoDTO>(locacao);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
