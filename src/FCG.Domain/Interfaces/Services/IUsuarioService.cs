using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCG.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task CriarUsuario(string nome, string email, string senha);
    }
}