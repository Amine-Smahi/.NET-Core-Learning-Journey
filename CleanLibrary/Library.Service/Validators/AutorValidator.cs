using FluentValidation;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Service.Validators
{
    public class AutorValidator : AbstractValidator<Autor>
    {
        public AutorValidator()
        {
            RuleFor(a => a)
                   .NotNull()
                   .OnAnyFailure(x =>
                   {
                       throw new ArgumentNullException("Autor não foi encontrado");
                   });

            RuleFor(l => l.Nome)
                    .NotEmpty().WithMessage("É necessario informar o Nome")
                    .NotNull().WithMessage("É necessario informar o Nome");

            RuleFor(l => l.DataCadastro)
                    .NotNull().WithMessage("É necessario informar a Data de Cadastro");
        }
    }
}
