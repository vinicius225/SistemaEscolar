using SistemaEscolar.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace SisatemaEscolar.API.Models
{
    public class UsuarioViewModel : AbstractModel<Usuario>
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Senha { get; set; }
        [Required]

        public DateTime DataNascimento { get; set; }
        public string Contato { get; set; }
        public string Endereco { get; set; }
        public string NumeroEndereco { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public bool Status { get; set; }
        public int[] Perfis { get; set; }

        public override void GetEntitie(Usuario entity)
        {
            this.Id = entity.Id;
            this.Nome = entity.Nome;
            this.Email = entity.Email;
            this.Senha = entity.Senha;
            this.DataNascimento = entity.DataNascimento;
            this.Contato = entity.Contato;
            this.Endereco = entity.Endereco;
            this.NumeroEndereco = entity.NumeroEndereco;
            this.CEP = entity.CEP;
            this.Estado = entity.Estado;
            this.Cidade = entity.Cidade;
            this.Status = entity.Status;
            foreach(var item in  entity.Perfil)
            {
                this.Perfis.Append(item.Id);
            }
        }

        public override void SetEntitie(Usuario entity)
        {
            entity.Id = this.Id;
            entity.Nome = this.Nome;
            entity.Email = this.Email;
            entity.Senha = this.Senha;
            entity.DataNascimento= this.DataNascimento;
            entity.Contato = this.Contato;
            entity.Endereco= this.Endereco;
            entity.NumeroEndereco= this.NumeroEndereco;
            entity.CEP = this.CEP;
            entity.Estado = this.Estado;
            entity.Cidade = this.Cidade;
            entity.Status = this.Status;
            foreach (var item in this.Perfis) 
            {
                entity.Perfil.Add(
                    new Perfil
                    {
                        Id = item
                    }
                    ) ;
            }
        }
    }
}
