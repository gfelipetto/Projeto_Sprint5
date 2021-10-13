using AutoMapper;
using Projeto_Sprint5.Data.Dtos.Cidade;
using Projeto_Sprint5.Models;

namespace Projeto_Sprint5.Profiles
{
    public class CidadesProfile : Profile
    {
        public CidadesProfile()
        {
            CreateMap<Cidades, LerCidadeDto>();
            CreateMap<AtualizarCidadeDto, Cidades>();
        }
    }
}
