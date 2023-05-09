using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEscolar.Infra.Data
{
    public class ConectionFactory : IConectionFactory
    {
        private readonly IConfiguration configuration;

        public ConectionFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ConectionDb()
        {
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}
