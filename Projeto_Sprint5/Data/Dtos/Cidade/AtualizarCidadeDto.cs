using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Sprint5.Data.Dtos.Cidade
{
    public class AtualizarCidadeDto
    {
        public string Nome { get; set; }
        public string Estado { get; set; }
    }

    public class AtualizarCidadeDtoValidator : AbstractValidator<AtualizarCidadeDto>
    {
        public AtualizarCidadeDtoValidator()
        {
            RuleFor(c => c.Nome).NotEmpty().WithMessage("O nome é um campo obrigatório");
            RuleFor(c => c.Estado).NotEmpty().WithMessage("O estado é um campo obrigatório");
        }
    }
}
