using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FCG.API.DTOs.Inputs;
using FCG.Domain.Entities;
using FCG.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FCG.API.Controllers
{
    [Route("usuario")]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost(Name = "CriarUsuario")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioInput input)
        {
            await _usuarioService.CriarUsuario(input.Nome, input.Email, input.Senha);

            return Created();
        }
    }
}