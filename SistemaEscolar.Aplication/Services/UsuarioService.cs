using SistemaEscolar.Aplication.Interfaces;
using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Aplication.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            usuario.Senha = GerarSenhaToken(usuario.Senha);
            int idUsuario =await _usuarioRepository.AdicionarAsync(usuario); 

        }

        public Task AtualizarAssync(Usuario usuario)
        {
            usuario.Senha = GerarSenhaToken(usuario.Senha);
            _usuarioRepository.AtualizarAssync(usuario);
            return Task.CompletedTask;
        }

        public Task DeletarAssync(int id)
        {
            _usuarioRepository.DeletarAssync(id);
            return Task.CompletedTask;
        }

        public string GerarSenhaToken(string senha)
        {
            byte[] senhaBytes = Encoding.ASCII.GetBytes(senha) ;
            byte[] salt = Encoding.ASCII.GetBytes("MelhsorAppDo Brasilhv");
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[senhaBytes.Length + salt.Length];

            for (int i = 0; i < senhaBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = senhaBytes[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[senhaBytes.Length + i] = salt[i];
            }

            return Encoding.ASCII.GetString(algorithm.ComputeHash(plainTextWithSaltBytes));
        }

        public  Task<Usuario> ListarUsuarioPorId(int id)
        {
            return _usuarioRepository.ListarUsuarioPorId(id);

        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return await _usuarioRepository.ListarUsuarios();
        }
    }
}
