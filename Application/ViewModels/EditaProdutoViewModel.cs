using Application.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class EditaProdutoViewModel
    {
        public string Nome { get; set; }
        public Guid CategoriaId { get; set; }
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório.")]
        [ValorProdutoValidation(ErrorMessage = "O valor do produto deve ser maior que zero.")]
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Imagem { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
