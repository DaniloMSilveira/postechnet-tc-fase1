using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FCG.Domain.Entities;
using FCG.Domain.Interfaces.Repositories;
using FCG.Domain.Interfaces.Services;

namespace FCG.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CriarUsuario(string nome, string email, string senha)
        {
            var existeUsuario = await _unitOfWork.UsuarioRepository.ObterTodos();

            var usuario = new Usuario(nome, email, senha);

            _unitOfWork.UsuarioRepository.Adicionar(usuario);

            var success = await _unitOfWork.Commit();
            if (!success)
            {
                throw new Exception("Erro ao criar usuário (nenhuma linha afetada na transação SQL).");
            }
        }
    }
}