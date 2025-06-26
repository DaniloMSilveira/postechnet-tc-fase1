using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FCG.Domain.Entities;
using FCG.Domain.Exceptions;

namespace FCG.UnitTests.Entities
{
    public class UsuarioTests
    {
        private string _nome;
        private string _email;
        private string _senha;

        public UsuarioTests()
        {
            var faker = new Faker();
            _nome = faker.Name.FullName();
            _email = faker.Internet.Email();
            _senha = faker.Internet.Password() + "Aa1!"; // Atribuindo caracteres necessários da validação
        }

        [Theory(DisplayName = "Validando nome do usuário - obrigatório")]
        [Trait("Categoria", "Usuario")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Usuario_ValidarNome_Obrigatorio(string nome)
        {
            // Arrange & Act
            var result = Assert.Throws<DomainException>(() =>
                new Usuario(nome, _email, _senha));

            // Assert
            Assert.Equal("Nome é um campo obrigatório.", result.Message);
        }

        [Fact(DisplayName = "Validando nome do usuário - tamanho máximo")]
        [Trait("Categoria", "Usuario")]
        public void Usuario_ValidarNome_TamanhoMaximo()
        {
            // Arrange & Act
            var nomeInvalido = _nome.PadRight(256, 'a');
            var result = Assert.Throws<DomainException>(() =>
                new Usuario(nomeInvalido, _email, _senha));

            // Assert
            Assert.Equal("Nome deve ter até 255 caracteres.", result.Message);
        }

        [Theory(DisplayName = "Validando e-mail do usuário - obrigatório")]
        [Trait("Categoria", "Usuario")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Usuario_ValidarEmail_Obrigatorio(string email)
        {
            // Arrange & Act
            var result = Assert.Throws<DomainException>(() =>
                new Usuario(_nome, email, _senha));

            // Assert
            Assert.Equal("Email é um campo obrigatório.", result.Message);
        }

        [Fact(DisplayName = "Validando e-mail do usuário - tamanho máximo")]
        [Trait("Categoria", "Usuario")]
        public void Usuario_ValidarEmail_TamanhoMaximo()
        {
            // Arrange & Act
            var emailInvalido = _email.PadLeft(101, 'a');
            var result = Assert.Throws<DomainException>(() =>
                new Usuario(_nome, emailInvalido, _senha));

            // Assert
            Assert.Equal("Email deve ter até 100 caracteres.", result.Message);
        }

        [Theory(DisplayName = "Validando e-mail do usuário - inválido")]
        [Trait("Categoria", "Usuario")]
        [InlineData("emailinvalido")]
        [InlineData("emailinvalido@invalido")]
        [InlineData("emailinvalido@invalido.")]
        [InlineData("emailinvalido@invalidocom")]
        [InlineData("emailinvalidoinvalido.com")]
        [InlineData("@invalido.com")]
        public void Usuario_ValidarEmail_Invalido(string email)
        {
            // Arrange & Act
            var result = Assert.Throws<DomainException>(() =>
                new Usuario(_nome, email, _senha));

            // Assert
            Assert.Equal("Email inválido.", result.Message);
        }

        [Theory(DisplayName = "Validando senha do usuário - obrigatório")]
        [Trait("Categoria", "Usuario")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Usuario_ValidarSenha_Obrigatorio(string senha)
        {
            // Arrange & Act
            var result = Assert.Throws<DomainException>(() =>
                new Usuario(_nome, _email, senha));

            // Assert
            Assert.Equal("Senha é um campo obrigatório.", result.Message);
        }

        [Fact(DisplayName = "Validando senha do usuário - tamanho máximo")]
        [Trait("Categoria", "Usuario")]
        public void Usuario_ValidarSenha_TamanhoMaximo()
        {
            // Arrange & Act
            var senhaInvalida = _senha.PadRight(41, 'a');
            var result = Assert.Throws<DomainException>(() =>
                new Usuario(_nome, _email, senhaInvalida));

            // Assert
            Assert.Equal("Senha deve ter até 40 caracteres.", result.Message);
        }

        [Theory(DisplayName = "Validando senha do usuário - senha forte")]
        [Trait("Categoria", "Usuario")]
        [InlineData("adsf")]
        [InlineData("12345678")]
        [InlineData("asdfadsf")]
        [InlineData("asdf5678")]
        [InlineData("asdf5678@")]
        [InlineData("Asdf5678")]
        public void Usuario_ValidarSenha_SenhaForte(string senha)
        {
            // Arrange & Act
            var result = Assert.Throws<DomainException>(() =>
                new Usuario(_nome, _email, senha));

            // Assert
            Assert.Equal("Senha deve se enquadrar nos requisitos de segurança (mínimo 8 caracteres, uma letra maiúscula, " +
                        "uma letra minúscula, um número e um caracter especial).", result.Message);
        }

        [Fact(DisplayName = "Validando usuário - válido")]
        [Trait("Categoria", "Usuario")]
        public void Usuario_ValidarUsuario_Valido()
        {
            // Arrange & Act
            var usuario = new Usuario(_nome, _email, _senha);

            // Assert
            Assert.NotNull(usuario);
            Assert.Equal(_nome, usuario.Nome);
            Assert.Equal(_email, usuario.Email);
            Assert.Equal(_senha, usuario.Senha);
        }
    }
}
