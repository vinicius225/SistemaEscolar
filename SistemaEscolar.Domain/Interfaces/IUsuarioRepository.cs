using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<int> AdicionarAsync(Usuario usuario);
        Task AtualizarAssync(Usuario usuario);
        Task DeletarAssync(int id);
        Task<IEnumerable<Usuario>> ListarUsuarios();
        Task<Usuario> ListarUsuarioPorId(int id);
    }
}
