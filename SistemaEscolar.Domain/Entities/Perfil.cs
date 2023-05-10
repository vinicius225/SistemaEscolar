using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Domain.Entities
{
    public class Perfil
    {
        public int Id { get; set; }
        public int Nome { get; set; }
        public bool Status { get; set; }
    }
}
