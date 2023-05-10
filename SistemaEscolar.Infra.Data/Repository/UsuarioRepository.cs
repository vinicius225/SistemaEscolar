using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;

namespace SistemaEscolar.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConectionFactory _conectionFactory;

        public UsuarioRepository(IConectionFactory conectionFactory)
        {
            _conectionFactory = conectionFactory;
        }

        public Task AdicionarAsync(Usuario usuario)
        {
            using (var conn = new SqlConnection(_conectionFactory.ConectionDb()))
            {
                conn.Open();
                string query = $@"insert into Usuario values = (
                                '{usuario.Nome}',
                                '{usuario.Email}',
                                '{usuario.Senha}',
                                '{usuario.DataNascimento}',
                                '{usuario.Contato}',
                                '{usuario.Endereco}',
                                '{usuario.NumeroEndereco}',
                                '{usuario.CEP}',
                                '{usuario.Estado}',
                                '{usuario.Cidade}',
                                '{usuario.Status}')
)";
                conn.ExecuteAsync(query);
            }
            
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
