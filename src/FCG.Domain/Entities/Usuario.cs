using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCG.Domain.Exceptions;
using FCG.Domain.Helpers;

namespace FCG.Domain.Entities
{
    public class Usuario : EntityBase
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime? ModificadoEm { get; private set; }

        protected Usuario() { }

        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            CriadoEm = DateTime.Now;

            ValidarEntidade();
        }

        public void AlterarNome(string nome)
        {
            Nome = nome;
            ModificadoEm = DateTime.Now;
        }

        public void AlterarSenha(string senha)
        {
            Senha = senha;
            ModificadoEm = DateTime.Now;
        }

        public void ValidarEntidade()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                throw new DomainException("Nome é um campo obrigatório.");

            if (ValidatorHelper.MaxLength(Nome, 255))
                throw new DomainException("Nome deve ter até 255 caracteres.");

            if (ValidatorHelper.NullOrEmpty(Email))
                throw new DomainException("Email é um campo obrigatório.");

            if (ValidatorHelper.MaxLength(Email, 100))
                throw new DomainException("Email deve ter até 100 caracteres.");

            if (!ValidatorHelper.ValidEmail(Email))
                throw new DomainException("Email inválido.");

            if (string.IsNullOrWhiteSpace(Senha))
                throw new DomainException("Senha é um campo obrigatório.");

            if (ValidatorHelper.MaxLength(Senha, 40))
                throw new DomainException("Senha deve ter até 40 caracteres.");

            if (!ValidatorHelper.ValidStrongPassword(Senha))
                throw new DomainException("Senha deve se enquadrar nos requisitos de segurança (mínimo 8 caracteres, uma letra maiúscula, " +
                        "uma letra minúscula, um número e um caracter especial).");
        }
    }
}