using AutoMapper;
using SistemaLocadora.Domain.Models;
using SistemaLocadora.Shared.DTOs;

namespace SistemaLocadora.Server.Controllers.Mapper
{
    public class LocadoraProfile: Profile
    {
        public LocadoraProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Filme, FilmeDTO>().ForMember(dest => dest.Lancamento,
                                         opt => opt.MapFrom(src => src.Lancamento == 1 ? true : false)).ReverseMap();

            CreateMap<Locacao, LocacaoDTO>().ForMember(dest => dest.ClienteNome,
                                                       opt => opt.MapFrom(src => src.Cliente.Nome))
                                            .ForMember(dest => dest.FilmeTitulo,
                                                       opt => opt.MapFrom(src => src.Filme.Titulo));
            CreateMap<LocacaoDTO, Locacao>();
        }
    }
}
