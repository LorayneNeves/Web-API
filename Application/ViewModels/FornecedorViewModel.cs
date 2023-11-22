using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class FornecedorViewModel
    {
        public Guid CodigoId { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
    }
}
