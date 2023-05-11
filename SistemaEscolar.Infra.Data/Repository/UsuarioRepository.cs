using SistemaEscolar.Domain.Entities;
using SistemaEscolar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace SistemaEscolar.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConectionFactory _conectionFactory;

        public UsuarioRepository(IConectionFactory conectionFactory)
        {
            _conectionFactory = conectionFactory;
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            try
            {
                using (var conn = new SqlConnection(_conectionFactory.ConectionDb()))
                {
                    conn.Open();
                    string query = $@"insert into Usuario (Nome, Senha, DataNascimento,
                                    Contato,Endereco,  NumeroEndereco, CEP, Estado, Cidade, Status ) values  (
                                '{usuario.Nome}',
                                '{usuario.Senha}',
                                '{usuario.DataNascimento}',
                                '{usuario.Contato}',
                                '{usuario.Endereco}',
                                '{usuario.NumeroEndereco}',
                                '{usuario.CEP}',
                                '{usuario.Estado}',
                                '{usuario.Cidade}',
                                '{usuario.Status}')
";
                    await conn.ExecuteAsync(query);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task AtualizarAssync(Usuario usuario)
        {
            using (var conn = new SqlConnection(_conectionFactory.ConectionDb()))
            {
                conn.Open();
                string query = $@"update Usuario set Nome ='{usuario.Nome}',
                                Email = '{usuario.Email}',
                                Senha ='{usuario.Senha}',
                                DataNascimento ='{usuario.DataNascimento}',
                                Contato = '{usuario.Contato}',
                                Endereco = '{usuario.Endereco}',
                                NumeroEndereco = '{usuario.NumeroEndereco}',
                                CEP = '{usuario.CEP}',
                                Estado = '{usuario.Estado}',
                                Cidade = '{usuario.Cidade}',
                                Status = '{usuario.Status}')
)";
                conn.ExecuteAsync(query);
            }
        }

        public Task DeletarAssync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> ListarUsuarioPorId(int id)
        {
            using (var conn = new SqlConnection(_conectionFactory.ConectionDb()))
            {
                string sql = @$"select * from Usuario where Id = {id}";

                return conn.QueryAsync<Usuario>(sql).Result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            using (var conn = new SqlConnection(_conectionFactory.ConectionDb()))
            {
                string sql = @$"select * from Usuario ";

                return conn.QueryAsync<Usuario>(sql).Result;
            }
        }
    }
}
