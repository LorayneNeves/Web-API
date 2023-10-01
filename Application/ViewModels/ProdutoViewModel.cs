using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int Codigo { get;  set; }
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public bool Ativo { get;  set; }
        public decimal Valor { get;  set; }
        public DateTime Data { get;  set; }
        public string Imagem { get;  set; }
        public int QuantidadeEstoque { get;  set; }

    }
}
