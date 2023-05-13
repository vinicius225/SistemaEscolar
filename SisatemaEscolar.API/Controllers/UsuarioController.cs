using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SisatemaEscolar.API.Models;
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
        public async Task<IActionResult> CadastrarUsuario(UsuarioViewModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario obj = new Usuario();
                    usuario.SetEntitie(obj);
                    await _usuarioService.AdicionarAsync(obj);
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return Problem("Erro no servidor, tente mais tarde");
            }
        }
    }
}
