using AutoMapper;
using Projeto_Sprint5.Data.Dtos.Cliente;
using Projeto_Sprint5.Models;

namespace Projeto_Sprint5.Profiles
{
    public class ClientesProfile: Profile
    {
        public ClientesProfile()
        {
            CreateMap<Clientes, LerClienteDto>();
            CreateMap<AtualizarClienteDto, Clientes>();
        }
    }
}
