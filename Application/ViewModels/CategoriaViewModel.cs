using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class CategoriaViewModel
    {
        public Guid CodigoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
