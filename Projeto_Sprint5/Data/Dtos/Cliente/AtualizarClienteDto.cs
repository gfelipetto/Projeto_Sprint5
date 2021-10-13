using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sprint5.Data.Dtos.Cliente
{
    public class AtualizarClienteDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cep { get; set; }
    }

    public class AtualizarClienteDtoValidator : AbstractValidator<AtualizarClienteDto>
    {
        public AtualizarClienteDtoValidator()
        {
            RuleFor(c => c.Nome).NotNull().WithMessage("O nome é um campo obrigatório");
            RuleFor(c => c.DataNascimento).NotNull().WithMessage("A data de nascimento é um campo obrigatório");
            RuleFor(c => c.Cep).NotNull().WithMessage("O cep é um campo obrigatório e precisa ser válido");
        }
    }
}
