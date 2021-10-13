using Projeto_Sprint5.Data.Dtos.Cidade;
using System;

namespace Projeto_Sprint5.Data.Dtos.Cliente
{
    public class LerClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int CidadeId { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public LerCidadeDto ResidenteDe { get; set; }
    }
}
