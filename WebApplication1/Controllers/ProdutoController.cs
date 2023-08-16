using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using WebApplication1.Models.Request;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly string _produtoCaminhoArquivo;

        public ProdutoController()
        {
            _produtoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "produto.json");
        }

        #region Métodos arquivo
        private List<ProdutoViewModel> LerProdutosDoArquivo()
        {
            if (!System.IO.File.Exists(_produtoCaminhoArquivo))
            {
                return new List<ProdutoViewModel>();
            }

            string json = System.IO.File.ReadAllText(_produtoCaminhoArquivo);

            if (string.IsNullOrEmpty(json))
            {
                return new List<ProdutoViewModel>();
            }

            return JsonConvert.DeserializeObject<List<ProdutoViewModel>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<ProdutoViewModel> produtos = LerProdutosDoArquivo();
            if (produtos.Any())
            {
                return produtos.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverProdutosNoArquivo(List<ProdutoViewModel> produtos)
        {
            string json = JsonConvert.SerializeObject(produtos);
            System.IO.File.WriteAllText(_produtoCaminhoArquivo, json);
        }
        #endregion

        #region Operações CRUD
        [HttpGet("{codigo}")]
       public IActionResult Get(int codigo)
        {
            List < ProdutoViewModel> listaTodosProdutos = LerProdutosDoArquivo();
            var produtoProcurado = listaTodosProdutos.Where(p => p.Codigo == codigo);
            if (!produtoProcurado.Any()) return NotFound();
            
            return Ok(produtoProcurado.First());
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<ProdutoViewModel> listaTodosProdutos = LerProdutosDoArquivo();
            return Ok(listaTodosProdutos);
        }

        [HttpPost]
        public IActionResult Post(NovoProdutoViewModel novoProdutoViewModel)
        {
            if (novoProdutoViewModel == null)
            {
                return BadRequest();
            }
            List<ProdutoViewModel> produtos = LerProdutosDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();

            ProdutoViewModel novoProduto = new ProdutoViewModel()
            {
                Codigo = proximoCodigo,
                Descricao = novoProdutoViewModel.Descricao,
                Preco = novoProdutoViewModel.Preco,
                Estoque = novoProdutoViewModel.Estoque,
                Ativo = novoProdutoViewModel.Ativo
            };

            produtos.Add(novoProduto);
            EscreverProdutosNoArquivo(produtos);

            return CreatedAtAction(nameof(Get), new { codigo = novoProduto.Codigo }, novoProduto);

        }

        [HttpPut("{codigo}")]
        public IActionResult Put(int codigo,[FromBody] EditaProdutoViewModel editaProdutoViewModel)
        {
            return Ok();
        }

        [HttpDelete("{codigo}")]
        public IActionResult Delete(int codigo)
        {
            return Ok();
        }
        #endregion
    }
}
