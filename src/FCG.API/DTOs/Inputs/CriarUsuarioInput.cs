using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCG.API.DTOs.Inputs
{
    public class CriarUsuarioInput
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
    }
}