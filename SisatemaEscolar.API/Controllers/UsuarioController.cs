using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaEscolar.Aplication.Interfaces;
using SistemaEscolar.Domain.Entities;

namespace SisatemaEscolar.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Route("listar")]
        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            return Ok( await _usuarioService.ListarUsuarios());
        }
        [Route("cadastrar")]
        [HttpPost]
        public async Task<IActionResult> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                return Ok( _usuarioService.AdicionarAsync(usuario));
            }
            catch (Exception ex)
            {
                return Problem("Erro no servidor, tente mais tarde");
            }
        }
    }
}
