using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace FCG.Application.DTOs.Inputs.Jogos
{
    public class AlterarJogoInput : BaseInput<AlterarJogoInput>
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string? Descricao { get; private set; }
        public string? Desenvolvedora { get; private set; }
        public DateTime? DataLancamento { get; private set; }
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }

        public AlterarJogoInput(string nome,
            string? descricao,
            string? desenvolvedora,
            DateTime? dataLancamento,
            decimal preco,
            bool ativo)
        {
            Nome = nome;
            Descricao = descricao;
            Desenvolvedora = desenvolvedora;
            DataLancamento = dataLancamento;
            Preco = preco;
            Ativo = ativo;
        }

        public void PreencherId(Guid id)
        {
            Id = id;
        }

        protected override IValidator<AlterarJogoInput> GetValidator()
        {
            return new AlterarJogoInputValidator();
        }
    }

    public class AlterarJogoInputValidator : AbstractValidator<AlterarJogoInput>
    {
        public AlterarJogoInputValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty()
                .WithMessage("Id é um campo obrigatório.");

            RuleFor(p => p.Id)
                .NotEqual(p => Guid.Empty)
                .WithMessage("Id é um campo obrigatório.");

            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("Nome é um campo obrigatório.");

            RuleFor(p => p.Nome)
                .MaximumLength(256)
                .WithMessage("Nome deve ter até 256 caracteres.")
                .When(p => !string.IsNullOrWhiteSpace(p.Nome));

            RuleFor(p => p.Descricao)
                .MaximumLength(1024)
                .WithMessage("Descricao deve ter até 1024 caracteres.")
                .When(p => !string.IsNullOrWhiteSpace(p.Descricao));

            RuleFor(p => p.Desenvolvedora)
                .MaximumLength(256)
                .WithMessage("Desenvolvedora deve ter até 256 caracteres.")
                .When(p => !string.IsNullOrWhiteSpace(p.Desenvolvedora));

            RuleFor(p => p.Preco)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Preco deve ser maior ou igual a zero.");
        }
    }
}