using SistemaEscolar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Aplication.Interfaces
{
    public interface IUsuarioService
    {
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAssync(Usuario usuario);
        Task DeletarAssync(int id);
    }
}
