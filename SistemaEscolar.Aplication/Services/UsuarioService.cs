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

        public Task AdicionarAsync(Usuario usuario)
        {
            _usuarioRepository.AdicionarAsync(usuario); 
            return Task.CompletedTask;
        }

        public Task AtualizarAssync(Usuario usuario)
        {
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
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha) ;
            byte[] salt = Encoding.UTF8.GetBytes("MelhsorAppDo Brasilhv");
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

            return Encoding.UTF8.GetString(algorithm.ComputeHash(plainTextWithSaltBytes));
        }

        public  Task<Usuario> ListarUsuarioPorId(int id)
        {
            return _usuarioRepository.ListarUsuarioPorId(id);

        }

        public Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return _usuarioRepository.ListarUsuarios();
        }
    }
}
