using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IProdutoRepository
    {
        public void Adicionar(Produto novoProduto);
        public Produto BuscarPorId(int codigo);

        public IEnumerable<Produto> BuscarTodos();
        public IEnumerable<Produto> BuscarTodosAtivos();
        public IEnumerable<Produto> BuscarTodosInativos();
    }
}
