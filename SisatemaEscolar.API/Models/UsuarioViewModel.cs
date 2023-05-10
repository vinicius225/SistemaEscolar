using SistemaEscolar.Domain.Entities;

namespace SisatemaEscolar.API.Models
{
    public class UsuarioViewModel 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public bool Status { get; set; }
        public int[] Perfis { get; set; }


    }
}
