
using Domain;
using Domain.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        #region - Construtor
        private readonly string _produtoCaminhoArquivo;

        public ProdutoRepository()
        {
            _produtoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(),
                "FileJsonData", "produto.json");
        }

        #endregion

        #region - Funções do repositorio
        public void Adicionar(Produto novoProduto)
        {
            List<Produto> produtos = new List<Produto>();
            int proximoCodigo = ObterProximoCodigoDisponivel();
            produtos.Add(novoProduto);
            EscreverProdutosNoArquivo(produtos);
        }

        public Produto BuscarPorId(int codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> BuscarTodosAtivos()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Produto> BuscarTodosInativos()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Funções do arquivo
        private List<Produto> LerProdutosDoArquivo()
        {
            if (!System.IO.File.Exists(_produtoCaminhoArquivo))
            {
                return new List<Produto>();
            }

            string json = System.IO.File.ReadAllText(_produtoCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Produto>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<Produto> produtos = LerProdutosDoArquivo();
            if (produtos.Any())
            {
                return produtos.Max(p => p.Codigo) + 1;
            }
            else
            {
                return 1;
            }
        }

        private void EscreverProdutosNoArquivo(List<Produto> produtos)
        {
            string json = JsonConvert.SerializeObject(produtos);
            System.IO.File.WriteAllText(_produtoCaminhoArquivo, json);
        }

        #endregion
    }
}