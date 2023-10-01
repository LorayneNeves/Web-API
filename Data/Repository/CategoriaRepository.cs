using Domain;
using Domain.Entities;
using Domain.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly string _categoriaCaminhoArquivo;

        #region - Construtores
        public CategoriaRepository()
        {
            _categoriaCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "FileJsonData", "categoria.json");
        }

        #endregion

        #region - Funções
        public void Adicionar(Categoria categoria)
        {
            var categorias = LerCategoriasDoArquivo();
            int proximoCodigo = ObterProximoCodigoDisponivel();
            categoria.SetaCodigoProduto(proximoCodigo);
            categorias.Add(categoria);
            EscreverCategoriaNoArquivo(categorias);
        }

        public void Atualizar(Categoria categoria, int codigo)
        {         
            List<Categoria> listaCategoria = LerCategoriasDoArquivo();
            var categoriaExistente = listaCategoria.FirstOrDefault(p => p.Codigo == codigo);
            EscreverCategoriaNoArquivo(listaCategoria);
        }

        public Task<IEnumerable<Categoria>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<Categoria> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(int codigo)
        {
            List<Categoria> categoria = LerCategoriasDoArquivo();
            var categoriaExistente = categoria.FirstOrDefault(p => p.Codigo == codigo);
            
            categoria.Remove(categoriaExistente);
            EscreverCategoriaNoArquivo(categoria);
        }
        #endregion

        #region - Métodos arquivo
        private List<Categoria> LerCategoriasDoArquivo()
        {
            if (!System.IO.File.Exists(_categoriaCaminhoArquivo))
                return new List<Categoria>();
            string json = System.IO.File.ReadAllText(_categoriaCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<Categoria>>(json);
        }

        private int ObterProximoCodigoDisponivel()
        {
            List<Categoria> categoria = LerCategoriasDoArquivo();
            if (categoria.Any())
                return categoria.Max(p => p.Codigo) + 1;
            else
                return 1;
        }

        private void EscreverCategoriaNoArquivo(List<Categoria> categoria)
        {
            string json = JsonConvert.SerializeObject(categoria);
            System.IO.File.WriteAllText(_categoriaCaminhoArquivo, json);
        }

        public void Atualizar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Remover(Categoria categoria)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
