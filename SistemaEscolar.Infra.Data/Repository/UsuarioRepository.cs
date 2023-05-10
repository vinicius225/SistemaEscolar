using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Infra.Data.Repository
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        public Task AdicionarAsync(Usuario usuario)
        {
            var conn = (using SqlConnection)
            throw new NotImplementedException();
        }

        public Task AtualizarAssync(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task DeletarAssync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
