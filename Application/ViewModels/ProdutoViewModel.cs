﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid CodigoId { get; set; }
        public Guid CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }

        [Required(ErrorMessage = "O campo Valor é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O campo Valor deve ser maior que zero")]
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Imagem { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "A quantidade em estoque não pode ser negativa.")]
        public int QuantidadeEstoque { get; set; }
        [Range(3, double.MaxValue, ErrorMessage = "A quantidade minima em estoque é de 3 produtos.")]
        public int EstoqueMinimo { get; set; }
    }
}
